using api.Features.PlexWebhooks.Models;
using MediatR;

namespace api.Commands;

public class PlexDeviceNewCommand : IRequest
{
    public PlexDeviceNewCommand(PlexWebhookEvent plexWebhookEvent)
    {
        PlexWebhookEvent = plexWebhookEvent;
    }

    public PlexWebhookEvent PlexWebhookEvent { get; set; }
}
