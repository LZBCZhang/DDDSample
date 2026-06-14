namespace ConsentOrchestrator.Application.UseCases.Unsubscribe;

/// <summary>Request to unsubscribe a user from a purpose via a signed token.</summary>
public record UnsubscribeCommand(string Token, string CorrelationId);