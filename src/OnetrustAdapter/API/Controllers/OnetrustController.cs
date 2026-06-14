using Microsoft.AspNetCore.Mvc;
using OnetrustAdapter.Application.DTOs.Requests;
using OnetrustAdapter.Application.DTOs.Responses;
using OnetrustAdapter.Application.UseCases.GetPurposes;
using OnetrustAdapter.Application.UseCases.UpdateUserConsent;

namespace OnetrustAdapter.API.Controllers;

[ApiController]
[Route("api/onetrust")]
public class OnetrustController(
    GetPurposesHandler getPurposesHandler,
    UpdateUserConsentHandler updateHandler,
    ILogger<OnetrustController> logger) : ControllerBase
{
    [HttpGet("purposes/{collectionPointId:guid}")]
    [ProducesResponseType(typeof(IReadOnlyList<PurposeResponse>), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetPurposes(
        [FromRoute] Guid collectionPointId,
        CancellationToken ct)
    {
        var correlationId = Request.Headers["X-Correlation-Id"].FirstOrDefault() ?? Guid.NewGuid().ToString();
        logger.LogInformation("[{CorrelationId}] GET purposes for collectionPoint {CollectionPointId}", correlationId, collectionPointId);

        var purposes = await getPurposesHandler.HandleAsync(collectionPointId, ct);
        return Ok(purposes);
    }

    [HttpPost("users/{userId:guid}/consents")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status502BadGateway)]
    public async Task<IActionResult> UpdateUserConsents(
        [FromRoute] Guid userId,
        [FromBody] UpdateUserConsentRequest request,
        CancellationToken ct)
    {
        var correlationId = Request.Headers["X-Correlation-Id"].FirstOrDefault() ?? Guid.NewGuid().ToString();
        logger.LogInformation("[{CorrelationId}] POST update consents for user {UserId}", correlationId, userId);

        await updateHandler.HandleAsync(request, ct);
        return NoContent();
    }
}
