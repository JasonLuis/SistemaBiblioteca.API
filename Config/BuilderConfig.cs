public static class BuilderConfig
{
    public static WebApplication AddBuilderConfig(this WebApplicationBuilder builder)
    {
        // Controllers
        builder.AddApiConfig();
        // Cors
        builder.AddCorsConfig();
        // DbContext
        builder.AddDbContextConfig();
        // Dependency Injection (Repository and Service)
        builder.AddDiConfig();
        // Swagger
        builder.AddSwagger();

        return builder.Build();
    }
}