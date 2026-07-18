public static class BuilderConfig
{
    public static WebApplication AddBuilderConfig(this WebApplicationBuilder builder)
    {
        // Controllers
        builder.AddApiConfig();
        // DbContext
        builder.AddDbContextConfig();
        // Dependency Injection (Repository and Service)
        builder.AddDiConfig();
        // OpenAPI
        builder.AddOpenApi();

        return builder.Build();
    }
}