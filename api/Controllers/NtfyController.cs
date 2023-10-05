using api.Commands;
using api.Features.PlexWebhooks.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace api.Controllers;

[ApiController]
[Route("ntfy")]
public class NtfyController : ControllerBase
{
    private readonly ILogger<NtfyController> _logger;
    private readonly IMediator _mediator;

    public NtfyController(ILogger<NtfyController> logger, IHttpClientFactory httpClientFactory, IMediator mediator)
    {
        _logger = logger;
        _mediator = mediator;
    }

    [HttpPost("plex", Name = "PlexWebhookEvent")]
    public IActionResult PlexWebhookEvent()
    {
        Request.Form.TryGetValue("payload", out var payloadString);
        
        // check if payload is null or empty
        if (string.IsNullOrEmpty(payloadString))
        {
            _logger.LogWarning("PlexWebhookEvent: payload is null or empty");
            return BadRequest();
        }
        var payload = JsonConvert.DeserializeObject<PlexWebhookEvent>(payloadString!);

        // check if payload is null
        if (payload is null)
        {
            _logger.LogWarning("PlexWebhookEvent: payload is null");
            return BadRequest();
        }
        _logger.LogInformation("PlexWebhookEvent: {Event}", payload.Event);
        _mediator.Send(new PlexWebhookEventCommand(payload));
        return Accepted();
    }
}
