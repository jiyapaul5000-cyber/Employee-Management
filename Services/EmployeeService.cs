using EmployeeAPI.Data;
using EmployeeAPI.Models;
using EmployeeAPI.DTOs;
using Microsoft.EntityFrameworkCore;

namespace EmployeeAPI.Services;

public class EmployeeService
{
    private readonly AppDbContext _db;

    public EmployeeService(AppDbContext db)
    {
        _db = db;
    }
    public async Task<List<EmployeeDto>> GetEmployees(
    string? search,
    double? minSalary,
    bool descending,
    int page,
    int pageSize)
{
    var query = _db.Employees.AsQueryable();

    if (!string.IsNullOrWhiteSpace(search))
    {
        query = query.Where(e => e.Name.Contains(search));
    }

    if (minSalary.HasValue)
    {
        query = query.Where(e => e.Salary >= minSalary.Value);
    }


    query = descending
        ? query.OrderByDescending(e => e.Salary)
        : query.OrderBy(e => e.Salary);
    query = query
    .Skip((page - 1) * pageSize)
    .Take(pageSize);

    var employees = await query.ToListAsync();

    return employees.Select(ToDto).ToList();
}

    public async Task<EmployeeDto?> GetEmployee(int id)
{
       var employee = await _db.Employees.FindAsync(id);

       if (employee == null)
    {
        return null;
    }

       return ToDto(employee);
}

    public async Task<EmployeeDto> CreateEmployee(CreateEmployeeDto dto)
    {
        var employee = new Employee
        {   Id = dto.Id,
            Name = dto.Name,
            Salary = dto.Salary
        };

        _db.Employees.Add(employee);

        await _db.SaveChangesAsync();

        return ToDto(employee);
    }

    public async Task<EmployeeDto?> UpdateEmployee(
        int id,
        UpdateEmployeeDto dto)
    {
        var employee = await _db.Employees.FindAsync(id);

        if (employee == null)
        {
            return null;
        }

        employee.Name = dto.Name;
        employee.Salary = dto.Salary;

        await _db.SaveChangesAsync();

        return ToDto(employee);
    }

    public async Task<bool> DeleteEmployee(int id)
    {
        var employee = await _db.Employees.FindAsync(id);

        if (employee == null)
        {
            return false;
        }

        _db.Employees.Remove(employee);

        await _db.SaveChangesAsync();

        return true;
    }

    private EmployeeDto ToDto(Employee employee)
    {
        return new EmployeeDto
        {
            Id = employee.Id,
            Name = employee.Name,
            Salary = employee.Salary
        };
    }
}