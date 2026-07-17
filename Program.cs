using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
 
// DbContext
builder.Services.AddDbContext<AppDbContext>(options => {    
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});
// Repository
builder.Services.AddScoped<ILivroRepository, LivrosRepository>();
// Service
builder.Services.AddScoped<BibliotecaService>();

builder.Services.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwaggerUI(options =>
    {
        options.DocumentTitle = "Sistema Biblioteca API";
        options.SwaggerEndpoint("/openapi/v1.json", "v1");
    });
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
