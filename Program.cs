using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using SolidBlogsApi.Data;
using SolidBlogsApi.Repositories;
using SolidBlogsApi.Services;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

// Configure Swagger
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Solid Blogs API",
        Version = "v1",
        Description = "A RESTful API for managing blog posts using SOLID principles",
        Contact = new OpenApiContact
        {
            Name = "Your Name",
            Email = "your.email@example.com"
        }
    });
    
    // Enable XML comments
    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    c.IncludeXmlComments(xmlPath);
});

// Database configuration
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("DefaultConnection"),
        sqlOptions => sqlOptions.EnableRetryOnFailure()
    )
);

// SOLID Dependency Injection
builder.Services.AddScoped<IBlogsRepository, BlogsRepository>();
builder.Services.AddScoped<IBlogsService, BlogsService>();

// JSON configuration for handling the Tags collection
builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.PropertyNamingPolicy = System.Text.Json.JsonNamingPolicy.CamelCase;
    });

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Solid Blogs API v1");
        c.RoutePrefix = string.Empty; // Set Swagger UI at the app's root
    });
    
    // Create the database if it doesn't exist (Development only)
    using (var scope = app.Services.CreateScope())
    {
        var services = scope.ServiceProvider;
        var context = services.GetRequiredService<AppDbContext>();
        context.Database.EnsureCreated();
    }
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();
