using CSVDataIntegrationApp.Application.DTOs;
using CSVDataIntegrationApp.Application.Models;
using CSVDataIntegrationApp.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace CSVDataIntegrationApp.Server.Controllers;

[Route("api/employee")]
[ApiController]
public class EmployeeController : ControllerBase
{
    private readonly IEmployeeService _employeeService;

    public EmployeeController(IEmployeeService employeeService)
    {
        _employeeService = employeeService;
    }

    [HttpPost("add")]
    public async Task<Guid> AddEmployee(CreateEmployeeDto createEmployeeDto)
    {
        var id = await _employeeService.AddEmployeeAsync(createEmployeeDto);
        return id;
    }

    [HttpGet("getById")]
    public async Task<EmployeeDto> GetEmployeeById(Guid id)
    {
        return await _employeeService.GetEmployeeByIdAsync(id);
    }

    [HttpDelete("delete")]
    public async Task DeleteEmployee(Guid id)
    {
        await _employeeService.DeleteEmployeeByIdAsync(id);
    }

    [HttpPut("update")]
    public async Task UpdateEmployee(EmployeeDto employeeDto)
    {
        await _employeeService.UpdateEmployeeAsync(employeeDto);
    }

    [HttpPost("uploadCSV")]
    public async Task<int> AddEmployees(IFormFile file)
    {
        if (file is null || file.Length == 0)
        {
            throw new ArgumentNullException(nameof(file));
        }

        await using var stream = file.OpenReadStream();
        var addedCount = await _employeeService.AddEmployeesAsync(stream);

        return addedCount;
    }

    [HttpGet("getAll")]
    public async Task<List<EmployeeDto>> GetAll([FromQuery] EmployeeQueryModel employeeQueryModel)
    {
        var res = await _employeeService.GetEmployeesAsync(employeeQueryModel);
        return res;
    }
}
