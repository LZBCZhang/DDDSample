using ConsentOrchestrator.Application.DTOs.Enums;

namespace ConsentOrchestrator.Application.DTOs.Requests;

public record UpdateUserConsentRequest(
    string Source,
    IReadOnlyList<PurposeConsentRequest> Purposes);

public record PurposeConsentRequest(
    Guid Id,
    ConsentStatusDto Status,
    IReadOnlyList<CommunicationPreferenceConsentRequest> CommunicationPreferences,
    IReadOnlyList<PreferenceOptionConsentRequest> OtherPreferences);

public record CommunicationPreferenceConsentRequest(
    Guid Id,
    IReadOnlyList<PreferenceOptionConsentRequest> Options);

public record PreferenceOptionConsentRequest(
    Guid Id,
    string Type,
    bool IsConsented);