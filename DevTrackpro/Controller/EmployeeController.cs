using DevTrackPro.DTOs;
using DevTrackPro.Services;
using Microsoft.AspNetCore.Mvc;

namespace DevTrackPro.Controllers;

[ApiController]
[Route("api/[controller]")]
public class EmployeesController : ControllerBase
{
    private readonly IEmployeeService _employeeService;

    public EmployeesController(IEmployeeService employeeService)
    {
        _employeeService = employeeService;
    }

    [HttpGet]
    public async Task<IActionResult> GetEmployees()
    {
        var employees = await _employeeService.GetAllEmployeesAsync();
        return Ok(employees);
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetEmployeeById(int id)
    {
        var employee = await _employeeService.GetEmployeeByIdAsync(id);
        if (employee == null) return NotFound();

        return Ok(employee);
    }

    [HttpPost]
    public async Task<IActionResult> CreateEmployee([FromBody] CreateEmployeeDto dto)
    {
        var createdEmployee = await _employeeService.CreateEmployeeAsync(dto);
        
        // Returns HTTP 201 Created with a Location header pointing to api/employees/{id}
        return CreatedAtAction(nameof(GetEmployeeById), new { id = createdEmployee.Id }, createdEmployee);
    }

    [HttpPut("{id:int}")]
    public async Task<IActionResult> UpdateEmployee(int id, [FromBody] UpdateEmployeeDto dto)
    {
        var updated = await _employeeService.UpdateEmployeeAsync(id, dto);
        if (!updated) return NotFound();

        return NoContent(); // HTTP 204
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> DeleteEmployee(int id)
    {
        var deleted = await _employeeService.DeleteEmployeeAsync(id);
        if (!deleted) return NotFound();

        return NoContent(); // HTTP 204
    }
}