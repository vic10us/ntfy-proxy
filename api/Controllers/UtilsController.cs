using api.Features.Discord;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers;

[ApiController]
[Route("utils")]
public class UtilsController : ControllerBase
{
    private readonly ILogger<UtilsController> _logger;

    public UtilsController(ILogger<UtilsController> logger)
    {
        _logger = logger;
    }

    [HttpGet("discord/snowflake/{snowflakeString}", Name = "DecodeDiscordSnowflake")]
    public IActionResult DecodeSnowflake(string snowflakeString)
    {
        // var discordSnowflake = new DiscordSnowflake();
        var (timestamp, workerId, datacenterId, sequence) = DiscordSnowflake.Decode(snowflakeString);
        return Ok(new
        {
            dateTime = DiscordSnowflake.ToDateTimeOffset(timestamp),
            timestamp = $"{timestamp}",
            workerId = $"{workerId}",
            datacenterId = $"{datacenterId}",
            sequence = $"{sequence}"
        });
    }
}
