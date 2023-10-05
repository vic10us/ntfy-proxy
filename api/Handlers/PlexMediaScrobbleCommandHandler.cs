using api.Commands;
using api.Features.Ntfy;
using MediatR;

namespace api.Handlers;

public class PlexMediaScrobbleCommandHandler : IRequestHandler<PlexMediaScrobbleCommand>
{
    private readonly INtfyClient _ntfyClient;

    public PlexMediaScrobbleCommandHandler(INtfyClient ntfyClient)
    {
        _ntfyClient = ntfyClient;
    }

    public async Task Handle(PlexMediaScrobbleCommand request, CancellationToken cancellationToken)
    {
        var metadata = request.PlexWebhookEvent.Metadata!;
        var account = request.PlexWebhookEvent.Account!;
        var contentString = metadata.LibrarySectionType.ToLowerInvariant() switch
        {
            "movie"  => @$"{account.title} played {metadata.GrandparentTitle} {metadata.Title}",
            "show"   => @$"{account.title} watched {metadata.GrandparentTitle} S{metadata.ParentIndex}E{metadata.Index} {metadata.Title}",
            "artist" => @$"{account.title} listened to {metadata.GrandparentTitle} {metadata.Title}",
            "album"  => @$"{account.title} listened to {metadata.GrandparentTitle} {metadata.Title}",
            "track"  => @$"{account.title} listened to {metadata.GrandparentTitle} {metadata.Title}",
            _ => string.Empty
        };

        if (string.IsNullOrEmpty(contentString)) return;

        var title = $"{account.title} finished a {metadata.LibrarySectionType}";
        await _ntfyClient.SendAsync("plex_media_scrobble", contentString, title, cancellationToken);
    }
}