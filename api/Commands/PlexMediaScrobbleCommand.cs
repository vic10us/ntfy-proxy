using api.Features.PlexWebhooks.Models;
using MediatR;

namespace api.Commands;

public class PlexMediaScrobbleCommand : IRequest
{
    public PlexMediaScrobbleCommand(PlexWebhookEvent plexWebhookEvent)
    {
        PlexWebhookEvent = plexWebhookEvent;
    }

    public PlexWebhookEvent PlexWebhookEvent { get; set; }
}
