using ConsentOrchestrator.Domain.ValueObjects;

namespace ConsentOrchestrator.Domain.Interfaces;

/// <summary>
/// Domain service that produces an unsubscribe link for a user/purpose pair.
/// Generating the link is a meaningful domain operation that does not naturally
/// belong to an entity or value object, so it is expressed as a standalone service.
/// </summary>
public interface IUnsubscribeLinkGenerator
{
    UnsubscribeLink Generate(UserId userId, CollectionPointId collectionPointId, PurposeId purposeId);
}
