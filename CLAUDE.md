# CLAUDE.md

This file provides guidance to Claude Code (claude.ai/code) when working with code in this repository.

## Key notions
### Purpose definition
Each purpose can have multiple communication preferences and each communication preference can have multiple preference options.  
For example, a purpose can be "Marketing" and the communication preferences can be "Email", "SMS", "Push Notifications" etc.
Each communication preference can have multiple preference options like "Promotional Emails", "Transactional Emails" etc.
When we create a user consent, we can define the communication preferences and their respective preference options is the user has consented to or not.
Other preferences can be any additional preferences that are not related to communication, such as data sharing preferences or privacy settings.


Purpose {
Id: guid,
Name: string,
Description: stirng,
Status : ConsentStatus,
Version: int,
PurposeType: string,
CollectionPointId: CollectionPointId,
List<CommunicationPrefrences> CommunicationPreferences,
List<OtherPreferences> OtherPreferences
}


CommunicationPrefrences {
Id: guid,
Name: string,
Description: string,
Version: int,
CommunicationType: CommunicationPreferenceType,
List<PrefenrenceOptions> PreferenceOptions
}

PrefenrenceOption {
Id: guid,
Type: string,
IsConsented: bool
}

### User consent definition
A user can provide or withdraw consent for one or more processing purposes.
Consent can be provided through the User Preference Center, accessible from a web application, a mobile application, or through a call center.
A user can withdraw consent through several channels:
by using the unsubscribe link included in the email footer;
through the "Unsubscribe" header (List-Unsubscribe), which is commonly displayed by email providers such as Gmail;
via SMS, using the available opt-out mechanisms.


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



