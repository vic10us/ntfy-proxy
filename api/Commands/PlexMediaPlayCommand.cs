using api.Features.PlexWebhooks.Models;
using MediatR;

namespace api.Commands;

public class PlexMediaPlayCommand : IRequest
{
    public PlexMediaPlayCommand(PlexWebhookEvent plexWebhookEvent)
    {
        PlexWebhookEvent = plexWebhookEvent;
    }

    public PlexWebhookEvent PlexWebhookEvent { get; set; }
}
