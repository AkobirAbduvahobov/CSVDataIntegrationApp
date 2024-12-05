using CSVDataIntegrationApp.Domain.Entites;
using CSVDataIntegrationApp.Domain.EntitiesConfiguration;
using Microsoft.EntityFrameworkCore;

namespace CSVDataIntegrationApp.Domain;

public class MainContext : DbContext
{
    public DbSet<Employee> Employees { get; set; }

    public MainContext(DbContextOptions<MainContext> options)
           : base(options)
    {

    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new EmployeeConfiguration());
    }
}
