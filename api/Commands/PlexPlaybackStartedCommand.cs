using api.Features.PlexWebhooks.Models;
using MediatR;

namespace api.Commands;

public class PlexPlaybackStartedCommand : IRequest
{
    public PlexPlaybackStartedCommand(PlexWebhookEvent plexWebhookEvent)
    {
        PlexWebhookEvent = plexWebhookEvent;
    }

    public PlexWebhookEvent PlexWebhookEvent { get; set; }
}