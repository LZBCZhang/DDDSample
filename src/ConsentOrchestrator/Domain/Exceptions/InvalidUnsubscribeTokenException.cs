namespace ConsentOrchestrator.Domain.Exceptions;

/// <summary>Raised when an unsubscribe token is malformed or has been tampered with.</summary>
public sealed class InvalidUnsubscribeTokenException()
    : Exception("The unsubscribe token is invalid or has been tampered with.");