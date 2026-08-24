#!/usr/bin/env bash
set -euo pipefail

configuration="${CONFIG:-Release}"
output_dir="${FABULOUS_SCREENSHOT_DIR:-$PWD/artifacts/screenshots/avalonia}"
shard_index="${1:-0}"
shard_count="${2:-1}"
mkdir -p "$output_dir"

if ((shard_index < 0 || shard_index >= shard_count)); then
  echo "Invalid shard $shard_index of $shard_count." >&2
  exit 2
fi

mapfile -d '' projects < <(
  find samples/avalonia -name '*.fsproj' \
    ! -path '*/TestableApp.UnitTests/*' \
    ! -path '*/TestableApp.Headless.XUnit/*' \
    -print0 | sort -z
)

test "${#projects[@]}" -gt 0
printf 'Capturing Avalonia sample shard %d of %d.\n' "$shard_index" "$shard_count"

captured_projects=0
for project_index in "${!projects[@]}"; do
  project="${projects[$project_index]}"
  relative="${project#samples/avalonia/}"
  is_gallery=false
  if [[ "$relative" == "Gallery/Gallery.fsproj" ]]; then
    is_gallery=true
  elif ((project_index % shard_count != shard_index)); then
    continue
  fi

  slug="${relative%.fsproj}"
  slug="${slug//\//-}"
  slug="${slug// /-}"

  echo "::group::Build $relative"
  dotnet build "$project" -c "$configuration" -p:FabulousSamplesDesktopOnly=true \
    -p:FabulousIncludePremiumControls=false
  echo "::endgroup::"

  pages=("")
  if [[ "$is_gallery" == true ]]; then
    mapfile -t gallery_pages < <(python3 - <<'PY'
import re
from pathlib import Path

source = Path("samples/avalonia/Gallery/MainView.fs").read_text()
registry = source.split("let freeControlNames =", 1)[1].split("#if PREMIUM_CONTROLS", 1)[0]
for name in dict.fromkeys(re.findall(r'"([^"]+)"', registry)):
  print(name)
PY
)
    pages+=("${gallery_pages[@]}")
  fi

  for page_index in "${!pages[@]}"; do
    if [[ "$is_gallery" == true ]] && ((page_index % shard_count != shard_index)); then
      continue
    fi

    page="${pages[$page_index]}"
    page_slug="${page// /-}"
    page_slug="${page_slug//\//-}"
    capture_slug="$slug${page_slug:+-$page_slug}"
    log="$output_dir/$capture_slug.log"
    screenshot="$output_dir/$capture_slug.png"

    mapfile -t existing_windows < <(xdotool search --onlyvisible --name '.*' 2>/dev/null || true)
    FABULOUS_GALLERY_PAGE="$page" dotnet run --project "$project" -c "$configuration" -f net10.0 \
      -p:FabulousSamplesDesktopOnly=true -p:FabulousIncludePremiumControls=false \
      --no-build --no-restore >"$log" 2>&1 &
    app_pid=$!

    window_id=""
    for _ in {1..60}; do
      if ! kill -0 "$app_pid" 2>/dev/null; then
        cat "$log"
        echo "$relative exited before displaying $page." >&2
        exit 1
      fi

      mapfile -t visible_windows < <(xdotool search --onlyvisible --name '.*' 2>/dev/null || true)
      for candidate in "${visible_windows[@]}"; do
        if [[ ! " ${existing_windows[*]} " =~ " $candidate " ]]; then
          window_id="$candidate"
          break 2
        fi
      done
      sleep 1
    done

    if [[ -z "$window_id" ]]; then
      cat "$log"
      echo "$relative did not display $page within 60 seconds." >&2
      exit 1
    fi

    captured=false
    for _ in {1..10}; do
      if ! kill -0 "$app_pid" 2>/dev/null; then
        cat "$log"
        echo "$relative exited before $page could be captured." >&2
        exit 1
      fi

      mapfile -t visible_windows < <(xdotool search --onlyvisible --name '.*' 2>/dev/null || true)
      for candidate in "${visible_windows[@]}"; do
        if [[ ! " ${existing_windows[*]} " =~ " $candidate " ]]; then
          window_id="$candidate"
          break
        fi
      done

      xdotool windowactivate --sync "$window_id" 2>/dev/null || true
      if import -window "$window_id" "$screenshot" 2>>"$log"; then
        colors=$(identify -format '%k' "$screenshot")
        if [[ "$colors" -ge 2 ]]; then
          captured=true
          break
        fi
      fi

      rm -f "$screenshot"
      sleep 1
    done

    if [[ "$captured" != true ]]; then
      cat "$log"
      echo "$relative did not expose a stable window for $page." >&2
      exit 1
    fi

    kill "$app_pid" 2>/dev/null || true
    wait "$app_pid" 2>/dev/null || true
    printf 'Captured %s (%s colors).\n' "$screenshot" "$colors"
  done
  captured_projects=$((captured_projects + 1))
done

test "$captured_projects" -gt 0
printf 'Captured %d Avalonia sample applications.\n' "$captured_projects"
