using ConsentOrchestrator.Domain.ValueObjects;

namespace ConsentOrchestrator.Application.UseCases.UpdateUserConsent;

public record UpdateUserConsentCommand(
    UserId UserId,
    CollectionPointId CollectionPointId,
    string Source,
    IReadOnlyList<ConsentDecision> Decisions,
    string CorrelationId);
