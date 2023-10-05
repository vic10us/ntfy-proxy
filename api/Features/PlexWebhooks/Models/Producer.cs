namespace api.Features.PlexWebhooks.Models;

public class Producer
{
    public int id { get; set; }
    public string filter { get; set; }
    public string tag { get; set; }
    public string tagKey { get; set; }
    public int count { get; set; }
}
