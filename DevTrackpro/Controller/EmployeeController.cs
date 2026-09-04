using Microsoft.AspNetCore.Mvc;

namespace DevTrackPro.Controllers;

[ApiController]
[Route("api/[controller]")]
public class EmployeesController : ControllerBase
{
    [HttpGet]
    public IActionResult GetEmployees()
    {
        // Returning hardcoded data until we implement our database
        var employees = new[]
        {
            new { Id = 1, Name = "Saqib Khan", Role = "Software Engineer" },
            new { Id = 2, Name = "Jane Doe", Role = "Project Manager" }
        };

        return Ok(employees); // Returns an HTTP 200 with the data
    }
}