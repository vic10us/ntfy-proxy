namespace api.Features.Ntfy;

public class NtfyOptions
{
    public const string ConfigurationSection = "Ntfy";

    public string ServerUrl { get; set; } = string.Empty;
    public string ApiKey { get; set; } = string.Empty;
    public Dictionary<string, string[]> Notifications { get; set; } = new();
}
