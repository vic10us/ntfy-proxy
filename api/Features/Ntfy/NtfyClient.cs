namespace api.Features.Ntfy;

public class NtfyClient : INtfyClient
{
    private readonly HttpClient _httpClient;

    public NtfyClient(IHttpClientFactory httpClientFactory)
    {
        _httpClient = httpClientFactory.CreateClient("Ntfy");
    }

    public async Task SendAsync(string endpoint, string content, string title, CancellationToken cancellationToken)
    {
        var request = new HttpRequestMessage(HttpMethod.Post, endpoint);
        request.Headers.Add("X-Title", title);
        request.Content = new StringContent(content);
        await _httpClient.SendAsync(request, cancellationToken);
    }
}
