using DevTrackPro.DTOs;

namespace DevTrackPro.Services;

public class EmployeeService : IEmployeeService
{
    public IEnumerable<EmployeeDto> GetAllEmployees()
    {
        return new List<EmployeeDto>
        {
            new EmployeeDto { Id = 1, Name = "Saqib Khan", Role = "Software Engineer" },
            new EmployeeDto { Id = 2, Name = "Jane Doe", Role = "Project Manager" }
        };
    }
}