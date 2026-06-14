using ConsentOrchestrator.Domain.ValueObjects;

namespace ConsentOrchestrator.Domain.Events;

public record UnsubscribeLinkGenerated(
    UserId UserId,
    IReadOnlyList<UnsubscribeLink> Links,
    DateTimeOffset OccurredAt) : IDomainEvent;
