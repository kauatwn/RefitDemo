using Refit;
using Refit_Demo.API.DTOs.Responses;

namespace Refit_Demo.API.Clients;

[Headers("accept: application/json", "Authorization: Bearer")]
public interface ITmdbMovieApi
{
    [Get("/movie/{movieId}")]
    Task<MovieDetailsResponse> GetMovieDetailsAsync(int movieId, [Query] string language);

    [Get("/trending/movie/{timeWindow}")]
    Task<MovieListResponse> GetTrendingMoviesAsync(string timeWindow, [Query] string language);

    [Get("/search/movie")]
    Task<MovieListResponse> SearchMoviesAsync([Query] string query, [Query] string language, [Query] int page);
}