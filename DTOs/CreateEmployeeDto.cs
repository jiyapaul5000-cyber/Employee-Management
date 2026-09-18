using System.ComponentModel.DataAnnotations;

namespace EmployeeAPI.DTOs;

public class CreateEmployeeDto
{
    public int Id { get; set; }

    [Required]
    [StringLength(100, MinimumLength = 2)]
    public string Name { get; set; } = string.Empty;

    [Range(1, double.MaxValue)]
    public double Salary { get; set; }
}