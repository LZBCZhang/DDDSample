using System.Net;
using Azure.Messaging.ServiceBus;
using ConsentOrchestrator.Application.Contracts;
using ConsentOrchestrator.Application.DTOs.Responses;
using ConsentOrchestrator.Infrastructure.Http;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Moq;

namespace ConsentOrchestrator.Tests.Acceptance;

/// <summary>
/// Boots the ConsentOrchestrator API in-memory for acceptance testing. The two
/// outbound dependencies are faked: the OneTrust adapter is reached through the
/// real <see cref="OnetrustAdapterClient"/> wired onto an in-memory HTTP stub,
/// and Azure Service Bus is replaced by a mock that records published messages.
/// Everything in between (controller, middlewares, mapper, handler, domain,
/// cache, link generator, event bus) runs as in production.
/// </summary>
public sealed class ConsentApiFactory : WebApplicationFactory<Program>
{
    // ── Stubbed OnetrustAdapter behaviour (set per test) ──────────────
    public List<PurposeResponse> AvailablePurposes { get; } = [];
    public HttpStatusCode GetPurposesStatus { get; set; } = HttpStatusCode.OK;
    public bool GetPurposesReturnsNullBody { get; set; }
    public HttpStatusCode UpdateConsentsStatus { get; set; } = HttpStatusCode.OK;

    // ── Captured interactions (asserted by tests) ─────────────────────
    public int GetPurposesCallCount { get; set; }
    public int UpdateConsentsCallCount { get; set; }
    public List<string?> ReceivedCorrelationIds { get; } = [];
    public List<ServiceBusMessage> PublishedMessages { get; } = [];

    protected override void ConfigureWebHost(IWebHostBuilder builder)
    {
        builder.ConfigureAppConfiguration((_, config) =>
        {
            config.AddInMemoryCollection(new Dictionary<string, string?>
            {
                ["Frontend:BaseUri"] = "https://frontend.test",
                ["Unsubscribe:HmacSecret"] = "test-hmac-secret",
                ["OnetrustAdapter:BaseUri"] = "https://onetrust-adapter.test",
                ["ServiceBus:ConnectionString"] =
                    "Endpoint=sb://test.servicebus.windows.net/;SharedAccessKeyName=k;SharedAccessKey=secret",
            });
        });

        builder.ConfigureTestServices(services =>
        {
            // Replace the Azure Service Bus client with a mock that records the
            // messages produced by the real ServiceBusEventBus.
            services.RemoveAll<ServiceBusClient>();

            var senderMock = new Mock<ServiceBusSender>();
            senderMock
                .Setup(s => s.SendMessageAsync(It.IsAny<ServiceBusMessage>(), It.IsAny<CancellationToken>()))
                .Callback<ServiceBusMessage, CancellationToken>((message, _) => PublishedMessages.Add(message))
                .Returns(Task.CompletedTask);

            var clientMock = new Mock<ServiceBusClient>();
            clientMock
                .Setup(c => c.CreateSender(It.IsAny<string>()))
                .Returns(senderMock.Object);

            services.AddSingleton(clientMock.Object);

            // Route the real typed OnetrustAdapter HttpClient through an
            // in-memory stub so the adapter's HTTP code is exercised end-to-end.
            services
                .AddHttpClient<IOnetrustAdapterClient, OnetrustAdapterClient>()
                .ConfigurePrimaryHttpMessageHandler(() => new FakeOnetrustHandler(this));
        });
    }
}