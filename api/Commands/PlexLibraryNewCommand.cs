using api.Features.PlexWebhooks.Models;
using MediatR;

namespace api.Commands;

public class PlexLibraryNewCommand : IRequest
{
    public PlexLibraryNewCommand(PlexWebhookEvent plexWebhookEvent)
    {
        PlexWebhookEvent = plexWebhookEvent;
    }

    public PlexWebhookEvent PlexWebhookEvent { get; set; }
}
