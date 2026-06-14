namespace ConsentOrchestrator.Domain.ValueObjects;

/// <summary>
/// An unsubscribe link generated for a purpose. Immutable value object holding
/// the purpose it targets and the resolved URL the user can follow.
/// </summary>
public record UnsubscribeLink(PurposeId PurposeId, string Url);
