using Microsoft.AspNetCore.Mvc;
using Refit_Demo.API.DTOs.Responses;
using Refit_Demo.API.Enums;
using Refit_Demo.API.Services.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace Refit_Demo.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class MoviesController(IMovieService movieService) : ControllerBase
{
    [HttpGet("{movieId:int}")]
    [ProducesResponseType<MovieDetailsResponse>(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<MovieDetailsResponse>> GetMovieDetails(int movieId,
        [FromQuery] string language = "en-US")
    {
        try
        {
            return Ok(await movieService.GetMovieDetailsAsync(movieId, language));
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, new
            {
                Message = "Erro ao buscar detalhes do filme",
                Error = ex.Message
            });
        }
    }

    [HttpGet("trending/{timeWindow}")]
    [ProducesResponseType<MovieListResponse>(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<MovieListResponse>> GetTrendingMovies(TimeWindow timeWindow = TimeWindow.Day,
        [FromQuery] string language = "en-US")
    {
        try
        {
            return Ok(await movieService.GetTrendingMoviesAsync(timeWindow.ToString().ToLower(), language));
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, new
            {
                Message = "Erro ao buscar filmes em tendência",
                Error = ex.Message
            });
        }
    }

    [HttpGet("search")]
    [ProducesResponseType<MovieListResponse>(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<MovieListResponse>> SearchMovies([FromQuery] [Required] string query,
        [FromQuery] string language = "en-US", [FromQuery] int page = 1)
    {
        try
        {
            return Ok(await movieService.SearchMoviesAsync(query, language, page));
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, new
            {
                Message = "Erro ao buscar filmes",
                Error = ex.Message
            });
        }
    }
}