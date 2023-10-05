using api.Commands;
using api.Features.Ntfy;
using MediatR;

namespace api.Handlers;

public class PlexMediaStopCommandHandler : IRequestHandler<PlexMediaStopCommand>
{
    private readonly INtfyClient _ntfyClient;

    public PlexMediaStopCommandHandler(INtfyClient ntfyClient)
    {
        _ntfyClient = ntfyClient;
    }

    public async Task Handle(PlexMediaStopCommand request, CancellationToken cancellationToken)
    {
        var metadata = request.PlexWebhookEvent.Metadata!;
        var account = request.PlexWebhookEvent.Account!;

        var contentString = metadata.LibrarySectionType.ToLowerInvariant() switch
        {
            "movie" => @$"{account.title} stopped playing {metadata.GrandparentTitle} {metadata.Title}",
            "show" => @$"{account.title} stopped watching {metadata.GrandparentTitle} S{metadata.ParentIndex}E{metadata.Index} {metadata.Title}",
            "artist" => @$"{account.title} stopped listening to {metadata.GrandparentTitle} {metadata.Title}",
            "album" => @$"{account.title} stopped listening to {metadata.GrandparentTitle} {metadata.Title}",
            "track" => @$"{account.title} stopped listening to {metadata.GrandparentTitle} {metadata.Title}",
            _ => string.Empty
        };
        
        if (string.IsNullOrEmpty(contentString)) return;

        var title = $"{account.title} stopped a {metadata.LibrarySectionType}";
        await _ntfyClient.SendAsync("plex_media_stop", contentString, title, cancellationToken);
    }
}