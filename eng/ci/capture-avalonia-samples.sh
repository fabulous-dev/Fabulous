#!/usr/bin/env bash
set -euo pipefail

configuration="${CONFIG:-Release}"
output_dir="${FABULOUS_SCREENSHOT_DIR:-$PWD/artifacts/screenshots/avalonia}"
mkdir -p "$output_dir"

mapfile -d '' projects < <(
  find samples/avalonia -name '*.fsproj' \
    ! -path '*/TestableApp.UnitTests/*' \
    ! -path '*/TestableApp.Headless.XUnit/*' \
    -print0 | sort -z
)

test "${#projects[@]}" -gt 0
printf 'Capturing %d Avalonia sample applications.\n' "${#projects[@]}"

for project in "${projects[@]}"; do
  relative="${project#samples/avalonia/}"
  slug="${relative%.fsproj}"
  slug="${slug//\//-}"
  slug="${slug// /-}"

  echo "::group::Build $relative"
  dotnet build "$project" -c "$configuration" -p:FabulousSamplesDesktopOnly=true
  echo "::endgroup::"

  pages=("")
  if [[ "$relative" == "Gallery/Gallery.fsproj" ]]; then
    mapfile -t gallery_pages < <(python3 - <<'PY'
import re
from pathlib import Path

source = Path("samples/avalonia/Gallery/MainView.fs").read_text()
registry = source.split("let controlNames =", 1)[1].split("let program =", 1)[0]
for name in dict.fromkeys(re.findall(r'"([^"]+)"', registry)):
    print(name)
PY
)
    pages+=("${gallery_pages[@]}")
  fi

  for page in "${pages[@]}"; do
    page_slug="${page// /-}"
    page_slug="${page_slug//\//-}"
    capture_slug="$slug${page_slug:+-$page_slug}"
    log="$output_dir/$capture_slug.log"
    screenshot="$output_dir/$capture_slug.png"

    mapfile -t existing_windows < <(xdotool search --onlyvisible --name '.*' 2>/dev/null || true)
    FABULOUS_GALLERY_PAGE="$page" dotnet run --project "$project" -c "$configuration" -f net10.0 \
      -p:FabulousSamplesDesktopOnly=true --no-build >"$log" 2>&1 &
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

    xdotool windowactivate --sync "$window_id" 2>/dev/null || true
    sleep 2
    import -window "$window_id" "$screenshot"

    colors=$(identify -format '%k' "$screenshot")
    if [[ "$colors" -lt 2 ]]; then
      echo "$relative $page produced a blank screenshot." >&2
      exit 1
    fi

    kill "$app_pid" 2>/dev/null || true
    wait "$app_pid" 2>/dev/null || true
    printf 'Captured %s (%s colors).\n' "$screenshot" "$colors"
  done
done

printf 'Captured %d Avalonia sample screenshots.\n' "${#projects[@]}"
