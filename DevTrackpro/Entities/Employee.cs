namespace DevTrackPro.Entities;

public class Employee
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Role { get; set; } = string.Empty;

    // Foreign Key
    public int DepartmentId { get; set; }

    // Navigation Property: An employee belongs to one department
    public Department? Department { get; set; }
}