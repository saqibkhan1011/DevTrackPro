using System.ComponentModel.DataAnnotations;

namespace DevTrackPro.DTOs;

public class CreateEmployeeDto
{
    [Required(ErrorMessage = "Name is required.")]
    [MaxLength(100, ErrorMessage = "Name cannot exceed 100 characters.")]
    public string Name { get; set; } = string.Empty;

    [Required(ErrorMessage = "Role is required.")]
    [MaxLength(50, ErrorMessage = "Role cannot exceed 50 characters.")]
    public string Role { get; set; } = string.Empty;

    [Required(ErrorMessage = "Department ID is required.")]
    [Range(1, int.MaxValue, ErrorMessage = "DepartmentId must be greater than 0.")]
    public int DepartmentId { get; set; }
}