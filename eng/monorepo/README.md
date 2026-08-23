# Monorepo migration

This directory tracks the migration of the active Fabulous repositories into
the single `fabulous-dev/Fabulous` repository. The migration keeps each active
source repository's commit history and leaves the source repositories available
until their replacement build, test, package, and documentation pipelines are
proven.

The legacy Xamarin.Forms repositories are not migration inputs. Organization
profile metadata in `fabulous-dev/.github` is also outside the product monorepo.

## Principles

- Import repositories with full history; do not squash or copy source trees.
- Import one migration wave at a time and keep each import independently
  reviewable.
- Keep every product, extension, compatibility, and test project under
  `src/neutral`, `src/maui`, or `src/avalonia`; keep examples under root
  `samples/` and templates under root `templates/`.
- Keep one root engineering system. Nested workflows, tool manifests, package
  catalogs, build properties, solutions, and repository policy files are
  removed after each history import.
- Replace package references between imported projects with project references.
- Keep package identities and public APIs stable unless a separately reviewed
  compatibility change requires otherwise.
- Build samples separately from package and test projects so platform workloads
  do not block unrelated validation.
- Publish packages and documentation only from the monorepo after equivalent CI
  has passed there.
- Publish authored and generated documentation from this repository with GitHub
  Pages; do not retain a separate documentation deployment repository.
- Archive a source repository only after its monorepo replacement is released.

The source refs, target directories, order, and current status are recorded in
`repositories.json`. In particular, the Maui import starts from PR #71 on
`update-fabulous-api` at commit `0059326758cd5530d8676d9b2c9a154e173111ab`.
That branch is current Maui `main` plus the Fabulous 3.0.0-pre23+ API alignment
commit.

Validate inventory changes locally with:

```bash
python3 eng/monorepo/validate-inventory.py
```

## Import procedure

By default, start each repository on a fresh branch from an up-to-date `main`
branch. An explicitly authorized direct import can set `ALLOW_MAIN_IMPORT=1`.
From the root of `Fabulous`, validate the import before executing it:

```bash
eng/monorepo/import-repository.sh \
  --check ../Fabulous.Avalonia platforms/avalonia main

eng/monorepo/import-repository.sh \
  --import ../Fabulous.Avalonia platforms/avalonia main
```

The import command uses `git subtree` without `--squash`. It creates a commit,
so inspect the source ref and destination before running it. Follow the import
with separate commits for build integration and dependency alignment; this
keeps the original repository history distinct from monorepo engineering.

## Migration gates

For each wave:

1. Import the repositories and record their exact source commits.
2. Consolidate shared MSBuild properties and centrally managed package versions.
3. Add package/test projects to the no-samples solution and make inter-project
   dependencies local project references.
4. Add platform-specific sample solutions and CI jobs only where their workloads
   and runners are available.
5. Pack every migrated package and compare package IDs, target frameworks,
   dependencies, and included files with the latest published package.
6. Add path-filtered pull request, nightly, release, and GitHub Pages workflows.
7. Release from the monorepo, verify NuGet and Pages, then archive the replaced
   repositories with a pointer to their new locations.

Wave 1 brought in Avalonia and the already-aligned Maui branch, including their
current samples and templates. The older standalone Avalonia samples repository
is therefore not a migration input. Wave 2 added Maui extensions and compatibility
support. `FSharp.Mobile.Templates` remains separate because it publishes plain
.NET platform templates and has no Fabulous dependency. Website and documentation
content publish through GitHub Pages. The Xamarin.Forms repositories remain
outside the monorepo and can be archived independently.