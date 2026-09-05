using DevTrackPro.DTOs;

namespace DevTrackPro.Services;

public interface IEmployeeService
{
    IEnumerable<EmployeeDto> GetAllEmployees();
}