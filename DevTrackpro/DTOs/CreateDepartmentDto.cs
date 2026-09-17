using System.ComponentModel.DataAnnotations;

namespace DevTrackPro.DTOs;

public class CreateDepartmentDto
{
    [Required(ErrorMessage = "Department name is required.")]
    [StringLength(100, MinimumLength = 2, ErrorMessage = "Department name must be between 2 and 100 characters.")]
    public string Name { get; set; } = string.Empty;
}