using api.Features.PlexWebhooks.Models;
using MediatR;

namespace api.Commands;

public class PlexLibraryOnDeckCommand : IRequest
{
    public PlexLibraryOnDeckCommand(PlexWebhookEvent plexWebhookEvent)
    {
        PlexWebhookEvent = plexWebhookEvent;
    }

    public PlexWebhookEvent PlexWebhookEvent { get; set; }
}
