using Microsoft.EntityFrameworkCore;

public static class DbContextConfig
{
    public static WebApplicationBuilder AddDbContextConfig(this WebApplicationBuilder builder)
    {
        // DbContext
        builder.Services.AddDbContext<AppDbContext>(options => {    
            options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
        });

        return builder;
    }
}