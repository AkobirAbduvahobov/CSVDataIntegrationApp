using CSVDataIntegrationApp.Application.DTOs;
using CSVDataIntegrationApp.Application.Services;
using CSVDataIntegrationApp.Domain.Entites;
using CSVDataIntegrationApp.Infrastructure.Repositories;
using FluentValidation;
using Moq;

namespace CSVDataIntegrationApp.Application.Tests;

public class EmployeeServiceTests
{
    private readonly Mock<IEmployeeRepository> _employeeRepositoryMock;
    private readonly Mock<IValidator<CreateEmployeeDto>> _createEmployeeValidatorMock;
    private readonly Mock<IValidator<EmployeeDto>> _employeeValidatorMock;
    private readonly EmployeeService _employeeService;

    public EmployeeServiceTests()
    {
        _employeeRepositoryMock = new Mock<IEmployeeRepository>();
        _createEmployeeValidatorMock = new Mock<IValidator<CreateEmployeeDto>>();
        _employeeValidatorMock = new Mock<IValidator<EmployeeDto>>();

        _employeeService = new EmployeeService(
            _employeeRepositoryMock.Object,
            _createEmployeeValidatorMock.Object,
            _employeeValidatorMock.Object);
    }

    [Fact]
    public async Task AddEmployeeAsync_ValidData_ReturnsEmployeeId()
    {
        // Arrange
        var createEmployeeDto = new CreateEmployeeDto
        {
            PayrollNumber = "12345",
            Forenames = "John",
            Surname = "Doe",
            DateOfBirth = new DateTime(1990, 1, 1),
            Telephone = "1234567890",
            Mobile = "0987654321",
            Address = "123 Street",
            Address2 = "Apt 456",
            Postcode = "12345",
            EmailHome = "john.doe@example.com",
            StartDate = new DateTime(2023, 1, 1)
        };

        _createEmployeeValidatorMock
            .Setup(v => v.Validate(createEmployeeDto))
            .Returns(new FluentValidation.Results.ValidationResult());

        _employeeRepositoryMock
            .Setup(r => r.InsertEmployeeAsync(It.IsAny<Employee>()))
            .ReturnsAsync(Guid.NewGuid());

        // Act
        var result = await _employeeService.AddEmployeeAsync(createEmployeeDto);

        // Assert
        Assert.NotEqual(Guid.Empty, result);
        _createEmployeeValidatorMock.Verify(v => v.Validate(createEmployeeDto), Times.Once);
        _employeeRepositoryMock.Verify(r => r.InsertEmployeeAsync(It.IsAny<Employee>()), Times.Once);
    }

    [Fact]
    public async Task UpdateEmployeeAsync_ValidData_UpdatesEmployee()
    {
        // Arrange
        var employeeDto = new EmployeeDto
        {
            Id = Guid.NewGuid(),
            PayrollNumber = "12345",
            Forenames = "John",
            Surname = "Doe",
            DateOfBirth = new DateTime(1990, 1, 1),
            Telephone = "1234567890",
            Mobile = "0987654321",
            Address = "123 Street",
            Address2 = "Apt 456",
            Postcode = "12345",
            EmailHome = "john.doe@example.com",
            StartDate = new DateTime(2023, 1, 1)
        };

        _employeeValidatorMock
            .Setup(v => v.Validate(employeeDto))
            .Returns(new FluentValidation.Results.ValidationResult());

        _employeeRepositoryMock
            .Setup(r => r.UpdateEmployeeAsync(It.IsAny<Employee>()))
            .Returns(Task.CompletedTask);

        // Act
        await _employeeService.UpdateEmployeeAsync(employeeDto);

        // Assert
        _employeeValidatorMock.Verify(v => v.Validate(employeeDto), Times.Once);
        _employeeRepositoryMock.Verify(r => r.UpdateEmployeeAsync(It.IsAny<Employee>()), Times.Once);
    }

    [Fact]
    public async Task GetEmployeeByIdAsync_ValidId_ReturnsEmployeeDto()
    {
        // Arrange
        var employeeId = Guid.NewGuid();
        var employee = new Employee
        {
            Id = employeeId,
            PayrollNumber = "12345",
            Forenames = "John",
            Surname = "Doe",
            DateOfBirth = new DateTime(1990, 1, 1),
            Telephone = "1234567890",
            Mobile = "0987654321",
            Address = "123 Street",
            Address2 = "Apt 456",
            Postcode = "12345",
            EmailHome = "john.doe@example.com",
            StartDate = new DateTime(2023, 1, 1)
        };

        _employeeRepositoryMock
            .Setup(r => r.SelectEmployeeByIdAsync(employeeId))
            .ReturnsAsync(employee);

        // Act
        var result = await _employeeService.GetEmployeeByIdAsync(employeeId);

        // Assert
        Assert.NotNull(result);
        Assert.Equal(employeeId, result.Id);
        _employeeRepositoryMock.Verify(r => r.SelectEmployeeByIdAsync(employeeId), Times.Once);
    }


    [Fact]
    public async Task DeleteEmployeeByIdAsync_ValidId_RemovesEmployee()
    {
        // Arrange
        var employeeId = Guid.NewGuid();

        _employeeRepositoryMock
            .Setup(r => r.RemoveEmployeesAsync(employeeId))
            .Returns(Task.CompletedTask);

        // Act
        await _employeeService.DeleteEmployeeByIdAsync(employeeId);

        // Assert
        _employeeRepositoryMock.Verify(r => r.RemoveEmployeesAsync(employeeId), Times.Once);
    }
}

