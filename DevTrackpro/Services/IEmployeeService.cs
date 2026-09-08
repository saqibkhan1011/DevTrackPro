using DevTrackPro.DTOs;

namespace DevTrackPro.Services;

public interface IEmployeeService
{
    Task<IEnumerable<EmployeeDto>> GetAllEmployeesAsync();
    Task<EmployeeDto?> GetEmployeeByIdAsync(int id);
    Task<EmployeeDto> CreateEmployeeAsync(CreateEmployeeDto dto);
    Task<bool> UpdateEmployeeAsync(int id, UpdateEmployeeDto dto);
    Task<bool> DeleteEmployeeAsync(int id);
}