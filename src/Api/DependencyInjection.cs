using RoadToApi.Middlewares;

namespace RoadToApi;

public static class DependencyInjection
{
    public static IServiceCollection AddPresentation(
        this IServiceCollection services,
        IConfiguration configuration,
        IWebHostEnvironment environment
    )
    {
        services.AddControllers();
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();
        services.AddTransient<GlobalExceptionHandlingMiddleware>();

        services.Configure<RouteOptions>(options =>
        {
            options.LowercaseUrls = true;
        });

        // services.AddBugsnag(config =>
        // {
        //     config.ApiKey = configuration["Integrations:Bugsnag:ApiKey"];
        //     config.ReleaseStage = environment.EnvironmentName;
        // });

        return services;
    }
}