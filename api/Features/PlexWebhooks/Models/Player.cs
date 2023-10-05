namespace api.Features.PlexWebhooks.Models;

public class Player
{
    public bool local { get; set; }
    public string publicAddress { get; set; }
    public string title { get; set; }
    public string uuid { get; set; }
}
