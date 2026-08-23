#!/usr/bin/env python3

import json
import sys
from pathlib import Path


if len(sys.argv) != 2 or not sys.argv[1].strip():
    print("Usage: prepare-templates.py <version>", file=sys.stderr)
    raise SystemExit(2)

version = sys.argv[1].strip()
repository_root = Path(__file__).parents[2]
template_files = sorted((repository_root / "templates").glob("**/.template.config/template.json"))
replacement_count = 0

for template_file in template_files:
    template = json.loads(template_file.read_text(encoding="utf-8"))

    for symbol in template.get("symbols", {}).values():
        if symbol.get("defaultValue") == "PKG_VERSION":
            symbol["defaultValue"] = version
            replacement_count += 1

    template_file.write_text(json.dumps(template, indent=2) + "\n", encoding="utf-8")

if replacement_count != 8:
    print(f"Expected 8 package version tokens, replaced {replacement_count}.", file=sys.stderr)
    raise SystemExit(1)

print(f"Prepared {len(template_files)} templates for version {version}.")