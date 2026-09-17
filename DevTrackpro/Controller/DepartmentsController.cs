using DevTrackPro.DTOs;
using DevTrackPro.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DevTrackPro.Controllers;

[Authorize] // Requires a valid JWT for ALL endpoints in this controller
[ApiController]
[Route("api/[controller]")] // Automatically routes to /api/departments
public class DepartmentsController : ControllerBase
{
    private readonly IDepartmentService _departmentService;

    // Inject the service via Dependency Injection
    public DepartmentsController(IDepartmentService departmentService)
    {
        _departmentService = departmentService;
    }

    // GET: /api/departments
    [HttpGet]
    public async Task<IActionResult> GetDepartments()
    {
        var departments = await _departmentService.GetAllDepartmentsAsync();
        return Ok(departments); // Returns HTTP 200 OK
    }

    // POST: /api/departments
    [HttpPost]
    [Authorize(Roles = "Admin")] // Only Admins can create departments
    public async Task<IActionResult> CreateDepartment([FromBody] CreateDepartmentDto dto)
    {
        var createdDepartment = await _departmentService.CreateDepartmentAsync(dto);
        
        // Returns HTTP 201 Created (the REST standard for resource creation)
        return StatusCode(201, createdDepartment); 
    }
}