namespace ConsentOrchestrator.Domain.ValueObjects;

/// <summary>
/// A single option of a communication preference (e.g. "Promotional Emails"),
/// together with whether the user consents to it. Immutable value object.
/// </summary>
public record PreferenceOption(Guid Id, string Type, bool IsConsented);