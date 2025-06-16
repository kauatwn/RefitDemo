namespace Refit_Demo.API.DTOs.Responses;

public sealed record MovieDetailsResponse(
    int Id,
    string? Title,
    string? OriginalTitle,
    string? Overview,
    string? ReleaseDate,
    List<MovieDetailsResponse.Genre> Genres)
{
    public sealed record Genre(int Id, string? Name);
}