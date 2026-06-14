using ConsentOrchestrator.API.Middlewares;
using ConsentOrchestrator.Application.DTOs.Requests;
using ConsentOrchestrator.Application.DTOs.Responses;
using ConsentOrchestrator.Application.Mappers;
using ConsentOrchestrator.Application.UseCases.UpdateUserConsent;
using Microsoft.AspNetCore.Mvc;

namespace ConsentOrchestrator.API.Controllers;

[ApiController]
[Route("api/consent/user")]
public class ConsentController(
    UpdateUserConsentHandler handler,
    ILogger<ConsentController> logger) : ControllerBase
{
    /// <summary>
    /// Update user consents for a given collection point.
    /// </summary>
    [HttpPost("{userId:guid}/{collectionPointId:guid}")]
    [ProducesResponseType(typeof(UpdateUserConsentResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status502BadGateway)]
    public async Task<IActionResult> UpdateUserConsent(
        [FromRoute] Guid userId,
        [FromRoute] Guid collectionPointId,
        [FromBody] UpdateUserConsentRequest request,
        CancellationToken ct)
    {
        var correlationId = HttpContext.Items[CorrelationIdMiddleware.HeaderName]?.ToString()
            ?? Guid.NewGuid().ToString();

        logger.LogInformation(
            "[{CorrelationId}] POST api/consent/user/{UserId}/{CollectionPointId}",
            correlationId, userId, collectionPointId);

        var command = ConsentMapper.ToCommand(userId, collectionPointId, request, correlationId);

        var result = await handler.HandleAsync(command, ct);

        var response = ConsentMapper.ToResponse(command.UserId, command.CollectionPointId, result.UnsubscribeLinks);

        return Ok(response);
    }
}
