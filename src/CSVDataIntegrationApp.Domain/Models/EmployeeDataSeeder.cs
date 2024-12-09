using CSVDataIntegrationApp.Domain.Entites;

namespace CSVDataIntegrationApp.Domain.Models;

public static class EmployeeDataSeeder
{
    public static Employee[] GetSeedData()
    {
        return new Employee[]
        {
            new Employee
            {
                Id = Guid.NewGuid(),
                PayrollNumber = "EMP001",
                Forenames = "John",
                Surname = "Doe",
                DateOfBirth = new DateTime(1985, 6, 15),
                Telephone = "1234567890",
                Mobile = "9876543210",
                Address = "123 Main Street",
                Address2 = "Apt 4B",
                Postcode = "10001",
                EmailHome = "john.doe@example.com",
                StartDate = new DateTime(2020, 1, 10)
            },
            new Employee
            {
                Id = Guid.NewGuid(),
                PayrollNumber = "EMP002",
                Forenames = "Jane",
                Surname = "Smith",
                DateOfBirth = new DateTime(1990, 4, 20),
                Telephone = "2345678901",
                Mobile = "8765432109",
                Address = "456 Elm Street",
                Address2 = "Suite 5C",
                Postcode = "10002",
                EmailHome = "jane.smith@example.com",
                StartDate = new DateTime(2021, 3, 15)
            },
            new Employee
            {
                Id = Guid.NewGuid(),
                PayrollNumber = "EMP003",
                Forenames = "Michael",
                Surname = "Johnson",
                DateOfBirth = new DateTime(1980, 12, 1),
                Telephone = "3456789012",
                Mobile = "7654321098",
                Address = "789 Oak Avenue",
                Address2 = "Unit 1D",
                Postcode = "10003",
                EmailHome = "michael.johnson@example.com",
                StartDate = new DateTime(2019, 5, 20)
            },
            new Employee
            {
                Id = Guid.NewGuid(),
                PayrollNumber = "EMP004",
                Forenames = "Emily",
                Surname = "Davis",
                DateOfBirth = new DateTime(1995, 8, 30),
                Telephone = "4567890123",
                Mobile = "6543210987",
                Address = "321 Pine Lane",
                Address2 = "",
                Postcode = "10004",
                EmailHome = "emily.davis@example.com",
                StartDate = new DateTime(2022, 2, 25)
            },
            new Employee
            {
                Id = Guid.NewGuid(),
                PayrollNumber = "EMP005",
                Forenames = "Robert",
                Surname = "Brown",
                DateOfBirth = new DateTime(1988, 3, 12),
                Telephone = "5678901234",
                Mobile = "5432109876",
                Address = "987 Willow Road",
                Address2 = "Building 2",
                Postcode = "10005",
                EmailHome = "robert.brown@example.com",
                StartDate = new DateTime(2018, 7, 30)
            },
            new Employee
            {
                Id = Guid.NewGuid(),
                PayrollNumber = "EMP006",
                Forenames = "Sarah",
                Surname = "Wilson",
                DateOfBirth = new DateTime(1993, 11, 18),
                Telephone = "6789012345",
                Mobile = "4321098765",
                Address = "654 Maple Drive",
                Address2 = "Floor 3",
                Postcode = "10006",
                EmailHome = "sarah.wilson@example.com",
                StartDate = new DateTime(2021, 6, 1)
            },
            new Employee
            {
                Id = Guid.NewGuid(),
                PayrollNumber = "EMP007",
                Forenames = "David",
                Surname = "Lee",
                DateOfBirth = new DateTime(1982, 7, 5),
                Telephone = "789013456",
                Mobile = "3210987654",
                Address = "321 Birch Boulevard",
                Address2 = "",
                Postcode = "10007",
                EmailHome = "david.lee@example.com",
                StartDate = new DateTime(2017, 12, 12)
            },
            new Employee
            {
                Id = Guid.NewGuid(),
                PayrollNumber = "EMP008",
                Forenames = "Anna",
                Surname = "Taylor",
                DateOfBirth = new DateTime(1991, 9, 22),
                Telephone = "8901234567",
                Mobile = "2109876543",
                Address = "147 Cherry Lane",
                Address2 = "Apartment 8A",
                Postcode = "10008",
                EmailHome = "anna.taylor@example.com",
                StartDate = new DateTime(2023, 4, 18)
            },
            new Employee
            {
                Id = Guid.NewGuid(),
                PayrollNumber = "EMP009",
                Forenames = "James",
                Surname = "Martinez",
                DateOfBirth = new DateTime(1987, 10, 10),
                Telephone = "9012345678",
                Mobile = "1098765432",
                Address = "963 Cedar Street",
                Address2 = "Unit B",
                Postcode = "10009",
                EmailHome = "james.martinez@example.com",
                StartDate = new DateTime(2019, 9, 15)
            },
            new Employee
            {
                Id = Guid.NewGuid(),
                PayrollNumber = "EMP010",
                Forenames = "Sophia",
                Surname = "Garcia",
                DateOfBirth = new DateTime(1994, 5, 25),
                Telephone = "0123456789",
                Mobile = "0987654321",
                Address = "852 Aspen Circle",
                Address2 = "House 4",
                Postcode = "10010",
                EmailHome = "sophia.garcia@example.com",
                StartDate = new DateTime(2022, 8, 5)
            }
        };

    }
}
