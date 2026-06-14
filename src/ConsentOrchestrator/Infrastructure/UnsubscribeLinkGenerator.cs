using ConsentOrchestrator.Domain.Interfaces;
using ConsentOrchestrator.Domain.ValueObjects;

namespace ConsentOrchestrator.Infrastructure;

/// <summary>
/// Builds an unsubscribe link by issuing an opaque <see cref="UnsubscribeToken"/>
/// and composing the frontend URL the user can follow to revoke a purpose.
/// </summary>
public class UnsubscribeLinkGenerator(
    string frontendBaseUri,
    IHmacTokenGenerator hmacTokenGenerator) : IUnsubscribeLinkGenerator
{
    public UnsubscribeLink Generate(UserId userId, CollectionPointId collectionPointId, PurposeId purposeId)
    {
        var token = UnsubscribeToken.Generate(hmacTokenGenerator, userId, collectionPointId, purposeId);
        var url = $"{frontendBaseUri}/unsubscribe?token={token}";
        return new UnsubscribeLink(purposeId, url);
    }
}
