namespace ConsentOrchestrator.Domain.ValueObjects;

/// <summary>
/// A non-communication preference attached to a purpose (e.g. data-sharing or
/// privacy settings), together with the user's consent for it. Immutable value object.
/// </summary>
public record OtherPreference(Guid Id, string Type, bool IsConsented);