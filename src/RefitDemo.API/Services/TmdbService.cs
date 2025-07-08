using RefitDemo.API.Clients;
using RefitDemo.API.DTOs.Responses;
using RefitDemo.API.Services.Interfaces;

namespace RefitDemo.API.Services;

public class TmdbService(ITmdbMovieApi movieApi) : IMovieService
{
    public async Task<MovieDetailsResponse> GetMovieDetailsAsync(int movieId, string language)
    {
        return await movieApi.GetMovieDetailsAsync(movieId, language);
    }

    public async Task<MovieListResponse> GetTrendingMoviesAsync(string timeWindow, string language)
    {
        return await movieApi.GetTrendingMoviesAsync(timeWindow, language);
    }

    public async Task<MovieListResponse> SearchMoviesAsync(string query, string language, int pageNumber)
    {
        return await movieApi.SearchMoviesAsync(query, language, pageNumber);
    }
}