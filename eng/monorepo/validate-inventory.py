#!/usr/bin/env python3

import json
import sys
from pathlib import Path, PurePosixPath


def fail(message: str) -> None:
    print(f"Migration inventory is invalid: {message}", file=sys.stderr)
    raise SystemExit(1)


inventory_path = Path(__file__).with_name("repositories.json")

with inventory_path.open(encoding="utf-8") as inventory_file:
    inventory = json.load(inventory_file)

if inventory.get("schemaVersion") != 1:
    fail("schemaVersion must be 1")

if inventory.get("target") != "fabulous-dev/Fabulous":
    fail("target must be fabulous-dev/Fabulous")

repositories = inventory.get("repositories")
if not isinstance(repositories, list) or not repositories:
    fail("repositories must be a non-empty array")

required_fields = {"name", "repository", "destination", "ref", "wave", "status"}

for repository in repositories:
    missing_fields = required_fields - repository.keys()
    if missing_fields:
        fail(f"{repository.get('name', '<unnamed>')} is missing {sorted(missing_fields)}")

for field in ("name", "repository", "destination"):
    values = [repository[field] for repository in repositories if repository[field] is not None]
    if len(values) != len(set(values)):
        fail(f"{field} values must be unique")

targets = [repository for repository in repositories if repository["status"] == "target"]
if len(targets) != 1 or targets[0]["repository"] != inventory["target"]:
    fail("exactly one target entry must match target")

if targets[0]["destination"] != "." or targets[0]["wave"] != 0:
    fail("the target entry must use destination '.' and wave 0")

for repository in repositories:
    searchable_value = " ".join(
        str(repository.get(field, "")) for field in ("name", "repository", "destination")
    ).lower()

    if "xamarin" in searchable_value or "legacy" in searchable_value:
        fail(f"legacy repository is not a migration input: {repository['name']}")

    if repository["repository"] == "fabulous-dev/.github":
        fail("the organization .github repository is outside the monorepo")

    destination_value = repository["destination"]
    if destination_value and destination_value.startswith(("platforms/", "extensions/", "compat/")):
        fail(f"{repository['name']} must use the consolidated root layout")

    if repository["status"] != "pending":
        continue

    if repository["wave"] not in (1, 2, 3):
        fail(f"{repository['name']} must be assigned to migration wave 1, 2, or 3")

    destination = PurePosixPath(repository["destination"])
    if destination.is_absolute() or ".." in destination.parts or destination == PurePosixPath("."):
        fail(f"{repository['name']} has an unsafe destination")

maui = next(
    (repository for repository in repositories if repository["name"] == "Fabulous.MauiControls"),
    None,
)

if maui is None or maui["ref"] != "update-fabulous-api":
    fail("Fabulous.MauiControls must use the PR #71 alignment branch")

if "0059326758cd5530d8676d9b2c9a154e173111ab" not in maui.get("notes", ""):
    fail("Fabulous.MauiControls must record the validated PR #71 commit")

repository_root = inventory_path.parents[2]

if (repository_root / "platforms").exists():
    fail("the retired platforms directory must not exist")

for nested_path in repository_root.rglob("*"):
    relative_path = nested_path.relative_to(repository_root)
    if ".git" in relative_path.parts:
        continue

    if relative_path != Path(".github") and nested_path.is_dir() and nested_path.name == ".github":
        fail(f"nested GitHub configuration is not allowed: {relative_path}")

    allowed_engineering_files = {
        Path("Directory.Build.props"),
        Path("Directory.Packages.props"),
        Path(".config/dotnet-tools.json"),
    }
    if relative_path not in allowed_engineering_files and relative_path.name in {
        "Directory.Build.props",
        "Directory.Packages.props",
        "dotnet-tools.json",
    }:
        fail(f"nested engineering configuration is not allowed: {relative_path}")

print(f"Validated {len(repositories)} monorepo migration entries.")