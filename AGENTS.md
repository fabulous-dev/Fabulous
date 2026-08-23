# AGENTS.md

## Scope

These instructions apply to the entire repository.

## Repository Structure

- `src/neutral/`: Fabulous.Core, core tests, and benchmarks.
- `src/maui/`: .NET MAUI backend, extensions, tests, and WinUI compatibility.
- `src/avalonia/`: Avalonia backend, extensions, tests, and shared sample properties.
- `samples/maui/` and `samples/avalonia/`: runnable sample applications.
- `templates/maui/` and `templates/avalonia/`: `dotnet new` template packages.
- `docs/`: authored documentation and API reference sources.
- `website/`: Hugo site published through GitHub Pages.
- `eng/monorepo/`: repository validation, template preparation, and migration tooling.

Do not reintroduce nested repositories, `.github` directories, package catalogs, tool manifests, solutions, or platform engineering roots. `Fabulous.sln` is the only root solution.

## Product and Package Identity

- The core project and assembly are `Fabulous.Core`.
- The core NuGet package ID and public F# namespaces remain `Fabulous`.
- All packages use the unified `10.0.x` release line.
- Internal dependencies use project references during development.
- Keep package IDs and public APIs stable unless a reviewed breaking change requires otherwise.

## Build and Test

Run focused checks first, then the consolidated checks relevant to the change.

```bash
python3 -B eng/monorepo/validate-inventory.py
dotnet restore Fabulous.sln
dotnet test Fabulous.sln -c Release
```

Core formatting:

```bash
dotnet tool restore
dotnet fantomas --check src/neutral/Fabulous.Core
dotnet fantomas --check src/neutral/Fabulous.Tests
dotnet fantomas --check src/neutral/Fabulous.Benchmarks
```

Package validation:

```bash
dotnet pack Fabulous.sln -c Release --property PackageOutputPath="$PWD/nupkgs"
```

The solution should produce 13 non-symbol NuGet packages. Template package versions are prepared by:

```bash
python3 eng/monorepo/prepare-templates.py <version>
```

This command edits template JSON files. Use it only in a disposable checkout or release/CI context unless those changes are intentionally being committed.

## Platform Validation

- Linux CI builds and tests the consolidated solution.
- Avalonia sample tests use `-p:FabulousSamplesDesktopOnly=true` to avoid restoring mobile workloads.
- Windows CI installs the MAUI workload, builds WinUI compatibility, builds the TicTacToe Windows target, and builds a generated MAUI template app.
- Generated template smoke-test projects must be created outside the repository root so they do not inherit this repository's Central Package Management settings.
- Do not claim a MAUI application was runtime-tested when it was only compiled. Actual launch/render validation requires emulator, simulator, or UI automation coverage.

## Project and Package References

- Preserve local project references between source projects.
- Files packed for consumers must not expose monorepo-only project references. Guard local-only references with an `Exists(...)` condition or keep them out of packed props/targets.
- After moving projects, validate all `ProjectReference`, `Import`, README, icon, and packed-content paths.
- Keep `Directory.Packages.props` as the single central package catalog.

## Templates

- Template JSON uses `PKG_VERSION` for package versions resolved during CI/release preparation.
- Template smoke tests must restore against both the downloaded local package artifact directory and NuGet.org.
- Test generated applications as external consumers, not from inside the monorepo.

## Documentation

- Public documentation is hosted at `https://fabulous-dev.github.io/Fabulous/`.
- Use repository-relative links for tracked files and the GitHub Pages URLs for published documentation.
- Do not link to retired `fabulous.dev`, `docs.fabulous.dev`, or `api.fabulous.dev` deployments.
- Changes to `website/` or `docs/` must keep the combined Hugo and MkDocs Pages artifact buildable.

## CI and Releases

- Root workflows are under `.github/workflows/`; do not add nested workflows.
- CI must remain green on `main` before opening follow-up upgrade PRs.
- Releases are triggered by adding a new topmost `## [10.0.x] - YYYY-MM-DD` section to `CHANGELOG.md` and pushing it to `main`. The workflow creates the tag after publishing succeeds.
- NuGet publishing uses `NuGet/login@v1` with GitHub OIDC trusted publishing. Never add a long-lived NuGet API key.
- Do not create or push release tags without explicit authorization.

## Editing Guidelines

- Preserve existing F# style and compile order in project files.
- Use established builders, attributes, and extension patterns before adding abstractions.
- Add deterministic tests for behavior changes. Avoid wall-clock sleeps when a synchronous event or injectable scheduler can test the behavior.
- Keep changes focused; do not rewrite generated output or unrelated imported history.
- Never commit `bin/`, `obj/`, package output, generated template smoke apps, or temporary GitHub inventory scripts.
