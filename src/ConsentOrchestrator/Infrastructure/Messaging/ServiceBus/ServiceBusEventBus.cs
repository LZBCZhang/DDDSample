using System.Text.Json;
using Azure.Messaging.ServiceBus;
using ConsentOrchestrator.Application.Contracts;
using ConsentOrchestrator.Domain.Events;
using Microsoft.Extensions.Logging;

namespace ConsentOrchestrator.Infrastructure.Messaging.ServiceBus;

public class ServiceBusEventBus(
    ServiceBusClient serviceBusClient,
    ServiceBusTopicOptions options,
    ILogger<ServiceBusEventBus> logger) : IEventBus
{
    private static readonly Dictionary<Type, string> TopicMap = new()
    {
        { typeof(ConsentUpdated),           "consent.updated" },
        { typeof(UnsubscribeLinkGenerated), "unsubscribe.generated" }
    };

    public async Task PublishAsync(IDomainEvent domainEvent, CancellationToken ct = default)
    {
        var eventType = domainEvent.GetType();

        if (!TopicMap.TryGetValue(eventType, out var topic))
            throw new InvalidOperationException($"No topic mapped for event type {eventType.Name}");

        var sender = serviceBusClient.CreateSender(topic);

        var body = JsonSerializer.Serialize(domainEvent, eventType);
        var message = new ServiceBusMessage(body)
        {
            ContentType        = "application/json",
            Subject            = eventType.Name,
            MessageId          = Guid.NewGuid().ToString(),
            ApplicationProperties = { ["EventType"] = eventType.Name }
        };

        logger.LogInformation(
            "Publishing event {EventType} to topic {Topic}",
            eventType.Name, topic);

        await sender.SendMessageAsync(message, ct);

        logger.LogInformation(
            "Event {EventType} published successfully to topic {Topic}",
            eventType.Name, topic);
    }
}

public record ServiceBusTopicOptions(
    string ConsentUpdatedTopic,
    string UnsubscribeGeneratedTopic);
