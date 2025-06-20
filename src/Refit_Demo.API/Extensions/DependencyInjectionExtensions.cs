using Microsoft.Extensions.Options;
using Refit;
using Refit_Demo.API.Clients;
using Refit_Demo.API.Options;
using Refit_Demo.API.Services;
using Refit_Demo.API.Services.Interfaces;
using System.Text.Json;

namespace Refit_Demo.API.Extensions;

public static class DependencyInjectionExtensions
{
    public static void AddTmdbApi(this IServiceCollection services, IConfiguration configuration)
    {
        AddOptions(services, configuration);
        AddMovieClient(services);
    }

    public static void AddServices(this IServiceCollection services)
    {
        services.AddScoped<IMovieService, TmdbService>();
    }

    private static void AddOptions(IServiceCollection services, IConfiguration configuration)
    {
        services.Configure<TmdbOptions>(configuration.GetSection(TmdbOptions.SectionName));
    }

    private static void AddMovieClient(IServiceCollection services)
    {
        services.AddRefitClient<ITmdbMovieApi>(provider =>
        {
            var options = provider.GetRequiredService<IOptions<TmdbOptions>>();
            return new RefitSettings
            {
                AuthorizationHeaderValueGetter = (_, _) => Task.FromResult(options.Value.ReadAccessToken),
                ContentSerializer = new SystemTextJsonContentSerializer(new JsonSerializerOptions
                {
                    PropertyNamingPolicy = JsonNamingPolicy.SnakeCaseLower,
                })
            };
        })
        .ConfigureHttpClient((_, client) =>
        {
            client.BaseAddress = new Uri(TmdbOptions.BaseUrl);
            client.Timeout = TimeSpan.FromSeconds(30);
        });
    }
}