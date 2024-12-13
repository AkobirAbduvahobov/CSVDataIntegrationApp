using CSVDataIntegrationApp.Core.Errors;
using CSVDataIntegrationApp.Domain;
using CSVDataIntegrationApp.Domain.Entites;
using Microsoft.EntityFrameworkCore;

namespace CSVDataIntegrationApp.Infrastructure.Repositories;

public class EmployeeRepository : IEmployeeRepository
{
    private readonly MainContext _mainContext;

    public EmployeeRepository(MainContext mainContext)
    {
        _mainContext = mainContext;
    }

    public async Task<int> InsertEmployeesAsync(IEnumerable<Employee> employees)
    {
        await _mainContext.Employees.AddRangeAsync(employees);
        var resCount = await _mainContext.SaveChangesAsync();
        return resCount;
    }

    public IQueryable<Employee> SelectEmployeesAsync()
    {
        return _mainContext.Employees.AsQueryable();
    }

    public async Task<Guid> InsertEmployeeAsync(Employee employee)
    {
        await _mainContext.Employees.AddAsync(employee);
        await _mainContext.SaveChangesAsync();
        return employee.Id;
    }

    public async Task UpdateEmployeeAsync(Employee employee)
    {
        _mainContext.Employees.Update(employee);
        await _mainContext.SaveChangesAsync();
    }

    public async Task RemoveEmployeesAsync(Guid id)
    {
        var employee = await SelectEmployeeByIdAsync(id);
        _mainContext.Employees.Remove(employee);
        await _mainContext.SaveChangesAsync();
    }

    public async Task<Employee> SelectEmployeeByIdAsync(Guid employeeId)
    {
        var employee = await _mainContext.Employees.FirstOrDefaultAsync(x => x.Id == employeeId);
        if (employee == null)
        {
            throw new NotFoundException("Entity not found from DB");
        }

        return employee;
    }
}
