namespace api.Features.PlexWebhooks.Models;

public class PlexWebhookEvent
{
    public required string Event { get; set; }
    public bool User { get; set; }
    public bool Owner { get; set; }
    public Account? Account { get; set; }
    public Server? Server { get; set; }
    public Player? Player { get; set; }
    public Metadata? Metadata { get; set; }
}
