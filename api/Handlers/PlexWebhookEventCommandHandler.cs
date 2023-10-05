using api.Commands;
using MediatR;

namespace api.Handlers;

public class PlexWebhookEventCommandHandler : IRequestHandler<PlexWebhookEventCommand>
{
    private readonly IMediator _mediator;

    public PlexWebhookEventCommandHandler(IMediator mediator)
    {
        _mediator = mediator;
    }

    public Task Handle(PlexWebhookEventCommand request, CancellationToken cancellationToken)
    {
        switch (request.PlexWebhookEvent.Event)
        {
            case "media.play":
                _mediator.Send(new PlexMediaPlayCommand(request.PlexWebhookEvent), cancellationToken);
                break;
            case "media.stop":
                _mediator.Send(new PlexMediaStopCommand(request.PlexWebhookEvent), cancellationToken);
                break;
            case "media.pause":
                _mediator.Send(new PlexMediaPauseCommand(request.PlexWebhookEvent), cancellationToken);
                break;
            case "media.resume":
                _mediator.Send(new PlexMediaResumeCommand(request.PlexWebhookEvent), cancellationToken);
                break;
            case "media.scrobble":
                _mediator.Send(new PlexMediaScrobbleCommand(request.PlexWebhookEvent), cancellationToken);
                break;
            case "media.rate":
                _mediator.Send(new PlexMediaRateCommand(request.PlexWebhookEvent), cancellationToken);
                break;
            case "library.on.deck":
                _mediator.Send(new PlexLibraryOnDeckCommand(request.PlexWebhookEvent), cancellationToken);
                break;
            case "library.new":
                _mediator.Send(new PlexLibraryNewCommand(request.PlexWebhookEvent), cancellationToken);
                break;
            case "admin.database.backup":
                _mediator.Send(new PlexAdminDatabaseBackupCommand(request.PlexWebhookEvent), cancellationToken);
                break;
            case "admin.database.corrupt":
                _mediator.Send(new PlexAdminDatabaseCorruptCommand(request.PlexWebhookEvent), cancellationToken);
                break;
            case "device.new":
                _mediator.Send(new PlexDeviceNewCommand(request.PlexWebhookEvent), cancellationToken);
                break;
            case "playback.started":
                _mediator.Send(new PlexPlaybackStartedCommand(request.PlexWebhookEvent), cancellationToken);
                break;
            default:
                break;
        }

        return Task.CompletedTask;
    }
}
