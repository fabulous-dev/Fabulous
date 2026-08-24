#!/usr/bin/env python3
"""Validate local Markdown links and reject retired Fabulous documentation hosts."""

from __future__ import annotations

import argparse
import re
import sys
from pathlib import Path
from urllib.parse import unquote, urlsplit


RETIRED_HOSTS = {"fabulous.dev", "docs.fabulous.dev", "api.fabulous.dev"}
LINK_RE = re.compile(r"(?<!!)\[[^\]]*\]\(([^)]+)\)")
HEADING_RE = re.compile(r"^#{1,6}\s+(.+?)\s*#?\s*$")
LEGACY_DOC_DIRS = {
    Path("docs/advanced"),
    Path("docs/avalonia"),
    Path("docs/basics"),
    Path("docs/maui"),
    Path("docs/samples-and-tutorials"),
    Path("docs/api/avalonia"),
    Path("docs/api/maui"),
}
LEGACY_DOC_FILES = {Path("docs/api/SUMMARY.md")}


def slugify(text: str) -> str:
    text = re.sub(r"<[^>]+>", "", text).strip().lower()
    text = re.sub(r"[^\w\- ]", "", text)
    return re.sub(r"[\s\-]+", "-", text).strip("-")


def anchors(path: Path) -> set[str]:
    result: set[str] = set()
    counts: dict[str, int] = {}
    in_fence = False

    for line in path.read_text(encoding="utf-8").splitlines():
        if line.lstrip().startswith("```"):
            in_fence = not in_fence
            continue
        if in_fence:
            continue
        match = HEADING_RE.match(line)
        if match:
            base = slugify(match.group(1))
            count = counts.get(base, 0)
            counts[base] = count + 1
            result.add(base if count == 0 else f"{base}_{count}")

    return result


def markdown_files(root: Path) -> list[Path]:
    files = []
    for path in root.rglob("*.md"):
        relative = path.relative_to(root)
        if ".git" in path.parts or relative in LEGACY_DOC_FILES:
            continue
        if any(relative.is_relative_to(directory) for directory in LEGACY_DOC_DIRS):
            continue
        files.append(path)
    return sorted(files)


def validate(root: Path) -> list[str]:
    failures: list[str] = []
    anchor_cache: dict[Path, set[str]] = {}

    for source in markdown_files(root):
        in_fence = False
        for line_number, line in enumerate(source.read_text(encoding="utf-8").splitlines(), 1):
            if line.lstrip().startswith("```"):
                in_fence = not in_fence
                continue
            if in_fence:
                continue

            for raw_target in LINK_RE.findall(line):
                target = raw_target.strip().split(maxsplit=1)[0].strip("<>")
                if "{" in target or "}" in target:
                    continue
                parsed = urlsplit(target)

                if parsed.hostname and parsed.hostname.lower() in RETIRED_HOSTS:
                    failures.append(f"{source.relative_to(root)}:{line_number}: retired host: {target}")
                    continue
                if parsed.scheme or target.startswith(("mailto:", "#")):
                    continue

                relative_path = unquote(parsed.path)
                destination = (source.parent / relative_path).resolve() if relative_path else source.resolve()
                if not destination.exists():
                    failures.append(f"{source.relative_to(root)}:{line_number}: missing target: {target}")
                    continue

                if parsed.fragment and destination.is_file() and destination.suffix.lower() == ".md":
                    destination_anchors = anchor_cache.setdefault(destination, anchors(destination))
                    if unquote(parsed.fragment).lower() not in destination_anchors:
                        failures.append(f"{source.relative_to(root)}:{line_number}: missing anchor: {target}")

    return failures


def main() -> int:
    parser = argparse.ArgumentParser()
    parser.add_argument("root", nargs="?", type=Path, default=Path.cwd())
    args = parser.parse_args()
    root = args.root.resolve()
    failures = validate(root)

    if failures:
        print("Documentation link validation failed:", file=sys.stderr)
        for failure in failures:
            print(f"- {failure}", file=sys.stderr)
        return 1

    print(f"Documentation links valid ({len(markdown_files(root))} Markdown files checked).")
    return 0


if __name__ == "__main__":
    raise SystemExit(main())