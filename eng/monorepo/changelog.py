#!/usr/bin/env python3

import argparse
import re
from pathlib import Path

HEADING = re.compile(r"^## \[(?P<version>[^]]+)](?: - (?P<date>\d{4}-\d{2}-\d{2}))?$", re.MULTILINE)
VERSION = re.compile(r"^10\.0\.\d+(?:-[0-9A-Za-z.-]+)?$")


def releases(text: str):
    return [match for match in HEADING.finditer(text) if match.group("version") != "Unreleased"]


def validate_structure(text: str) -> None:
    matches = list(HEADING.finditer(text))
    unreleased = [match for match in matches if match.group("version") == "Unreleased"]
    if len(unreleased) != 1 or not matches or matches[0].group("version") != "Unreleased":
        raise SystemExit("CHANGELOG.md must start with exactly one ## [Unreleased] section.")


def current_version(text: str) -> str:
    matches = releases(text)
    if not matches:
        raise SystemExit("No released version section found.")
    return matches[0].group("version")


def validate_version(version: str) -> None:
    if not VERSION.fullmatch(version):
        raise SystemExit(f"Release version must use the 10.0.x line: {version}")


def release_notes(text: str, version: str) -> str:
    matches = releases(text)
    for index, match in enumerate(matches):
        if match.group("version") == version:
            if match.group("date") is None:
                raise SystemExit(f"Release section {version} must include a YYYY-MM-DD date.")
            start = match.end()
            end = matches[index + 1].start() if index + 1 < len(matches) else len(text)
            notes = text[start:end].strip()
            if not notes:
                raise SystemExit(f"Release section {version} is empty.")
            return notes
    raise SystemExit(f"Release section not found: {version}")


def main() -> None:
    parser = argparse.ArgumentParser()
    parser.add_argument("command", choices=("current-version", "validate-version", "notes"))
    parser.add_argument("changelog", type=Path)
    parser.add_argument("version", nargs="?")
    args = parser.parse_args()

    text = args.changelog.read_text(encoding="utf-8")
    validate_structure(text)
    if args.command == "current-version":
        print(current_version(text))
    elif args.command == "validate-version" and args.version:
        validate_version(args.version)
    elif args.version:
        validate_version(args.version)
        print(release_notes(text, args.version))
    else:
        parser.error(f"{args.command} requires a version")


if __name__ == "__main__":
    main()
