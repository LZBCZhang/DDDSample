using ConsentOrchestrator.Application.DTOs.Enums;

namespace ConsentOrchestrator.Application.DTOs.Requests;

public record UpdateUserConsentRequest(
    string Source,
    IReadOnlyList<PurposeRequest> Purposes);

public record PurposeRequest(
    Guid Id,
    ConsentStatusDto Status,
    IReadOnlyList<string> Communications);
