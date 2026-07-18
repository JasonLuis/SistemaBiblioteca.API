public static class OpenApiConfig
{
    public static WebApplicationBuilder AddOpenApi(this WebApplicationBuilder builder)
    {
        builder.Services.AddOpenApi();
        
        return builder;
    }
}