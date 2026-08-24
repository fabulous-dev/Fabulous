#!/usr/bin/env bash
set -euo pipefail

configuration="${CONFIG:-Release}"
output_dir="${FABULOUS_SCREENSHOT_DIR:-$PWD/artifacts/screenshots/maui-android}"
manifest="$output_dir/samples.tsv"
coverage="$output_dir/coverage.tsv"
mkdir -p "$output_dir"

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

mapfile -d '' projects < <(
  find samples/maui -name '*.fsproj' \
    ! -path '*/WinUICompat/*' \
    -print0 | sort -z
)

test "${#projects[@]}" -gt 0

build_samples() {
  : >"$manifest"
  printf 'project\tplatform\tstatus\treason\n' >"$coverage"
  printf 'Building %d MAUI sample applications for Android.\n' "${#projects[@]}"

  for project in "${projects[@]}"; do
    relative="${project#samples/maui/}"
    slug="${relative%.fsproj}"
    slug="${slug//\//-}"
    slug="${slug// /-}"

    echo "::group::Build $relative"
    dotnet build "$project" -t:SignAndroidPackage -c "$configuration" -r android-x64 \
      -p:FabulousAndroidOnly=true \
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

    printf '%s\t%s\t%s\t%s\n' "$slug" "$relative" "$application_id" "$apk" >>"$manifest"
    printf '%s\tandroid\tbuilt\t\n' "$relative" >>"$coverage"
  done

  while IFS= read -r project; do
    relative="${project#samples/maui/}"
    printf '%s\twindows\tbuild-only\tWinUI has no Android runtime\n' "$relative" >>"$coverage"
  done < <(find samples/maui/WinUICompat -name '*.fsproj' | sort)
}

capture_samples() {
  test -s "$manifest"

  while IFS=$'\t' read -r slug relative application_id apk; do
    screenshot="$output_dir/$slug.png"
    echo "::group::Launch $relative"
    adb install -r "$apk"
    adb shell am force-stop "$application_id"
    adb shell monkey -p "$application_id" -c android.intent.category.LAUNCHER 1

    running=false
    for _ in {1..30}; do
      if adb shell pidof "$application_id" >/dev/null; then
        running=true
        break
      fi
      sleep 1
    done

    if [[ "$running" != true ]]; then
      adb logcat -d -t 300 >"$output_dir/$slug.logcat.txt"
      echo "$relative did not remain running." >&2
      exit 1
    fi

    sleep 3
    adb exec-out screencap -p >"$screenshot"
    assert_png "$screenshot"

    if [[ "$relative" == "Gallery/Gallery.fsproj" ]]; then
      capture_gallery_pages "$slug" "$application_id"
    fi
    mark_captured "$relative"

    adb shell am force-stop "$application_id"
    adb uninstall "$application_id"
    echo "::endgroup::"
  done <"$manifest"
}

case "${1:-}" in
  build) build_samples ;;
  capture) capture_samples ;;
  *) echo "Usage: $0 build|capture" >&2; exit 2 ;;
esac
