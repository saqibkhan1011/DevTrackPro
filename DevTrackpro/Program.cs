using DevTrackPro.Middleware;
using DevTrackPro.Services;
using System.Diagnostics;

var builder = WebApplication.CreateBuilder(args);

// Add support for Controllers to the application
builder.Services.AddControllers();
builder.Services.AddScoped<IEmployeeService, EmployeeService>();

var app = builder.Build();

app.UseMiddleware<RequestTimingMiddleware>();

// Map incoming HTTP requests to our Controllers
app.MapControllers();

app.Run();