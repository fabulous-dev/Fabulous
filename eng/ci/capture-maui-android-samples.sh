#!/usr/bin/env bash
set -euo pipefail

configuration="${CONFIG:-Release}"
output_dir="${FABULOUS_SCREENSHOT_DIR:-$PWD/artifacts/screenshots/maui-android}"
package_dir="${FABULOUS_ANDROID_PACKAGE_DIR:-$PWD/artifacts/android-packages}"
capture_mode="${FABULOUS_SAMPLE_CAPTURE_MODE:-all}"
coverage="$output_dir/coverage.tsv"
mkdir -p "$output_dir" "$package_dir"

if [[ "$capture_mode" != "all" && "$capture_mode" != "gallery" ]]; then
  echo "Invalid capture mode: $capture_mode." >&2
  exit 2
fi

assert_png() {
  python3 - "$1" <<'PY'
import struct
import sys
from pathlib import Path

path = Path(sys.argv[1])
data = path.read_bytes()
if len(data) < 24 or data[:8] != b"\x89PNG\r\n\x1a\n":
    raise SystemExit(f"{path} is not a PNG")
width, height = struct.unpack(">II", data[16:24])
if width < 100 or height < 100 or len(data) < 1000:
    raise SystemExit(f"{path} is unexpectedly small: {width}x{height}, {len(data)} bytes")
print(f"Captured {path} ({width}x{height}, {len(data)} bytes).")
PY
}

wait_for_process() {
  local application_id="$1"
  local logcat_path="$2"

  for _ in {1..30}; do
    if adb shell pidof "$application_id" >/dev/null; then
      return 0
    fi
    sleep 1
  done

  adb logcat -d -t 300 >"$logcat_path"
  echo "$application_id did not remain running. See $logcat_path." >&2
  return 1
}

smoke_test() {
  local application_id="$1"
  local apk="$2"
  local logcat_path="$output_dir/$application_id.logcat.txt"

  test -s "$apk"
  adb uninstall "$application_id" || true
  adb install -r "$apk"
  adb logcat -c
  adb shell monkey -p "$application_id" -c android.intent.category.LAUNCHER 1
  wait_for_process "$application_id" "$logcat_path"
}

capture_gallery_pages() {
  local slug="$1"
  local application_id="$2"
  local component
  component=$(adb shell cmd package resolve-activity --brief "$application_id" | tr -d '\r' | tail -n 1)
  mapfile -t sample_names < <(python3 - <<'PY'
import re
from pathlib import Path

source = Path("samples/maui/Gallery/Samples.fs").read_text()
for name in re.findall(r"\b(\w+)\.sample", source):
    print(name)
PY
)

  test "${#sample_names[@]}" -gt 0
  for index in "${!sample_names[@]}"; do
    sample_name="${sample_names[$index]}"
    adb shell am start -S -n "$component" --ei fabulousGallerySampleIndex "$index"
    sleep 3
    adb exec-out screencap -p >"$output_dir/$slug-$sample_name.png"
    assert_png "$output_dir/$slug-$sample_name.png"
  done
}

mark_captured() {
  python3 - "$coverage" "$1" <<'PY'
import sys
from pathlib import Path

path = Path(sys.argv[1])
project = sys.argv[2]
lines = path.read_text().splitlines()
expected = f"{project}\tandroid\tbuilt\t"
replacement = f"{project}\tandroid\tcaptured\t"
if lines.count(expected) != 1:
    raise SystemExit(f"Expected exactly one coverage row for {project}")
path.write_text("\n".join(replacement if line == expected else line for line in lines) + "\n")
PY
}

if [[ "$capture_mode" == "gallery" ]]; then
  projects=("samples/maui/Gallery/Gallery.fsproj")
else
  mapfile -d '' projects < <(
    find samples/maui -name '*.fsproj' \
      ! -path '*/WinUICompat/*' \
      -print0 | sort -z
  )
fi

test "${#projects[@]}" -gt 0

