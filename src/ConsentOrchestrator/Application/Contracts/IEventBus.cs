using ConsentOrchestrator.Domain.Events;

namespace ConsentOrchestrator.Application.Contracts;

public interface IEventBus
{
    Task PublishAsync(IDomainEvent domainEvent, CancellationToken ct = default);
}
