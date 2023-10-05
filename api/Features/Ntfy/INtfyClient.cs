namespace api.Features.Ntfy;

public interface INtfyClient
{
    public Task SendAsync(string endpoint, string content, string title, CancellationToken cancellationToken);
}