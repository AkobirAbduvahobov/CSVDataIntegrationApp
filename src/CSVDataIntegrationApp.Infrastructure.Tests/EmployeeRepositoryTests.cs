
using global::CSVDataIntegrationApp.Core.Errors;
using global::CSVDataIntegrationApp.Domain;
using global::CSVDataIntegrationApp.Domain.Entites;
using global::CSVDataIntegrationApp.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

namespace CSVDataIntegrationApp.Infrastructure.Tests;
public class EmployeeRepositoryTests
{
    private readonly EmployeeRepository _repository;
    private readonly DbContextOptions<MainContext> _options;
    private MainContext _context;

    public EmployeeRepositoryTests()
    {
        _options = new DbContextOptionsBuilder<MainContext>()
            .UseInMemoryDatabase(databaseName: "TestDatabase")
            .Options;

        _context = new MainContext(_options);
        _repository = new EmployeeRepository(_context);
    }

    [Fact]
    public async Task InsertEmployeeAsync_ShouldInsertEmployee()
    {
        // Arrange
        var employee = new Employee
        {
            Id = Guid.NewGuid(),
            PayrollNumber = "12345",
            Forenames = "John",
            Surname = "Doe",
            DateOfBirth = DateTime.UtcNow.AddYears(-30),
            Telephone = "1234567890",
            Mobile = "0987654321",
            Address = "123 Main St",
            Address2 = "Apt 4B",
            Postcode = "12345",
            EmailHome = "john.doe@example.com",
            StartDate = DateTime.UtcNow
        };

        // Act
        var employeeId = await _repository.InsertEmployeeAsync(employee);

        // Assert
        var insertedEmployee = await _context.Employees.FindAsync(employeeId);
        Assert.NotNull(insertedEmployee);
        Assert.Equal(employee.PayrollNumber, insertedEmployee.PayrollNumber);
    }

    [Fact]
    public async Task SelectEmployeeByIdAsync_ShouldReturnEmployee()
    {
        // Arrange
        var employee = new Employee
        {
            Id = Guid.NewGuid(),
            PayrollNumber = "12345",
            Forenames = "John",
            Surname = "Doe",
            DateOfBirth = DateTime.UtcNow.AddYears(-30),
            Telephone = "1234567890",
            Mobile = "0987654321",
            Address = "123 Main St",
            Address2 = "Apt 4B",
            Postcode = "12345",
            EmailHome = "john.doe@example.com",
            StartDate = DateTime.UtcNow
        };

        await _repository.InsertEmployeeAsync(employee);

        // Act
        var result = await _repository.SelectEmployeeByIdAsync(employee.Id);

        // Assert
        Assert.NotNull(result);
        Assert.Equal(employee.Id, result.Id);
    }

    [Fact]
    public async Task SelectEmployeeByIdAsync_ShouldThrowNotFoundException_WhenEmployeeNotFound()
    {
        // Act & Assert
        var exception = await Assert.ThrowsAsync<NotFoundException>(() => _repository.SelectEmployeeByIdAsync(Guid.NewGuid()));
        Assert.Equal("Entity not found from DB", exception.Message);
    }

    [Fact]
    public async Task UpdateEmployeeAsync_ShouldUpdateEmployee()
    {
        // Arrange
        var employee = new Employee
        {
            Id = Guid.NewGuid(),
            PayrollNumber = "12345",
            Forenames = "John",
            Surname = "Doe",
            DateOfBirth = DateTime.UtcNow.AddYears(-30),
            Telephone = "1234567890",
            Mobile = "0987654321",
            Address = "123 Main St",
            Address2 = "Apt 4B",
            Postcode = "12345",
            EmailHome = "john.doe@example.com",
            StartDate = DateTime.UtcNow
        };

        var employeeId = await _repository.InsertEmployeeAsync(employee);
        employee.Surname = "Smith"; // Update surname

        // Act
        await _repository.UpdateEmployeeAsync(employee);

        // Assert
        var updatedEmployee = await _context.Employees.FindAsync(employeeId);
        Assert.Equal("Smith", updatedEmployee.Surname);
    }

    [Fact]
    public async Task RemoveEmployeesAsync_ShouldRemoveEmployee()
    {
        // Arrange
        var employee = new Employee
        {
            Id = Guid.NewGuid(),
            PayrollNumber = "12345",
            Forenames = "John",
            Surname = "Doe",
            DateOfBirth = DateTime.UtcNow.AddYears(-30),
            Telephone = "1234567890",
            Mobile = "0987654321",
            Address = "123 Main St",
            Address2 = "Apt 4B",
            Postcode = "12345",
            EmailHome = "john.doe@example.com",
            StartDate = DateTime.UtcNow
        };

        var employeeId = await _repository.InsertEmployeeAsync(employee);

        // Act
        await _repository.RemoveEmployeesAsync(employeeId);

        // Assert
        var removedEmployee = await _context.Employees.FindAsync(employeeId);
        Assert.Null(removedEmployee);
    }

    [Fact]
    public async Task SelectEmployeesAsync_ShouldReturnAllEmployees()
    {
        // Arrange
        var employee1 = new Employee
        {
            Id = Guid.NewGuid(),
            PayrollNumber = "12345",
            Forenames = "John",
            Surname = "Doe",
            DateOfBirth = DateTime.UtcNow.AddYears(-30),
            Telephone = "1234567890",
            Mobile = "0987654321",
            Address = "123 Main St",
            Address2 = "Apt 4B",
            Postcode = "12345",
            EmailHome = "john.doe@example.com",
            StartDate = DateTime.UtcNow
        };

        var employee2 = new Employee
        {
            Id = Guid.NewGuid(),
            PayrollNumber = "67890",
            Forenames = "Jane",
            Surname = "Doe",
            DateOfBirth = DateTime.UtcNow.AddYears(-25),
            Telephone = "0987654321",
            Mobile = "1234567890",
            Address = "456 Main St",
            Address2 = "Apt 2B",
            Postcode = "67890",
            EmailHome = "jane.doe@example.com",
            StartDate = DateTime.UtcNow
        };

        await _repository.InsertEmployeeAsync(employee1);
        await _repository.InsertEmployeeAsync(employee2);

        // Act
        var employees = await _repository.SelectEmployeesAsync().ToListAsync();

        // Assert
        Assert.Equal(2, employees.Count);
    }
}


