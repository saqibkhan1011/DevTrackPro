using DevTrackPro.DTOs;

namespace DevTrackPro.Services;

public interface IDepartmentService
{
    Task<IEnumerable<DepartmentDto>> GetAllDepartmentsAsync();
    Task<DepartmentDto> CreateDepartmentAsync(CreateDepartmentDto dto);
}