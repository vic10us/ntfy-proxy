namespace api.Features.PlexWebhooks.Models;

public class Metadata
{
    public string LibrarySectionType { get; set; }
    public string RatingKey { get; set; }
    public string Key { get; set; }
    public string Studio { get; set; }
    public string Type { get; set; }
    public string Title { get; set; }
    public string LibrarySectionTitle { get; set; }
    public int LibrarySectionID { get; set; }
    public string LibrarySectionKey { get; set; }
    public string ContentRating { get; set; }
    public string Summary { get; set; }
    // public float Rating { get; set; }
    public float AudienceRating { get; set; }
    public int ViewOffset { get; set; }
    public int LastViewedAt { get; set; }
    public int Year { get; set; }
    public string Tagline { get; set; }
    public string Thumb { get; set; }
    public string Art { get; set; }
    public int Duration { get; set; }
    public string OriginallyAvailableAt { get; set; }
    public int AddedAt { get; set; }
    public int UpdatedAt { get; set; }
    public string AudienceRatingImage { get; set; }
    public string PrimaryExtraKey { get; set; }
    public string RatingImage { get; set; }
    public string ParentRatingKey { get; set; }
    public string GrandparentRatingKey { get; set; }
    public string ParentGuid { get; set; }
    public string GrandparentGuid { get; set; }
    public string GrandparentKey { get; set; }
    public string ParentKey { get; set; }
    public string GrandparentTitle { get; set; }
    public string ParentTitle { get; set; }
    public int Index { get; set; }
    public int ParentIndex { get; set; }
    public int ViewCount { get; set; }
    public string ParentThumb { get; set; }
    public string GrandparentThumb { get; set; }
    public string GrandparentArt { get; set; }
    public string GrandparentTheme { get; set; }
    //public Genre[]? Genre { get; set; }
    //public Country[]? Country { get; set; }
    //public Director[]? Director { get; set; }
    //public Writer[]? Writer { get; set; }
    //public Role[]? Role { get; set; }
    //public Producer[]? Producer { get; set; }
}
