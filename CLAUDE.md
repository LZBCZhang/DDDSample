# CLAUDE.md

This file provides guidance to Claude Code (claude.ai/code) when working with code in this repository.

## Project

Consent-management system built as two ASP.NET Core (`net10.0`) APIs in `src/`:
- **ConsentOrchestrator** — orchestrates consent updates, caching, and domain-event publishing to Azure Service Bus.
- **OnetrustAdapter** — adapter over the external OneTrust API.

`ddd.md` is the domain/design spec. Consult it for domain rules and intended behavior before implementing or changing domain logic.

## Build & test

```bash
dotnet restore
dotnet build
dotnet test                               # all tests
dotnet test --filter "FullyQualifiedName~UpdateUserConsent"   # single test/class
dotnet format                             # run before considering work done (see below)
```

Run an API locally: `cd src/ConsentOrchestrator && dotnet run` (or `OnetrustAdapter`).

- Uses .NET 10 SDK pinned in `global.json` (`rollForward: latestMinor`).
- Central Package Management: add/upgrade NuGet versions in `Directory.Packages.props`, not in individual `.csproj` files.

## Build is strict — `dotnet format` before finishing

`Directory.Build.props` sets `TreatWarningsAsErrors=true`, `EnforceCodeStyleInBuild=true`, `Nullable=enable`, `AnalysisLevel=latest`, and `LangVersion=preview`. Any analyzer or code-style warning fails the build. Always run `dotnet format` (and resolve nullable warnings) before treating a change as done.

## Code style (`.editorconfig`)

- 4-space indentation, CRLF line endings, UTF-8 BOM, final newline.
- Private fields must be `_camelCase` (underscore prefix) — enforced.
- `ImplicitUsings=enable` — don't add redundant `using` directives.

## Architecture

Read ddd.md

## Tests

xUnit + Moq + FluentAssertions, in `tests/`, organized by use case mirroring `src/`.



