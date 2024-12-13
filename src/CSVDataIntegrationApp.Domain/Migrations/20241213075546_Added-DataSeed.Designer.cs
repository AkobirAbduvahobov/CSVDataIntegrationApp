﻿// <auto-generated />
using System;
using CSVDataIntegrationApp.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CSVDataIntegrationApp.Domain.Migrations
{
    [DbContext(typeof(MainContext))]
    [Migration("20241213075546_Added-DataSeed")]
    partial class AddedDataSeed
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("CSVDataIntegrationApp.Domain.Entites.Employee", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("Address2")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("datetime2");

                    b.Property<string>("EmailHome")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Forenames")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Mobile")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.Property<string>("PayrollNumber")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Postcode")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Telephone")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.HasKey("Id");

                    b.HasIndex("EmailHome")
                        .IsUnique();

                    b.HasIndex("PayrollNumber")
                        .IsUnique();

                    b.ToTable("Employees");

                    b.HasData(
                        new
                        {
                            Id = new Guid("b7723755-f37f-41b8-805c-a2e950bab4a1"),
                            Address = "123 Main Street",
                            Address2 = "Apt 4B",
                            DateOfBirth = new DateTime(1985, 6, 15, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            EmailHome = "john.doe@example.com",
                            Forenames = "John",
                            Mobile = "9876543210",
                            PayrollNumber = "EMP001",
                            Postcode = "10001",
                            StartDate = new DateTime(2020, 1, 10, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Surname = "Doe",
                            Telephone = "1234567890"
                        },
                        new
                        {
                            Id = new Guid("2355738f-f8a6-4596-80ba-48e60c0a85e3"),
                            Address = "456 Elm Street",
                            Address2 = "Suite 5C",
                            DateOfBirth = new DateTime(1990, 4, 20, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            EmailHome = "jane.smith@example.com",
                            Forenames = "Jane",
                            Mobile = "8765432109",
                            PayrollNumber = "EMP002",
                            Postcode = "10002",
                            StartDate = new DateTime(2021, 3, 15, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Surname = "Smith",
                            Telephone = "2345678901"
                        },
                        new
                        {
                            Id = new Guid("c39b33aa-fbcf-488c-a456-4fd66078fc09"),
                            Address = "789 Oak Avenue",
                            Address2 = "Unit 1D",
                            DateOfBirth = new DateTime(1980, 12, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            EmailHome = "michael.johnson@example.com",
                            Forenames = "Michael",
                            Mobile = "7654321098",
                            PayrollNumber = "EMP003",
                            Postcode = "10003",
                            StartDate = new DateTime(2019, 5, 20, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Surname = "Johnson",
                            Telephone = "3456789012"
                        },
                        new
                        {
                            Id = new Guid("cbbc823e-604d-4216-96b4-ec05fa126cae"),
                            Address = "321 Pine Lane",
                            Address2 = "",
                            DateOfBirth = new DateTime(1995, 8, 30, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            EmailHome = "emily.davis@example.com",
                            Forenames = "Emily",
                            Mobile = "6543210987",
                            PayrollNumber = "EMP004",
                            Postcode = "10004",
                            StartDate = new DateTime(2022, 2, 25, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Surname = "Davis",
                            Telephone = "4567890123"
                        },
                        new
                        {
                            Id = new Guid("496cdba1-5ba3-463e-9b0f-f33157c6b575"),
                            Address = "987 Willow Road",
                            Address2 = "Building 2",
                            DateOfBirth = new DateTime(1988, 3, 12, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            EmailHome = "robert.brown@example.com",
                            Forenames = "Robert",
                            Mobile = "5432109876",
                            PayrollNumber = "EMP005",
                            Postcode = "10005",
                            StartDate = new DateTime(2018, 7, 30, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Surname = "Brown",
                            Telephone = "5678901234"
                        },
                        new
                        {
                            Id = new Guid("beb5939e-faee-45b3-9e95-f94af9f7907b"),
                            Address = "654 Maple Drive",
                            Address2 = "Floor 3",
                            DateOfBirth = new DateTime(1993, 11, 18, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            EmailHome = "sarah.wilson@example.com",
                            Forenames = "Sarah",
                            Mobile = "4321098765",
                            PayrollNumber = "EMP006",
                            Postcode = "10006",
                            StartDate = new DateTime(2021, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Surname = "Wilson",
                            Telephone = "6789012345"
                        },
                        new
                        {
                            Id = new Guid("8cb88945-b261-459e-ae7e-6880f39dfaa6"),
                            Address = "321 Birch Boulevard",
                            Address2 = "",
                            DateOfBirth = new DateTime(1982, 7, 5, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            EmailHome = "david.lee@example.com",
                            Forenames = "David",
                            Mobile = "3210987654",
                            PayrollNumber = "EMP007",
                            Postcode = "10007",
                            StartDate = new DateTime(2017, 12, 12, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Surname = "Lee",
                            Telephone = "789013456"
                        },
                        new
                        {
                            Id = new Guid("cb4bc3c4-5f64-47fa-864b-af62b0421fca"),
                            Address = "147 Cherry Lane",
                            Address2 = "Apartment 8A",
                            DateOfBirth = new DateTime(1991, 9, 22, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            EmailHome = "anna.taylor@example.com",
                            Forenames = "Anna",
                            Mobile = "2109876543",
                            PayrollNumber = "EMP008",
                            Postcode = "10008",
                            StartDate = new DateTime(2023, 4, 18, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Surname = "Taylor",
                            Telephone = "8901234567"
                        },
                        new
                        {
                            Id = new Guid("28284ea8-d874-48e9-bbd1-15a463526c0c"),
                            Address = "963 Cedar Street",
                            Address2 = "Unit B",
                            DateOfBirth = new DateTime(1987, 10, 10, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            EmailHome = "james.martinez@example.com",
                            Forenames = "James",
                            Mobile = "1098765432",
                            PayrollNumber = "EMP009",
                            Postcode = "10009",
                            StartDate = new DateTime(2019, 9, 15, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Surname = "Martinez",
                            Telephone = "9012345678"
                        },
                        new
                        {
                            Id = new Guid("101ad7c3-db57-4fb5-a38a-ae4ad98c6caf"),
                            Address = "852 Aspen Circle",
                            Address2 = "House 4",
                            DateOfBirth = new DateTime(1994, 5, 25, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            EmailHome = "sophia.garcia@example.com",
                            Forenames = "Sophia",
                            Mobile = "0987654321",
                            PayrollNumber = "EMP010",
                            Postcode = "10010",
                            StartDate = new DateTime(2022, 8, 5, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Surname = "Garcia",
                            Telephone = "0123456789"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
