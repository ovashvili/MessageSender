using MessageSender.Api.Filters;
using MessageSender.Application.Common.Models;
using MessageSender.Application.Sms.Models;
using MessageSender.Application.Sms.Services;
using MessageSender.Domain.Enums;
using Microsoft.AspNetCore.Mvc;

namespace MessageSender.Api.Controllers;

/// <summary>
/// Controller for managing SMS-related operations.
/// </summary>
[ApiController]
[ApiVersion("1.0")]
[Route("api/v{version:apiVersion}/sms")]
[Produces("application/json")]
[ApiKeyAuthFilter]
public class SmsController : ControllerBase
{
    private readonly ISmsService _smsService;

    public SmsController(ISmsService smsService)
    {
        _smsService = smsService;
    }

    /// <summary>
    /// Sends an SMS.
    /// </summary>
    /// <param name="sendSmsDto">A request data for sending the SMS.</param>
    /// <param name="clientId">TThe UUID of the client requesting the SMS transmission.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <returns>A result object containing the ID of the sent message or an error message if the operation failed.</returns>
    [HttpPost("send")]
    [ProducesResponseType(typeof(Result<long>), 200)]
    public async Task<Result<long>> SendSmsAsync([FromBody] SendSmsDto sendSmsDto, [FromHeader(Name = "x-client-id")] Guid clientId, CancellationToken cancellationToken)
    {
        return await _smsService.SendAsync(sendSmsDto, clientId, cancellationToken);
    }

    /// <summary>
    /// Gets the status of an SMS by message ID.
    /// </summary>
    /// <param name="id">The ID of the SMS message to retrieve the status of.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <returns>A result object containing the status of the SMS message or an error message if the operation failed.</returns>
    [HttpGet("status/{id:long}")]
    [ProducesResponseType(typeof(Result<MessageDeliveryStatus?>), 200)]
    public async Task<Result<MessageDeliveryStatus?>> GetSmsStatusAsync(long id, CancellationToken cancellationToken)
    {
        return await _smsService.GetStatusAsync(id, cancellationToken);
    }
}