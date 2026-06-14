using ConsentOrchestrator.Domain.Exceptions;
using System.Net;
using System.Text.Json;

namespace ConsentOrchestrator.API.Middlewares;

public class ExceptionMiddleware(RequestDelegate next, ILogger<ExceptionMiddleware> logger)
{
    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await next(context);
        }
        catch (InvalidConsentException ex)
        {
            logger.LogWarning(ex, "Invalid consent");
            await WriteErrorAsync(context, HttpStatusCode.BadRequest, ex.Message);
        }
        catch (UnknownPurposeException ex)
        {
            logger.LogWarning(ex, "Unknown purpose");
            await WriteErrorAsync(context, HttpStatusCode.BadRequest, ex.Message);
        }
        catch (ConsentUpdateException ex)
        {
            logger.LogError(ex, "Consent update failed");
            await WriteErrorAsync(context, HttpStatusCode.BadGateway, ex.Message);
        }
        catch (PurposesNotFoundException ex)
        {
            logger.LogError(ex, "Purposes not found");
            await WriteErrorAsync(context, HttpStatusCode.NotFound, ex.Message);
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Unexpected error");
            await WriteErrorAsync(context, HttpStatusCode.InternalServerError, "An unexpected error occurred");
        }
    }

    private static async Task WriteErrorAsync(HttpContext context, HttpStatusCode status, string message)
    {
        context.Response.StatusCode  = (int)status;
        context.Response.ContentType = "application/json";
        await context.Response.WriteAsync(JsonSerializer.Serialize(new { error = message }));
    }
}
