namespace Lapka.ApiGateway.Swagger;

public static class SwaggerExtension
{
    public static IServiceCollection AddSwagger(this IServiceCollection services)
    {
        services.AddSwaggerGen();
        services.AddEndpointsApiExplorer();

        return services;
    }

    public static IApplicationBuilder UseSwaggerDocs(this IApplicationBuilder app, List<SwaggerEndpoint> endpoints)
    {
        return app
            .UseSwagger()
            .UseSwaggerUI(c =>
            {
                foreach (var e in endpoints)
                {
                    c.SwaggerEndpoint(e.GetFullUrl(), e.GetFullName());
                }
            });
    }
}