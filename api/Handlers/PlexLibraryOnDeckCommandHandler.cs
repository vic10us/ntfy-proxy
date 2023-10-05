using api.Commands;
using api.Features.Ntfy;
using MediatR;

namespace api.Handlers;

public class PlexLibraryOnDeckCommandHandler : IRequestHandler<PlexLibraryNewCommand>
{
    private readonly INtfyClient _ntfyClient;

    public PlexLibraryOnDeckCommandHandler(INtfyClient ntfyClient)
    {
        _ntfyClient = ntfyClient;
    }

    public async Task Handle(PlexLibraryNewCommand request, CancellationToken cancellationToken)
    {
        var metadata = request.PlexWebhookEvent.Metadata!;
        var account = request.PlexWebhookEvent.Account!;
        var contentString = metadata.LibrarySectionType.ToLowerInvariant() switch
        {
            "movie"  => @$"{account.title} added {metadata.GrandparentTitle} {metadata.Title} to {metadata.LibrarySectionTitle}",
            "show"   => @$"{account.title} added {metadata.GrandparentTitle} S{metadata.ParentIndex}E{metadata.Index} {metadata.Title} to {metadata.LibrarySectionTitle}",
            "artist" => @$"{account.title} added {metadata.GrandparentTitle} {metadata.Title} to {metadata.LibrarySectionTitle}",
            "album"  => @$"{account.title} added {metadata.GrandparentTitle} {metadata.Title} to {metadata.LibrarySectionTitle}",
            "track"  => @$"{account.title} added {metadata.GrandparentTitle} {metadata.Title} to {metadata.LibrarySectionTitle}",
            _ => string.Empty
        };

        if (string.IsNullOrEmpty(contentString)) return;

        var title = $"{account.title} added a {metadata.LibrarySectionType}";
        await _ntfyClient.SendAsync("plex_library_on_deck", contentString, title, cancellationToken);
    }
}