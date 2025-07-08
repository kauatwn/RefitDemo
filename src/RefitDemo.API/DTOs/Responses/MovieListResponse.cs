namespace RefitDemo.API.DTOs.Responses;

public sealed record MovieListResponse(
    int Page,
    List<MovieListResponse.MovieSummary> Results,
    int TotalPages,
    int TotalResults)
{
    public sealed record MovieSummary(
        int Id,
        string? Title,
        string? OriginalTitle,
        string? Overview,
        string? ReleaseDate);
}