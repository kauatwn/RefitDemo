using Refit_Demo.API.DTOs.Responses;

namespace Refit_Demo.API.Services.Interfaces;

public interface IMovieService
{
    Task<MovieDetailsResponse> GetMovieDetailsAsync(int movieId, string language);
    Task<MovieListResponse> GetTrendingMoviesAsync(string timeWindow, string language);
    Task<MovieListResponse> SearchMoviesAsync(string query, string language, int page);
}