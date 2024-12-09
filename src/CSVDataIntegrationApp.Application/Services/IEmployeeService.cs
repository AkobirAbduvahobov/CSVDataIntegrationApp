using CSVDataIntegrationApp.Application.DTOs;
using CSVDataIntegrationApp.Application.Models;

namespace CSVDataIntegrationApp.Application.Services;

public interface IEmployeeService
{
    Task<int> AddEmployeesAsync(Stream csvFileStream);

    Task<Guid> AddEmployeeAsync(CreateEmployeeDto createEmployeeDto);

    Task<List<EmployeeDto>> GetEmployeesAsync(EmployeeQueryModel employeeQueryModel);

    Task UpdateEmployeeAsync(EmployeeDto employeeDto);

    Task DeleteEmployeeByIdAsync(Guid employeeId);

    Task<EmployeeDto> GetEmployeeByIdAsync(Guid employeeId);
}