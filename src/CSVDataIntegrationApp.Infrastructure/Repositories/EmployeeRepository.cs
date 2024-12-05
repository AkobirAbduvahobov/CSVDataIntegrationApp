using CSVDataIntegrationApp.Domain;
using CSVDataIntegrationApp.Domain.Entites;

namespace CSVDataIntegrationApp.Infrastructure.Repositories;

public class EmployeeRepository : IEmployeeRepository
{
    private readonly MainContext _mainContext;

    public EmployeeRepository(MainContext mainContext)
    {
        _mainContext = mainContext;
    }

    public async Task<int> AddEmployeesAsync(IEnumerable<Employee> employees)
    {
        await _mainContext.Employees.AddRangeAsync(employees);
        var resCount = await _mainContext.SaveChangesAsync();
        return resCount;
    }

    public Task<IEnumerable<Employee>> GetEmployeesAsync()
    {
        throw new NotImplementedException();
    }
}
