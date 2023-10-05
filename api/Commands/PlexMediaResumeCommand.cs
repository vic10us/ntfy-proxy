using api.Features.PlexWebhooks.Models;
using MediatR;

namespace api.Commands;

public class PlexMediaResumeCommand : IRequest
{
    public PlexMediaResumeCommand(PlexWebhookEvent plexWebhookEvent)
    {
        PlexWebhookEvent = plexWebhookEvent;
    }

    public PlexWebhookEvent PlexWebhookEvent { get; set; }
}
