namespace ConsentOrchestrator.Domain.Exceptions;

/// <summary>Raised when a consent would violate an aggregate invariant.</summary>
public sealed class InvalidConsentException(string message) : Exception(message);
