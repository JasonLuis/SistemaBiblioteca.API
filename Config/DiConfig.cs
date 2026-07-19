public static class DiConfig
{
    public static WebApplicationBuilder AddDiConfig(this WebApplicationBuilder builder)
    {
        // Repository
        builder.Services.AddScoped<ILivroRepository, LivrosRepository>();
        // Service
        builder.Services.AddScoped<BibliotecaService>();
        builder.Services.AddScoped<AuthService>();
        return builder;
    }
}