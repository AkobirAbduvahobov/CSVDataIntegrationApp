using CSVDataIntegrationApp.Application.DTOs;
using CSVDataIntegrationApp.Application.Models;

namespace CSVDataIntegrationApp.Application.Services;

public interface IEmployeeService
{
    Task<int> AddEmployeesAsync(Stream csvFileStream);
    Task<List<EmployeeDto>> GetEmployeesAsync(EmployeeQueryModel employeeQueryModel);

}