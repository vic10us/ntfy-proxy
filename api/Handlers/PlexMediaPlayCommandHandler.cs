using api.Commands;
using api.Features.Ntfy;
using MediatR;

namespace api.Handlers;

public class PlexMediaPlayCommandHandler : IRequestHandler<PlexMediaPlayCommand>
{
    private readonly INtfyClient _ntfyClient;

    public PlexMediaPlayCommandHandler(INtfyClient ntfyClient)
    {
        _ntfyClient = ntfyClient;
    }

    public async Task Handle(PlexMediaPlayCommand request, CancellationToken cancellationToken)
    {
        var metadata = request.PlexWebhookEvent.Metadata!;
        var account = request.PlexWebhookEvent.Account!;
        var contentString = metadata.LibrarySectionType.ToLowerInvariant() switch
        {
            "movie" => @$"{account.title} started playing {metadata.GrandparentTitle} {metadata.Title}",
            "show" => @$"{account.title} started watching {metadata.GrandparentTitle} S{metadata.ParentIndex}E{metadata.Index} {metadata.Title}",
            "artist" => @$"{account.title} started listening to {metadata.GrandparentTitle} {metadata.Title}",
            "album" => @$"{account.title} started listening to {metadata.GrandparentTitle} {metadata.Title}",
            "track" => @$"{account.title} started listening to {metadata.GrandparentTitle} {metadata.Title}",
            _ => string.Empty
        };
        
        if (string.IsNullOrEmpty(contentString)) return;

        var title = $"{account.title} started a {metadata.LibrarySectionType}";
        await _ntfyClient.SendAsync("plex_media_play", contentString, title, cancellationToken);
    }
}
