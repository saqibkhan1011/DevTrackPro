using DevTrackPro.Data;
using DevTrackPro.DTOs;
using DevTrackPro.Entities;
using DevTrackPro.Services;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace DevTrackPro.Tests;

public class EmployeeServiceTests
{
    private DevTrackDbContext GetInMemoryDbContext()
    {
        // Creates a fresh in-memory database with a unique name for each test
        var options = new DbContextOptionsBuilder<DevTrackDbContext>()
            .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
            .Options;

        return new DevTrackDbContext(options);
    }

    [Fact]
    public async Task GetEmployeeByIdAsync_ReturnsEmployee_WhenEmployeeExists()
    {
        // ARRANGE
        using var context = GetInMemoryDbContext();
        context.Employees.Add(new Employee { Id = 10, Name = "Alice Smith", Role = "QA Engineer", DepartmentId = 1 });
        await context.SaveChangesAsync();

        var service = new EmployeeService(context);

        // ACT
        var result = await service.GetEmployeeByIdAsync(10);

        // ASSERT
        Assert.NotNull(result);
        Assert.Equal(10, result.Id);
        Assert.Equal("Alice Smith", result.Name);
        Assert.Equal("QA Engineer", result.Role);
    }

    [Fact]
    public async Task GetEmployeeByIdAsync_ReturnsNull_WhenEmployeeDoesNotExist()
    {
        // ARRANGE
        using var context = GetInMemoryDbContext();
        var service = new EmployeeService(context);

        // ACT
        var result = await service.GetEmployeeByIdAsync(999);

        // ASSERT
        Assert.Null(result);
    }

    [Fact]
    public async Task CreateEmployeeAsync_AddsEmployeeToDatabase()
    {
        // ARRANGE
        using var context = GetInMemoryDbContext();
        var service = new EmployeeService(context);
        var createDto = new CreateEmployeeDto
        {
            Name = "Bob Martin",
            Role = "DevOps Lead",
            DepartmentId = 1
        };

        // ACT
        var result = await service.CreateEmployeeAsync(createDto);

        // ASSERT
        Assert.NotNull(result);
        Assert.True(result.Id > 0);
        Assert.Equal("Bob Martin", result.Name);

        // Verify it was actually written to the DbContext
        var dbEmployee = await context.Employees.FindAsync(result.Id);
        Assert.NotNull(dbEmployee);
        Assert.Equal("Bob Martin", dbEmployee.Name);
    }
}