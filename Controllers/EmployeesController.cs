using EmployeeAPI.Services;
using Microsoft.AspNetCore.Mvc;
using EmployeeAPI.DTOs;
using Microsoft.AspNetCore.Authorization;

namespace EmployeeAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class EmployeesController : ControllerBase
{
    private readonly EmployeeService _employeeService;

    public EmployeesController(EmployeeService employeeService)
    {
        _employeeService = employeeService;
    }

[HttpGet]
   public async Task<IActionResult> GetEmployees(
string? search,
double? minSalary,
bool descending = false,
int page = 1,
int pageSize = 10)
{
    var employees = await _employeeService.GetEmployees(search, minSalary, descending,page,
    pageSize);
    return Ok(employees);
}


   [HttpGet("{id}")]
   public async Task<IActionResult> GetEmployee(int id)
{
      var employee = await _employeeService.GetEmployee(id);

      if (employee == null)
    {
        return NotFound();
    }

      return Ok(employee);
}

   [HttpPost]
   public async Task<IActionResult> CreateEmployee(CreateEmployeeDto dto)
{
      var createdEmployee = await _employeeService.CreateEmployee(dto);

      return CreatedAtAction(
      nameof(GetEmployee),
      new { id = createdEmployee.Id },
      createdEmployee);
}

   [HttpPut("{id}")]
   public async Task<IActionResult> UpdateEmployee(
    int id,
    UpdateEmployeeDto dto)
{
      var employee = await _employeeService.UpdateEmployee(id, dto);

      if (employee == null)
    {
        return NotFound();
    }

      return Ok(employee);
}

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteEmployee(int id)
{
       var deleted = await _employeeService.DeleteEmployee(id);

       if (!deleted)
    {
        return NotFound();
    }

    return NoContent();
}
}