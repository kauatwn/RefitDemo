using Microsoft.Extensions.Options;
using Refit;
using System.Text.Json;
using RefitDemo.API.Clients;
using RefitDemo.API.Options;
using RefitDemo.API.Services;
using RefitDemo.API.Services.Interfaces;

namespace RefitDemo.API.Extensions;

public static class DependencyInjectionExtensions
{
    public static void AddApplicationDependencies(this IServiceCollection services, IConfiguration configuration)
    {
        AddOptionsConfiguration(services, configuration);
        AddTmdbClient(services);
        AddApplicationServices(services);
    }

    private static void AddOptionsConfiguration(IServiceCollection services, IConfiguration configuration)
    {
        services.Configure<TmdbOptions>(configuration.GetSection(TmdbOptions.SectionName));
    }

    private static void AddTmdbClient(IServiceCollection services)
    {
        services.AddRefitClient<ITmdbMovieApi>((provider) =>
        {
            var options = provider.GetRequiredService<IOptions<TmdbOptions>>();
            return new RefitSettings
            {
                AuthorizationHeaderValueGetter = (_, _) => Task.FromResult(options.Value.ReadAccessToken),
                ContentSerializer = new SystemTextJsonContentSerializer(new JsonSerializerOptions
                {
                    PropertyNamingPolicy = JsonNamingPolicy.SnakeCaseLower
                })
            };
        })
        .ConfigureHttpClient((_, client) =>
        {
            client.BaseAddress = new Uri(TmdbOptions.BaseUrl);
            client.Timeout = TimeSpan.FromSeconds(30);
        });
    }

    private static void AddApplicationServices(IServiceCollection services)
    {
        services.AddScoped<IMovieService, TmdbService>();
    }
}