build_samples() {
  local shard_index="${1:-0}"
  local shard_count="${2:-1}"
  local manifest="$package_dir/samples-$shard_index.tsv"
  local built=0

  if ((shard_index < 0 || shard_index >= shard_count)); then
    echo "Invalid shard $shard_index of $shard_count." >&2
    exit 2
  fi

  : >"$manifest"
  printf 'Building Android sample shard %d of %d.\n' "$shard_index" "$shard_count"

  for project_index in "${!projects[@]}"; do
    if ((project_index % shard_count != shard_index)); then
      continue
    fi

    project="${projects[$project_index]}"
    relative="${project#samples/maui/}"
    slug="${relative%.fsproj}"
    slug="${slug//\//-}"
    slug="${slug// /-}"

    echo "::group::Build $relative"
    dotnet build "$project" -t:SignAndroidPackage -c "$configuration" -f net10.0-android -r android-x64 \
      -p:FabulousAndroidOnly=true \
      -p:EmbedAssembliesIntoApk=true \
      -p:AndroidPackageFormat=apk -p:AndroidPackageFormats=apk
    echo "::endgroup::"

    apk=$(find "$(dirname "$project")/bin/$configuration/net10.0-android" \
      -name '*-Signed.apk' -print -quit)
    if [[ -z "$apk" ]]; then
      echo "$relative did not produce a signed APK." >&2
      exit 1
    fi

    application_id=$(dotnet msbuild "$project" -getProperty:ApplicationId \
      -p:FabulousAndroidOnly=true \
      --nologo | tail -n 1)
    if [[ -z "$application_id" ]]; then
      echo "$relative has no Android application ID." >&2
      exit 1
    fi

    apk_name="$slug.apk"
    cp "$apk" "$package_dir/$apk_name"
    printf '%s\t%s\t%s\t%s\n' "$slug" "$relative" "$application_id" "$apk_name" >>"$manifest"
    built=$((built + 1))
  done

  test "$built" -gt 0
}

capture_samples() {
  mapfile -t manifests < <(find "$package_dir" -maxdepth 1 -name 'samples-*.tsv' -type f | sort)
  test "${#manifests[@]}" -gt 0

  actual_count=$(cat "${manifests[@]}" | wc -l)
  unique_count=$(cat "${manifests[@]}" | cut -f2 | sort -u | wc -l)
  test "$actual_count" -eq "${#projects[@]}"
  test "$unique_count" -eq "${#projects[@]}"

  printf 'project\tplatform\tstatus\treason\n' >"$coverage"
  while IFS=$'\t' read -r _ relative _ _; do
    printf '%s\tandroid\tbuilt\t\n' "$relative" >>"$coverage"
  done < <(cat "${manifests[@]}" | sort -t $'\t' -k2,2)

  while IFS= read -r project; do
    relative="${project#samples/maui/}"
    printf '%s\twindows\tbuild-only\tWinUI has no Android runtime\n' "$relative" >>"$coverage"
  done < <(find samples/maui/WinUICompat -name '*.fsproj' | sort)

  while IFS=$'\t' read -r slug relative application_id apk_name; do
    apk="$package_dir/$apk_name"
    test -s "$apk"
    screenshot="$output_dir/$slug.png"
    echo "::group::Launch $relative"
    adb install -r "$apk"
    adb shell am force-stop "$application_id"
    adb logcat -c
    adb shell monkey -p "$application_id" -c android.intent.category.LAUNCHER 1
    wait_for_process "$application_id" "$output_dir/$slug.logcat.txt"

    sleep 3
    adb exec-out screencap -p >"$screenshot"
    assert_png "$screenshot"

    if [[ "$relative" == "Gallery/Gallery.fsproj" && "$capture_mode" == "all" ]]; then
      capture_gallery_pages "$slug" "$application_id"
    fi
    mark_captured "$relative"

    adb shell am force-stop "$application_id"
    adb uninstall "$application_id"
    echo "::endgroup::"
  done < <(cat "${manifests[@]}" | sort -t $'\t' -k2,2)
}

case "${1:-}" in
  build) build_samples "${2:-0}" "${3:-1}" ;;
  capture) capture_samples ;;
  smoke) smoke_test "${2:?application ID is required}" "${3:?APK path is required}" ;;
  *) echo "Usage: $0 build [shard-index shard-count]|capture|smoke application-id apk" >&2; exit 2 ;;
esac
