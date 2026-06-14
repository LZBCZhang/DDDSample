using ConsentOrchestrator.Domain.ValueObjects;

namespace ConsentOrchestrator.Domain.Exceptions;

/// <summary>Raised when a decision references a purpose not offered at the collection point.</summary>
public sealed class UnknownPurposeException(PurposeId purposeId)
    : Exception($"Unknown purpose {purposeId} for the given collection point.");
