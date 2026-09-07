using DevTrackPro.Middleware;
using DevTrackPro.Services;
using DevTrackPro.Data;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

var builder = WebApplication.CreateBuilder(args);

// Add support for Controllers to the application
builder.Services.AddControllers();
builder.Services.AddScoped<IEmployeeService, EmployeeService>();
builder.Services.AddDbContext<DevTrackDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();

app.UseMiddleware<RequestTimingMiddleware>();

// Map incoming HTTP requests to our Controllers
app.MapControllers();

app.Run();