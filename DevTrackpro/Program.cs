var builder = WebApplication.CreateBuilder(args);

// Add support for Controllers to the application
builder.Services.AddControllers();

var app = builder.Build();

// Map incoming HTTP requests to our Controllers
app.MapControllers();

app.Run();