using ConsentOrchestrator.Domain.ValueObjects;

namespace ConsentOrchestrator.Application.UseCases.UpdateUserConsent;

public record UpdateUserConsentResult(
    IReadOnlyList<UnsubscribeLink> UnsubscribeLinks);
