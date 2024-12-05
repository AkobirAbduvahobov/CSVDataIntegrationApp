using CSVDataIntegrationApp.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace CSVDataIntegrationApp.Server.Controllers;

[Route("api/[controller]")]
[ApiController]
public class EmployeeController : ControllerBase
{
    private readonly IEmployeeService _employeeService;

    public EmployeeController(IEmployeeService employeeService)
    {
        _employeeService = employeeService;
    }

    [HttpPost("upload")]
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
}
