using api.Features.PlexWebhooks.Models;
using MediatR;

namespace api.Commands;

public class PlexAdminDatabaseBackupCommand : IRequest
{
    public PlexAdminDatabaseBackupCommand(PlexWebhookEvent plexWebhookEvent)
    {
        PlexWebhookEvent = plexWebhookEvent;
    }

    public PlexWebhookEvent PlexWebhookEvent { get; set; }
}
