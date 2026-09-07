namespace DevTrackPro.Entities;

public class Department
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;

    // Navigation Property: One department has many employees
    public ICollection<Employee> Employees { get; set; } = new List<Employee>();
}