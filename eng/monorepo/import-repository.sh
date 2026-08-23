#!/usr/bin/env bash

set -euo pipefail

usage() {
    cat <<'EOF'
Usage:
  import-repository.sh --check <source> <destination> <ref>
  import-repository.sh --import <source> <destination> <ref>

Imports a repository below the current repository using git subtree without
squashing its history. Run --check first, then run --import from a migration
branch after reviewing the source ref and destination in repositories.json.
EOF
}

if [[ $# -ne 4 ]]; then
    usage >&2
    exit 2
fi

mode="$1"
source_repository="$2"
destination="$3"
source_ref="$4"

if [[ "$mode" != "--check" && "$mode" != "--import" ]]; then
    usage >&2
    exit 2
fi

if ! git rev-parse --show-toplevel >/dev/null 2>&1; then
    echo "Run this command from within the Fabulous repository." >&2
    exit 1
fi

repository_root="$(git rev-parse --show-toplevel)"
cd "$repository_root"

if [[ -n "$(git status --porcelain)" ]]; then
    echo "The Fabulous worktree must be clean before an import." >&2
    exit 1
fi

if [[ ! -d "$source_repository/.git" && ! -f "$source_repository/HEAD" ]]; then
    echo "Source is not a local Git repository: $source_repository" >&2
    exit 1
fi

if ! git -C "$source_repository" rev-parse --verify --quiet "$source_ref^{commit}" >/dev/null; then
    echo "Source ref does not resolve to a commit: $source_ref" >&2
    exit 1
fi

if [[ "$destination" == "." || "$destination" == /* || "$destination" == *".."* ]]; then
    echo "Destination must be a new relative directory below the repository root." >&2
    exit 1
fi

if [[ -e "$destination" ]]; then
    echo "Destination already exists: $destination" >&2
    exit 1
fi

current_branch="$(git branch --show-current)"

if [[ -z "$current_branch" ]]; then
    echo "Imports require a checked-out migration branch." >&2
    exit 1
fi

if [[ "$current_branch" == "main" || "$current_branch" == "master" ]]; then
    echo "Create and check out a migration branch before importing." >&2
    exit 1
fi

source_commit="$(git -C "$source_repository" rev-parse "$source_ref^{commit}")"
echo "Source:      $source_repository@$source_ref ($source_commit)"
echo "Destination: $destination"
echo "Branch:      $current_branch"

if [[ "$mode" == "--check" ]]; then
    echo "Import preconditions passed."
    exit 0
fi

git subtree add --prefix="$destination" "$source_repository" "$source_ref"