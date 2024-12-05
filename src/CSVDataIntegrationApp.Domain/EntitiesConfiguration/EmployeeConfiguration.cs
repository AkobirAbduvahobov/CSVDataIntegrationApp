using CSVDataIntegrationApp.Domain.Entites;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace CSVDataIntegrationApp.Domain.EntitiesConfiguration;

public class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
{
    public void Configure(EntityTypeBuilder<Employee> builder)
    {
        builder.HasKey(e => e.Id);

        builder.Property(e => e.Id)
            .IsRequired()
            .ValueGeneratedOnAdd(); 

        builder.Property(e => e.PayrollNumber)
            .IsRequired()
            .HasMaxLength(50); 

        builder.Property(e => e.Forenames)
            .IsRequired()
            .HasMaxLength(100); 

        builder.Property(e => e.Surname)
            .IsRequired()
            .HasMaxLength(100); 

        builder.Property(e => e.DateOfBirth)
            .IsRequired();

        builder.Property(e => e.Telephone)
            .HasMaxLength(15); 

        builder.Property(e => e.Mobile)
            .HasMaxLength(15);

        builder.Property(e => e.Address)
            .IsRequired()
            .HasMaxLength(200);

        builder.Property(e => e.Address2)
            .HasMaxLength(200); 

        builder.Property(e => e.Postcode)
            .IsRequired()
            .HasMaxLength(10);

        builder.Property(e => e.EmailHome)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(e => e.StartDate)
            .IsRequired();

        builder.HasIndex(e => e.PayrollNumber).IsUnique(); 
        builder.HasIndex(e => e.EmailHome).IsUnique(); 
    }
}

