using ConsentOrchestrator.Application.Contracts;
using ConsentOrchestrator.Domain.Exceptions;
using ConsentOrchestrator.Domain.Interfaces;
using ConsentOrchestrator.Domain.ValueObjects;
using Microsoft.Extensions.Logging;

namespace ConsentOrchestrator.Application.UseCases.Unsubscribe;

/// <summary>
/// Handles the one-click unsubscribe followed from an email link. The signed
/// token is authenticated and decoded back into the user / collection point /
/// purpose it targets, then consent for that purpose is withdrawn in OneTrust
/// through the adapter.
/// </summary>
public class UnsubscribeHandler(
    IHmacTokenGenerator hmacTokenGenerator,
    IOnetrustAdapterClient onetrustClient,
    ILogger<UnsubscribeHandler> logger)
{
    public async Task HandleAsync(UnsubscribeCommand command, CancellationToken ct = default)
    {
        // Validate the token's signature and recover the identifiers it carries.
        var token = UnsubscribeToken.Decode(hmacTokenGenerator, command.Token)
            ?? throw new InvalidUnsubscribeTokenException();

        logger.LogInformation(
            "[{CorrelationId}] Unsubscribe request for user {UserId} / purpose {PurposeId}",
            command.CorrelationId, token.UserId, token.PurposeId);

        // Unsubscribing withdraws consent for that single purpose.
        var decision = new ConsentDecision(token.PurposeId, ConsentStatus.Declined, [], []);

        await onetrustClient.UpdateUserConsentsAsync(
            token.UserId,
            token.CollectionPointId,
            [decision],
            command.CorrelationId,
            ct);

        logger.LogInformation(
            "[{CorrelationId}] User {UserId} unsubscribed from purpose {PurposeId}",
            command.CorrelationId, token.UserId, token.PurposeId);
    }
}