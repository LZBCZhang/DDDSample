namespace ConsentOrchestrator.Domain.ValueObjects;

/// <summary>
/// Identity of a <c>Consent</c> aggregate: a user's consent at a given collection point.
/// </summary>
public record ConsentId(UserId UserId, CollectionPointId CollectionPointId)
{
    public override string ToString() => $"{UserId}:{CollectionPointId}";
}
