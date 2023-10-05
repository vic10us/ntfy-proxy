using api.Features.PlexWebhooks.Models;
using MediatR;

namespace api.Commands;

public class PlexAdminDatabaseCorruptCommand : IRequest
{
    public PlexAdminDatabaseCorruptCommand(PlexWebhookEvent plexWebhookEvent)
    {
        PlexWebhookEvent = plexWebhookEvent;
    }

    public PlexWebhookEvent PlexWebhookEvent { get; set; }
}
