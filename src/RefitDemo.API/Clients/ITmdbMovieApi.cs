using Refit;
using RefitDemo.API.DTOs.Responses;

namespace RefitDemo.API.Clients;

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