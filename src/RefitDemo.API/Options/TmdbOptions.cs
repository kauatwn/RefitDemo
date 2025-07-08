namespace RefitDemo.API.Options;

public class TmdbOptions
{
    public const string SectionName = "Tmdb";
    public const string BaseUrl = "https://api.themoviedb.org/3";

    public string ReadAccessToken { get; init; } = string.Empty;
}