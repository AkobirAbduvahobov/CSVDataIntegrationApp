using CSVDataIntegrationApp.Application.DTOs;
using CSVDataIntegrationApp.Application.Models;
using CSVDataIntegrationApp.Domain.Entites;
using CSVDataIntegrationApp.Infrastructure.Repositories;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using System.Globalization;

namespace CSVDataIntegrationApp.Application.Services;

public class EmployeeService : IEmployeeService
{
    private readonly IEmployeeRepository _employeeRepository;
    private readonly IValidator<CreateEmployeeDto> _createEmployeeValidator;
    private readonly IValidator<EmployeeDto> _employeeValidator;

    public EmployeeService(IEmployeeRepository employeeRepository, IValidator<CreateEmployeeDto> createEmployeeValidator, IValidator<EmployeeDto> employeeValidator)
    {
        _employeeRepository = employeeRepository;
        _createEmployeeValidator = createEmployeeValidator;
        _employeeValidator = employeeValidator;
    }

    public async Task<Guid> AddEmployeeAsync(CreateEmployeeDto createEmployeeDto)
    {
        ValidateCreateEmployeeDto(createEmployeeDto);
        var entity = ConvertToEntity(createEmployeeDto);
        var id = await _employeeRepository.InsertEmployeeAsync(entity);

        return id;
    }

    public async Task UpdateEmployeeAsync(EmployeeDto employeeDto)
    {
        var employee = ConvertToEntity(employeeDto);
        await _employeeRepository.UpdateEmployeeAsync(employee);
    }

    public async Task DeleteEmployeeByIdAsync(Guid employeeId)
    {
        await _employeeRepository.RemoveEmployeesAsync(employeeId); 
    }

    public async Task<EmployeeDto> GetEmployeeByIdAsync(Guid employeeId)
    {
        var employee = await _employeeRepository.SelectEmployeeByIdAsync(employeeId);
        var employeeDto = ConverToDto(employee);

        return employeeDto;
    }

    public async Task<int> AddEmployeesAsync(Stream csvFileStream)
    {
        var employeesDto = new List<CreateEmployeeDto>();
        using (var reader = new StreamReader(csvFileStream))
        {
            var headerLine = await reader.ReadLineAsync();
            if (string.IsNullOrEmpty(headerLine) is true)
            {
                throw new InvalidOperationException("Empty file");
            }

            while (!reader.EndOfStream)
            {
                var line = await reader.ReadLineAsync();
                if (string.IsNullOrEmpty(line)) continue;

                var fields = line.Split(',');

                var dateOfBirth = new DateTime();
                var formats = new string[] { "d/M/yyyy", "dd/MM/yyyy", "d/MM/yyyy", "dd/M/yyyy" };
                var resBirth = DateTime.TryParseExact(fields[3].Trim(), formats, CultureInfo.InvariantCulture, DateTimeStyles.None, out dateOfBirth);
                if (resBirth is false)
                {
                    throw new FormatException($"Invalid date format: {fields[3].Trim()}");
                }

                var startDate = new DateTime();
                var resStart = DateTime.TryParseExact(fields[10].Trim(), formats, CultureInfo.InvariantCulture, DateTimeStyles.None, out startDate);
                if (resStart is false)
                {
                    throw new FormatException($"Invalid date format: {fields[10].Trim()}");
                }

                employeesDto.Add(new CreateEmployeeDto
                {
                    PayrollNumber = fields[0].Trim(),
                    Forenames = fields[1].Trim(),
                    Surname = fields[2].Trim(),
                    DateOfBirth = dateOfBirth,
                    Telephone = fields[4].Trim(),
                    Mobile = fields[5].Trim(),
                    Address = fields[6].Trim(),
                    Address2 = fields[7].Trim(),
                    Postcode = fields[8].Trim(),
                    EmailHome = fields[9].Trim(),
                    StartDate = startDate
                });
            }
        }

        var employees = employeesDto.Select(dto =>
        {
            ValidateCreateEmployeeDto(dto);
            return ConvertToEntity(dto);
        }).ToList();

        return await AddEmployeesToDbAsync(employees);
    }

