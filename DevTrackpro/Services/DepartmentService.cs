using DevTrackPro.Data;
using DevTrackPro.DTOs;
using DevTrackPro.Entities;
using Microsoft.EntityFrameworkCore;

namespace DevTrackPro.Services;

public class DepartmentService : IDepartmentService
{
    private readonly DevTrackDbContext _context;

    // Inject the DbContext via the constructor
    public DepartmentService(DevTrackDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<DepartmentDto>> GetAllDepartmentsAsync()
    {
        // 1. Query the Departments table
        // 2. Map the Department Entity to a DepartmentDto
        // 3. Execute the query asynchronously and return a List
        return await _context.Departments
            .Select(d => new DepartmentDto
            {
                Id = d.Id,
                Name = d.Name
            })
            .ToListAsync();
    }

    public async Task<DepartmentDto> CreateDepartmentAsync(CreateDepartmentDto dto)
    {
        // 1. Map the incoming DTO to a new Database Entity
        var department = new Department
        {
            Name = dto.Name
        };

        // 2. Add it to EF Core's tracking and save to SQL Server
        _context.Departments.Add(department);
        await _context.SaveChangesAsync();

        // 3. Map the newly created Entity (which now has an SQL-generated Id) back to a DTO
        return new DepartmentDto
        {
            Id = department.Id,
            Name = department.Name
        };
    }
}