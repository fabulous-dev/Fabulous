#!/usr/bin/env python3

import argparse
import re
import sys
import zipfile
from pathlib import Path
from xml.etree import ElementTree

EXPECTED_PACKAGE_COUNT = 13
REPOSITORY_URL = "https://github.com/fabulous-dev/Fabulous"
CONCRETE_VERSION = re.compile(r"^[0-9A-Za-z][0-9A-Za-z.+-]*$")


def fail(message: str) -> None:
    raise ValueError(message)


def local_name(element: ElementTree.Element) -> str:
    return element.tag.rsplit("}", 1)[-1]


def child(parent: ElementTree.Element, name: str) -> ElementTree.Element:
    result = next((item for item in parent if local_name(item) == name), None)
    if result is None:
        fail(f"missing nuspec element: {name}")
    return result


def validate_package(package: Path, symbols: dict[str, Path]) -> None:
    with zipfile.ZipFile(package) as archive:
        names = set(archive.namelist())
        nuspec_names = [name for name in names if name.endswith(".nuspec")]
        if len(nuspec_names) != 1:
            fail(f"{package.name}: expected exactly one nuspec")

        root = ElementTree.fromstring(archive.read(nuspec_names[0]))
        metadata = child(root, "metadata")
        package_id = (child(metadata, "id").text or "").strip()

        for field in ("version", "authors", "description", "license"):
            if not (child(metadata, field).text or "").strip():
                fail(f"{package.name}: empty {field}")

        repository = child(metadata, "repository")
        if repository.get("url", "").rstrip("/") != REPOSITORY_URL:
            fail(f"{package.name}: unexpected repository URL")

        for field in ("readme", "icon"):
            archive_path = (child(metadata, field).text or "").strip()
            if not archive_path or archive_path not in names:
                fail(f"{package.name}: missing packaged {field} '{archive_path}'")

        for dependency in (item for item in metadata.iter() if local_name(item) == "dependency"):
            version = dependency.get("version", "")
            is_interval = (
                len(version) >= 3
                and version[0] in "[("
                and version[-1] in ")]"
                and version[1:-1].strip() not in ("", ",")
            )
            if not version or not (is_interval or CONCRETE_VERSION.fullmatch(version)):
                fail(f"{package.name}: dependency {dependency.get('id')} has an unbounded version '{version}'")

        assemblies = [name for name in names if name.startswith("lib/") and name.endswith(".dll")]
        if assemblies:
            symbol_package = symbols.get(package_id)
            if symbol_package is None:
                fail(f"{package.name}: library package has no matching .snupkg")
            with zipfile.ZipFile(symbol_package) as symbol_archive:
                pdbs = [name for name in symbol_archive.namelist() if name.endswith(".pdb")]
                if not pdbs:
                    fail(f"{symbol_package.name}: contains no portable PDB")


def package_id(package: Path) -> str:
    with zipfile.ZipFile(package) as archive:
        nuspec = next(name for name in archive.namelist() if name.endswith(".nuspec"))
        root = ElementTree.fromstring(archive.read(nuspec))
        metadata = child(root, "metadata")
        return (child(metadata, "id").text or "").strip()


def main() -> None:
    parser = argparse.ArgumentParser()
    parser.add_argument("package_directory", type=Path)
    args = parser.parse_args()

    packages = sorted(args.package_directory.glob("*.nupkg"))
    packages = [package for package in packages if not package.name.endswith(".symbols.nupkg")]
    if len(packages) != EXPECTED_PACKAGE_COUNT:
        fail(f"expected {EXPECTED_PACKAGE_COUNT} packages, found {len(packages)}")

    symbol_packages = {package_id(package): package for package in args.package_directory.glob("*.snupkg")}
    for package in packages:
        validate_package(package, symbol_packages)

    print(f"Validated {len(packages)} packages and {len(symbol_packages)} symbol packages.")


if __name__ == "__main__":
    try:
        main()
    except (ValueError, zipfile.BadZipFile, ElementTree.ParseError) as error:
        print(error, file=sys.stderr)
        raise SystemExit(1) from error