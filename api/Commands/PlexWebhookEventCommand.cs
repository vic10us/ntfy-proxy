using api.Features.PlexWebhooks.Models;
using MediatR;

namespace api.Commands;

public class PlexWebhookEventCommand : IRequest
{
    public PlexWebhookEventCommand(PlexWebhookEvent plexWebhookEvent)
    {
        PlexWebhookEvent = plexWebhookEvent;
    }

    public PlexWebhookEvent PlexWebhookEvent { get; set; }
}
