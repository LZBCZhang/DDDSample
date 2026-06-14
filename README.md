# Consent Domain — .NET 10

## Projects

| Project | Type | Description |
|---|---|---|
| `ConsentOrchestrator` | Web API | Core consent orchestration — entry point |
| `OnetrustAdapter` | Web API | ACL — wraps OneTrust external API |
| `ConsentOrchestrator.Tests` | xUnit | Unit tests for orchestrator |
| `OnetrustAdapter.Tests` | xUnit | Unit tests for adapter |

## Quick start

```bash
# Requires .NET 10 SDK
dotnet restore
dotnet build

# Run ConsentOrchestrator
cd src/ConsentOrchestrator
dotnet run

# Run OnetrustAdapter
cd src/OnetrustAdapter
dotnet run

# Run tests
dotnet test
```

## Use case : Update user consent

```
POST api/consent/user/{userId}/{collectionPointId}
Content-Type: application/json
X-Correlation-Id: <uuid>

{
  "source": "web",
  "purposes": [
    {
      "id": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
      "status": "CONFIRMED",
      "communications": ["EMAIL", "PUSH-NOTIFICATION"]
    }
  ]
}
```

## Architecture

```
Request
  └─► ConsentOrchestrator API
        ├─ 1. Get purposes (cache → OnetrustAdapter fallback)
        ├─ 2. Update consents → OnetrustAdapter → OneTrust
        ├─ 3. Generate unsubscribe tokens
        ├─ 4. Publish ConsentUpdated → Service Bus topic: consent.updated
        └─ 5. Publish UnsubscribeLinkGenerated → Service Bus topic: unsubscribe.generated
```

## NuGet packages (centrally managed)

Versions are managed in `Directory.Packages.props`.

- `Azure.Messaging.ServiceBus` 7.x
- `Microsoft.Extensions.Http.Resilience` 9.x (Polly v8)
- `Microsoft.AspNetCore.OpenApi` 10.x
- `Serilog.AspNetCore` 8.x
