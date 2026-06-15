namespace ConsentOrchestrator.Domain.ValueObjects;

/// <summary>
/// A user's decision for a single purpose: the chosen status, the preference
/// options consented to within each communication preference, and any other
/// (non-communication) preferences. Immutable value object that carries the
/// intent into the <c>Consent</c> aggregate without leaking transport DTOs.
/// </summary>
public record ConsentDecision(
    PurposeId PurposeId,
    ConsentStatus Status,
    IReadOnlyList<CommunicationPreferenceDecision> CommunicationPreferences,
    IReadOnlyList<PreferenceOption> OtherPreferences);

/// <summary>The options a user consents to within one communication preference.</summary>
public record CommunicationPreferenceDecision(
    Guid CommunicationPreferenceId,
    IReadOnlyList<PreferenceOption> Options);