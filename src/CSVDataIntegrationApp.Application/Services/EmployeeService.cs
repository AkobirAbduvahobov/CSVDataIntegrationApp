using CSVDataIntegrationApp.Application.DTOs;
using CSVDataIntegrationApp.Application.Models;
using CSVDataIntegrationApp.Domain.Entites;
using CSVDataIntegrationApp.Infrastructure.Repositories;
using System.Globalization;

namespace CSVDataIntegrationApp.Application.Services;

public class EmployeeService : IEmployeeService
{
    private readonly IEmployeeRepository _employeeRepository;

    public EmployeeService(IEmployeeRepository employeeRepository)
    {
        _employeeRepository = employeeRepository;
    }

    public async Task<int> AddEmployeesAsync(Stream csvFileStream)
    {
        var employees = new List<Employee>();
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

                employees.Add(new Employee
                {
                    Id = Guid.NewGuid(),
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

        return await _employeeRepository.AddEmployeesAsync(employees);
    }

    public Task<List<EmployeeDto>> GetEmployeesAsync(EmployeeQueryModel employeeQueryModel)
    {
        throw new NotImplementedException();
    }
}
