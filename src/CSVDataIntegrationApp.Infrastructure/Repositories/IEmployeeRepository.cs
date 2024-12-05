using CSVDataIntegrationApp.Domain.Entites;

namespace CSVDataIntegrationApp.Infrastructure.Repositories;

public interface IEmployeeRepository
{
    Task<int> AddEmployeesAsync(IEnumerable<Employee> employees);
    Task<IEnumerable<Employee>> GetEmployeesAsync();
}