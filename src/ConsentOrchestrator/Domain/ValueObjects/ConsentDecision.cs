namespace ConsentOrchestrator.Domain.ValueObjects;

/// <summary>
/// A user's decision for a single purpose: the chosen status and the
/// communication channels (by type) they consent to. Immutable value object
/// that carries the intent into the <c>Consent</c> aggregate without leaking
/// transport DTOs into the domain.
/// </summary>
public record ConsentDecision(
    PurposeId PurposeId,
    ConsentStatus Status,
    IReadOnlyList<string> Communications);
