namespace api.Features.Ntfy;

public class PlexWebhookEventType
{
    private PlexWebhookEventType(string value) { Value = value; }

    public string Value { get; set; }

    public static PlexWebhookEventType Play { get { return new PlexWebhookEventType("media.play"); } }
    public static PlexWebhookEventType Pause { get { return new PlexWebhookEventType("media.pause"); } }
    public static PlexWebhookEventType Resume { get { return new PlexWebhookEventType("media.resume"); } }
    public static PlexWebhookEventType Stop { get { return new PlexWebhookEventType("media.stop"); } }
    public static PlexWebhookEventType Scrobble { get { return new PlexWebhookEventType("media.scrobble"); } }
    public static PlexWebhookEventType Rate { get { return new PlexWebhookEventType("media.rate"); } }
    public static PlexWebhookEventType LibraryOnDeck { get { return new PlexWebhookEventType("library.on.deck"); } }
    public static PlexWebhookEventType LibraryNew { get { return new PlexWebhookEventType("library.new"); } }
    public static PlexWebhookEventType AdminDatabaseBackup { get { return new PlexWebhookEventType("admin.database.backup"); } }
    public static PlexWebhookEventType AdminDatabaseCorrupt { get { return new PlexWebhookEventType("admin.database.corrupt"); } }
    public static PlexWebhookEventType NewDevice { get { return new PlexWebhookEventType("device.new"); } }
    public static PlexWebhookEventType PlaybackStarted { get { return new PlexWebhookEventType("playback.started"); } }
}
