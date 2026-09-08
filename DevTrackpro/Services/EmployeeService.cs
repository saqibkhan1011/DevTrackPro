using DevTrackPro.Data;
using DevTrackPro.DTOs;
using DevTrackPro.Entities;
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

    public async Task<EmployeeDto?> GetEmployeeByIdAsync(int id)
    {
        var employee = await _context.Employees.FindAsync(id);
        if (employee == null) return null;

        return new EmployeeDto
        {
            Id = employee.Id,
            Name = employee.Name,
            Role = employee.Role
        };
    }

    public async Task<EmployeeDto> CreateEmployeeAsync(CreateEmployeeDto dto)
    {
        var employee = new Employee
        {
            Name = dto.Name,
            Role = dto.Role,
            DepartmentId = dto.DepartmentId
        };

        _context.Employees.Add(employee);
        await _context.SaveChangesAsync();

        return new EmployeeDto
        {
            Id = employee.Id,
            Name = employee.Name,
            Role = employee.Role
        };
    }

    public async Task<bool> UpdateEmployeeAsync(int id, UpdateEmployeeDto dto)
    {
        var employee = await _context.Employees.FindAsync(id);
        if (employee == null) return false;

        employee.Name = dto.Name;
        employee.Role = dto.Role;
        employee.DepartmentId = dto.DepartmentId;

        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<bool> DeleteEmployeeAsync(int id)
    {
        var employee = await _context.Employees.FindAsync(id);
        if (employee == null) return false;

        _context.Employees.Remove(employee);
        await _context.SaveChangesAsync();
        return true;
    }
}