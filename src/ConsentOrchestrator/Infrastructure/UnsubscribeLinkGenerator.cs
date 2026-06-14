using ConsentOrchestrator.Domain.Interfaces;
using ConsentOrchestrator.Domain.ValueObjects;

namespace ConsentOrchestrator.Infrastructure;

/// <summary>
/// Builds an unsubscribe link by issuing an opaque <see cref="UnsubscribeToken"/>
/// and composing the frontend URL the user can follow to revoke a purpose.
/// </summary>
public class UnsubscribeLinkGenerator(string frontendBaseUri) : IUnsubscribeLinkGenerator
{
    public UnsubscribeLink Generate(UserId userId, PurposeId purposeId)
    {
        var token = UnsubscribeToken.Generate();
        var url = $"{frontendBaseUri}/unsubscribe?token={token}&purposeId={purposeId}";
        return new UnsubscribeLink(purposeId, url);
    }
}
