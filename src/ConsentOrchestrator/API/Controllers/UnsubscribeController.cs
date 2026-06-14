using ConsentOrchestrator.API.Middlewares;
using ConsentOrchestrator.Application.UseCases.Unsubscribe;
using Microsoft.AspNetCore.Mvc;

namespace ConsentOrchestrator.API.Controllers;

[ApiController]
[Route("api/consent/unsubscribe")]
public class UnsubscribeController(
    UnsubscribeHandler handler,
    ILogger<UnsubscribeController> logger) : ControllerBase
{
    /// <summary>
    /// One-click unsubscribe followed from a signed email link. The token carries
    /// (and authenticates) the user, collection point and purpose to withdraw.
    /// </summary>
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status502BadGateway)]
    public async Task<IActionResult> Unsubscribe([FromQuery] string token, CancellationToken ct)
    {
        var correlationId = HttpContext.Items[CorrelationIdMiddleware.HeaderName]?.ToString()
            ?? Guid.NewGuid().ToString();

        logger.LogInformation("[{CorrelationId}] GET api/consent/unsubscribe", correlationId);

        await handler.HandleAsync(new UnsubscribeCommand(token, correlationId), ct);

        return Ok(new { status = "UNSUBSCRIBED" });
    }
}