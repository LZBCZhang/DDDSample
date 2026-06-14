using Microsoft.Extensions.Http.Resilience;
using OnetrustAdapter.Application.Contracts;
using OnetrustAdapter.Application.UseCases.GetPurposes;
using OnetrustAdapter.Application.UseCases.UpdateUserConsent;
using OnetrustAdapter.Infrastructure.Cache;
using OnetrustAdapter.Infrastructure.Http;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddOpenApi();
builder.Services.AddMemoryCache();

builder.Services.AddScoped<IPurposeCacheService, PurposeCacheService>();
builder.Services.AddScoped<GetPurposesHandler>();
builder.Services.AddScoped<UpdateUserConsentHandler>();

builder.Services.AddHttpClient<IOnetrustApiClient, OnetrustApiClient>(client =>
{
    client.BaseAddress = new Uri(
        builder.Configuration["OneTrust:BaseUri"]
        ?? throw new InvalidOperationException("OneTrust:BaseUri is required"));
})
.AddResilienceHandler("onetrust-retry", b =>
{
    b.AddRetry(new HttpRetryStrategyOptions
    {
        MaxRetryAttempts = 3,
        Delay             = TimeSpan.FromMilliseconds(300),
        BackoffType       = DelayBackoffType.Exponential
    });
    b.AddTimeout(TimeSpan.FromSeconds(15));
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
    app.MapOpenApi();

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();