    private async Task<int> AddEmployeesToDbAsync(List<Employee> employees)
    {
        var res = await _employeeRepository.InsertEmployeesAsync(employees);
        return res;
    }

    public async Task<List<EmployeeDto>> GetEmployeesAsync(EmployeeQueryModel employeeQueryModel)
    {
        var employeesQuery = _employeeRepository.SelectEmployeesAsync();

        if (employeesQuery is null)
        {
            throw new ArgumentNullException(nameof(employeesQuery));
        }

        if (string.IsNullOrWhiteSpace(employeeQueryModel.Search) is false)
        {
            employeesQuery = employeesQuery.Where(e =>
                e.Surname.Contains(employeeQueryModel.Search) ||
                e.Forenames.Contains(employeeQueryModel.Search) ||
                e.EmailHome.Contains(employeeQueryModel.Search));
        }

        employeesQuery = employeeQueryModel.SortColumn switch
        {
            "Surname" => employeeQueryModel.SortAscending ? employeesQuery.OrderBy(e => e.Surname)
                                                                : employeesQuery.OrderByDescending(e => e.Surname),
            "DateOfBirth" => employeeQueryModel.SortAscending ? employeesQuery.OrderBy(e => e.DateOfBirth)
                                                                : employeesQuery.OrderByDescending(e => e.DateOfBirth),
            _ => employeesQuery.OrderBy(e => e.Surname),
        };

        var resultEmployees = await employeesQuery.ToListAsync();
        var employeeDtos = resultEmployees.Select(e => ConverToDto(e)).ToList();

        return employeeDtos;
    }

    private EmployeeDto ConverToDto(Employee e)
    {
        return new EmployeeDto()
        {
            Id = e.Id,
            PayrollNumber = e.PayrollNumber,
            Forenames = e.Forenames,
            Surname = e.Surname,
            DateOfBirth = e.DateOfBirth,
            Telephone = e.Telephone,
            Mobile = e.Mobile,
            Address = e.Address,
            Address2 = e.Address2,
            Postcode = e.Postcode,
            EmailHome = e.EmailHome,
            StartDate = e.StartDate,
        };
    }

    private Employee ConvertToEntity(CreateEmployeeDto dto)
    {
        return new Employee()
        {
            Id = Guid.NewGuid(),
            PayrollNumber = dto.PayrollNumber,
            Forenames = dto.Forenames,
            Surname = dto.Surname,
            DateOfBirth = dto.DateOfBirth,
            Telephone = dto.Telephone,
            Mobile = dto.Mobile,
            Address = dto.Address,
            Address2 = dto.Address2,
            Postcode = dto.Postcode,
            EmailHome = dto.EmailHome,
            StartDate = dto.StartDate,
        };
    }

    private Employee ConvertToEntity(EmployeeDto dto)
    {
        return new Employee()
        {
            Id = dto.Id,
            PayrollNumber = dto.PayrollNumber,
            Forenames = dto.Forenames,
            Surname = dto.Surname,
            DateOfBirth = dto.DateOfBirth,
            Telephone = dto.Telephone,
            Mobile = dto.Mobile,
            Address = dto.Address,
            Address2 = dto.Address2,
            Postcode = dto.Postcode,
            EmailHome = dto.EmailHome,
            StartDate = dto.StartDate,
        };
    }



    private void ValidateCreateEmployeeDto(CreateEmployeeDto createEmployeeDto)
    {
        var validationResult = _createEmployeeValidator.Validate(createEmployeeDto);

        if (validationResult.IsValid is false)
        {
            var errors = validationResult.Errors.Select(e => e.ErrorMessage);
            throw new ValidationException(string.Join(", ", errors));
        }
    }

    private void ValidateEmployeeDto(EmployeeDto employeeDto)
    {
        var validationResult = _employeeValidator.Validate(employeeDto);

        if (validationResult.IsValid is false)
        {
            var errors = validationResult.Errors.Select(e => e.ErrorMessage);
            throw new ValidationException(string.Join(", ", errors));
        }
    }

   
}
