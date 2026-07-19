using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;

public static class IdentityConfig
{
    public static WebApplicationBuilder AddIdentityConfig(this WebApplicationBuilder builder)
    {
        builder.Services.AddIdentity<IdentityUser, IdentityRole>()
            .AddEntityFrameworkStores<AppDbContext>()
            .AddDefaultTokenProviders();

        // Pegando o Token e gerando a chave encodada
        var JwtSettingsSection = builder.Configuration.GetSection("JwtSettings"); // pega a seção do appsettings
        builder.Services.Configure<JwtSettings>(JwtSettingsSection); // registra a seção no contêiner de serviços

        var jwtSettings = JwtSettingsSection.Get<JwtSettings>(); // pega as configurações do JWT
        var key = System.Text.Encoding.ASCII.GetBytes(jwtSettings.Secret); // pega a chave secreta do JWT e codifica em bytes

        builder.Services.AddAuthentication(options =>
        {
            options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme; // define o esquema de autenticação padrão
            options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme; // define o esquema de desafio padrão
        }).AddJwtBearer(options =>
        {
            options.RequireHttpsMetadata = true; // requer HTTPS
            options.SaveToken = true; // salva o token
            options.TokenValidationParameters = new TokenValidationParameters
            {
              IssuerSigningKey = new SymmetricSecurityKey(key), // chave simetrica de segurança
              ValidateIssuer = true, // valida o emissor
              ValidateAudience = true, // valida o público
              ValidIssuer = jwtSettings.Issuer, // define o emissor válido
              ValidAudience = jwtSettings.Audience, // define o público válido
            };
        });

        return builder;
    }
}