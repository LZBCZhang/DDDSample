using Azure.Messaging.ServiceBus;
using ConsentOrchestrator.Application.Contracts;
using ConsentOrchestrator.Application.UseCases.Unsubscribe;
using ConsentOrchestrator.Application.UseCases.UpdateUserConsent;
using ConsentOrchestrator.Domain.Interfaces;
using ConsentOrchestrator.Infrastructure;
using ConsentOrchestrator.Infrastructure.Cache;
using ConsentOrchestrator.Infrastructure.Http;
using ConsentOrchestrator.Infrastructure.Messaging.ServiceBus;
using ConsentOrchestrator.Infrastructure.Security;
using Microsoft.Extensions.Http.Resilience;

namespace ConsentOrchestrator.API.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddConsentOrchestrator(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        // ── Cache ──────────────────────────────────────────────────────
        services.AddMemoryCache();
        services.AddScoped<IPurposeCacheService, PurposeCacheService>();

        // ── Use Cases ─────────────────────────────────────────────────
        services.AddScoped<UpdateUserConsentHandler>();
        services.AddScoped<UnsubscribeHandler>();

        // ── Domain Services ───────────────────────────────────────────
        var frontendBaseUri = configuration["Frontend:BaseUri"]
            ?? throw new InvalidOperationException("Frontend:BaseUri is required");

        var unsubscribeHmacSecret = configuration["Unsubscribe:HmacSecret"]
            ?? throw new InvalidOperationException("Unsubscribe:HmacSecret is required");
        services.AddSingleton<IHmacTokenGenerator>(_ => new HmacToken(unsubscribeHmacSecret));

        services.AddSingleton<IUnsubscribeLinkGenerator>(sp =>
            new UnsubscribeLinkGenerator(frontendBaseUri, sp.GetRequiredService<IHmacTokenGenerator>()));

        // ── Http Client : OnetrustAdapter with Polly (3 retries) ──────
        services.AddHttpClient<IOnetrustAdapterClient, OnetrustAdapterClient>(client =>
        {
            client.BaseAddress = new Uri(
                configuration["OnetrustAdapter:BaseUri"]
                ?? throw new InvalidOperationException("OnetrustAdapter:BaseUri is required"));

            client.Timeout = TimeSpan.FromSeconds(30);
        })
        .AddResilienceHandler("onetrust-retry", builder =>
        {
            // Polly v8 via Microsoft.Extensions.Http.Resilience
            builder.AddRetry(new HttpRetryStrategyOptions
            {
                MaxRetryAttempts = 3,
                Delay             = TimeSpan.FromMilliseconds(500),
                BackoffType       = DelayBackoffType.Exponential,
                ShouldHandle      = args => ValueTask.FromResult(
                    args.Outcome.Exception is not null ||
                    (int)(args.Outcome.Result?.StatusCode ?? 0) >= 500)
            });

            builder.AddTimeout(TimeSpan.FromSeconds(10));
        });

        // ── Service Bus ───────────────────────────────────────────────
        var serviceBusConnection = configuration["ServiceBus:ConnectionString"]
            ?? throw new InvalidOperationException("ServiceBus:ConnectionString is required");

        services.AddSingleton(_ => new ServiceBusClient(serviceBusConnection));
        services.AddSingleton(_ => new ServiceBusTopicOptions(
            configuration["ServiceBus:ConsentUpdatedTopic"] ?? "consent.updated",
            configuration["ServiceBus:UnsubscribeGeneratedTopic"] ?? "unsubscribelink.generated"));
        services.AddScoped<IEventBus, ServiceBusEventBus>();

        return services;
    }
}
