using DevTrackPro.Data;
using DevTrackPro.DTOs;
using Microsoft.EntityFrameworkCore;

namespace DevTrackPro.Services;

public class EmployeeService : IEmployeeService
{
    private readonly DevTrackDbContext _context;

    public EmployeeService(DevTrackDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<EmployeeDto>> GetAllEmployeesAsync()
    {
        return await _context.Employees
            .Select(e => new EmployeeDto
            {
                Id = e.Id,
                Name = e.Name,
                Role = e.Role
            })
            .ToListAsync();
    }
}