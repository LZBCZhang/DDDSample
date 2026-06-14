namespace ConsentOrchestrator.Domain.ValueObjects;

/// <summary>
/// A communication channel offered by a purpose (e.g. EMAIL, PUSH-NOTIFICATION).
/// Described purely by its attributes, so it is modelled as an immutable value object.
/// </summary>
public record CommunicationChannel(Guid Id, string Type);
