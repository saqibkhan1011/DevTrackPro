using DevTrackPro.Services;
using Microsoft.AspNetCore.Mvc;

namespace DevTrackPro.Controllers;

[ApiController]
[Route("api/[controller]")]
public class EmployeesController : ControllerBase
{
    private readonly IEmployeeService _employeeService;

    // The DI container automatically supplies IEmployeeService here
    public EmployeesController(IEmployeeService employeeService)
    {
        _employeeService = employeeService;
    }

    [HttpGet]
    public IActionResult GetEmployees()
    {
        var employees = _employeeService.GetAllEmployees();
        return Ok(employees);
    }
}