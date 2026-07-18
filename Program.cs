var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var app = builder.AddBuilderConfig();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();

    app.UseSwaggerUI(options =>
    {
        options.DocumentTitle = "Sistema Biblioteca API";
        options.SwaggerEndpoint("/swagger/v1/swagger.json", "Sistema Biblioteca API v1");
    });
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
