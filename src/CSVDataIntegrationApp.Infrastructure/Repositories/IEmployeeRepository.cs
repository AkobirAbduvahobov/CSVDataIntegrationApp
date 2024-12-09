using CSVDataIntegrationApp.Domain.Entites;

namespace CSVDataIntegrationApp.Infrastructure.Repositories;

public interface IEmployeeRepository
{
    Task<int> InsertEmployeesAsync(IEnumerable<Employee> employees);

    Task<Guid> InsertEmployeeAsync(Employee employee);

    IQueryable<Employee> SelectEmployeesAsync();

    Task UpdateEmployeeAsync(Employee employee);

    Task RemoveEmployeesAsync(Guid id);

    Task<Employee> SelectEmployeeByIdAsync(Guid employeeId);
}