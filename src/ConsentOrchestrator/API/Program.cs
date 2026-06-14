using ConsentOrchestrator.API.Extensions;
using ConsentOrchestrator.API.Middlewares;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddOpenApi();
builder.Services.AddConsentOrchestrator(builder.Configuration);

var app = builder.Build();

app.UseMiddleware<CorrelationIdMiddleware>();
app.UseMiddleware<ExceptionMiddleware>();

if (app.Environment.IsDevelopment())
    app.MapOpenApi();

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();

// Exposed so the acceptance test project can bootstrap the API in-memory
// through WebApplicationFactory<Program>.
public partial class Program;
