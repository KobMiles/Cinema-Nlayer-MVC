namespace Cinema.BLL.External.TmDb;

public class TmDbOptions
{
    public const string SectionName = "Tmdb";

    public required string ApiKey { get; init; }

    public string BaseUrl { get; init; } = "https://api.themoviedb.org/3/";
    public string ImageBaseUrl { get; init; } = "https://image.tmdb.org/t/p/";
    public string Language { get; init; } = "en-US";
    public string PosterSize { get; init; } = "w500";
    public string YoutubeBase { get; init; } = "https://www.youtube.com/embed/";
}