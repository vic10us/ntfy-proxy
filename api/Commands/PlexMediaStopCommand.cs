using api.Features.PlexWebhooks.Models;
using MediatR;

namespace api.Commands;

public class PlexMediaStopCommand : IRequest
{
    public PlexMediaStopCommand(PlexWebhookEvent plexWebhookEvent)
    {
        PlexWebhookEvent = plexWebhookEvent;
    }

    public PlexWebhookEvent PlexWebhookEvent { get; set; }
}
