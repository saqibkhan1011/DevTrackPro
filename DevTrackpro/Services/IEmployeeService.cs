using DevTrackPro.DTOs;

namespace DevTrackPro.Services;

public interface IEmployeeService
{
    Task<IEnumerable<EmployeeDto>> GetAllEmployeesAsync();
}