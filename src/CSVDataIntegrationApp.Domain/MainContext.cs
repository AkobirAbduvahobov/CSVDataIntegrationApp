using CSVDataIntegrationApp.Domain.Entites;
using CSVDataIntegrationApp.Domain.EntitiesConfiguration;
using CSVDataIntegrationApp.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace CSVDataIntegrationApp.Domain;

public class MainContext : DbContext
{
    public DbSet<Employee> Employees { get; set; }

    public MainContext(DbContextOptions<MainContext> options)
           : base(options)
    {

    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.ConfigureWarnings(warnings => warnings.Ignore(RelationalEventId.PendingModelChangesWarning));
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new EmployeeConfiguration());

        SeedPaginationOptions(modelBuilder);
    }

    private void SeedPaginationOptions(ModelBuilder modelBuilder)
    {
        var predefinedEmployeeData = EmployeeDataSeeder.GetSeedData();

        foreach (var employee in predefinedEmployeeData)
        {
            modelBuilder.Entity<Employee>().HasData(new
            {
                employee.Id,
                employee.PayrollNumber,
                employee.Forenames,
                employee.Surname,
                employee.DateOfBirth,
                employee.Telephone,
                employee.Mobile,
                employee.Address,
                employee.Address2,
                employee.Postcode,
                employee.EmailHome,
                employee.StartDate,
            });
        }
    }
}
