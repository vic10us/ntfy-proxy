namespace api.Features.PlexWebhooks.Models;

public class Role
{
    public int id { get; set; }
    public string filter { get; set; }
    public string tag { get; set; }
    public string tagKey { get; set; }
    public string role { get; set; }
    public string thumb { get; set; }
    public int count { get; set; }
}
