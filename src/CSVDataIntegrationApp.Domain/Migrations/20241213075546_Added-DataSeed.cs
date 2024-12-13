using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CSVDataIntegrationApp.Domain.Migrations
{
    /// <inheritdoc />
    public partial class AddedDataSeed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: new Guid("27a22354-2c2c-4fef-8e0f-fd4924781b7f"));

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: new Guid("3556edc7-5e78-4c6b-8a61-be1611f44a93"));

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: new Guid("4b085a8f-030a-406f-a401-6d876e4ff170"));

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: new Guid("64e0e131-162b-4235-8f3d-550878a24d0b"));

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: new Guid("70818b60-944f-4e63-ba6f-d50d0e47893c"));

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: new Guid("70a20de0-d1f9-4871-9b3a-02aae234ec53"));

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: new Guid("911f6348-8b31-489d-94a8-3883c93a4c66"));

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: new Guid("a74e4875-4c7d-49f6-ba1e-8e15dab7f27f"));

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: new Guid("c304d43a-1e7c-4e66-8fdf-ca2e609d6e3d"));

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: new Guid("d94b9d16-cdd9-4843-95b9-bec7bfea25a3"));

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Address", "Address2", "DateOfBirth", "EmailHome", "Forenames", "Mobile", "PayrollNumber", "Postcode", "StartDate", "Surname", "Telephone" },
                values: new object[,]
                {
                    { new Guid("101ad7c3-db57-4fb5-a38a-ae4ad98c6caf"), "852 Aspen Circle", "House 4", new DateTime(1994, 5, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "sophia.garcia@example.com", "Sophia", "0987654321", "EMP010", "10010", new DateTime(2022, 8, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Garcia", "0123456789" },
                    { new Guid("2355738f-f8a6-4596-80ba-48e60c0a85e3"), "456 Elm Street", "Suite 5C", new DateTime(1990, 4, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "jane.smith@example.com", "Jane", "8765432109", "EMP002", "10002", new DateTime(2021, 3, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Smith", "2345678901" },
                    { new Guid("28284ea8-d874-48e9-bbd1-15a463526c0c"), "963 Cedar Street", "Unit B", new DateTime(1987, 10, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "james.martinez@example.com", "James", "1098765432", "EMP009", "10009", new DateTime(2019, 9, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Martinez", "9012345678" },
                    { new Guid("496cdba1-5ba3-463e-9b0f-f33157c6b575"), "987 Willow Road", "Building 2", new DateTime(1988, 3, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "robert.brown@example.com", "Robert", "5432109876", "EMP005", "10005", new DateTime(2018, 7, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "Brown", "5678901234" },
                    { new Guid("8cb88945-b261-459e-ae7e-6880f39dfaa6"), "321 Birch Boulevard", "", new DateTime(1982, 7, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "david.lee@example.com", "David", "3210987654", "EMP007", "10007", new DateTime(2017, 12, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Lee", "789013456" },
                    { new Guid("b7723755-f37f-41b8-805c-a2e950bab4a1"), "123 Main Street", "Apt 4B", new DateTime(1985, 6, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "john.doe@example.com", "John", "9876543210", "EMP001", "10001", new DateTime(2020, 1, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Doe", "1234567890" },
                    { new Guid("beb5939e-faee-45b3-9e95-f94af9f7907b"), "654 Maple Drive", "Floor 3", new DateTime(1993, 11, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "sarah.wilson@example.com", "Sarah", "4321098765", "EMP006", "10006", new DateTime(2021, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Wilson", "6789012345" },
                    { new Guid("c39b33aa-fbcf-488c-a456-4fd66078fc09"), "789 Oak Avenue", "Unit 1D", new DateTime(1980, 12, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "michael.johnson@example.com", "Michael", "7654321098", "EMP003", "10003", new DateTime(2019, 5, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Johnson", "3456789012" },
                    { new Guid("cb4bc3c4-5f64-47fa-864b-af62b0421fca"), "147 Cherry Lane", "Apartment 8A", new DateTime(1991, 9, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "anna.taylor@example.com", "Anna", "2109876543", "EMP008", "10008", new DateTime(2023, 4, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "Taylor", "8901234567" },
                    { new Guid("cbbc823e-604d-4216-96b4-ec05fa126cae"), "321 Pine Lane", "", new DateTime(1995, 8, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "emily.davis@example.com", "Emily", "6543210987", "EMP004", "10004", new DateTime(2022, 2, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "Davis", "4567890123" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: new Guid("101ad7c3-db57-4fb5-a38a-ae4ad98c6caf"));

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: new Guid("2355738f-f8a6-4596-80ba-48e60c0a85e3"));

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: new Guid("28284ea8-d874-48e9-bbd1-15a463526c0c"));

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: new Guid("496cdba1-5ba3-463e-9b0f-f33157c6b575"));

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: new Guid("8cb88945-b261-459e-ae7e-6880f39dfaa6"));

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: new Guid("b7723755-f37f-41b8-805c-a2e950bab4a1"));

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: new Guid("beb5939e-faee-45b3-9e95-f94af9f7907b"));

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: new Guid("c39b33aa-fbcf-488c-a456-4fd66078fc09"));

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: new Guid("cb4bc3c4-5f64-47fa-864b-af62b0421fca"));

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: new Guid("cbbc823e-604d-4216-96b4-ec05fa126cae"));

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Address", "Address2", "DateOfBirth", "EmailHome", "Forenames", "Mobile", "PayrollNumber", "Postcode", "StartDate", "Surname", "Telephone" },
                values: new object[,]
                {
                    { new Guid("27a22354-2c2c-4fef-8e0f-fd4924781b7f"), "987 Willow Road", "Building 2", new DateTime(1988, 3, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "robert.brown@example.com", "Robert", "5432109876", "EMP005", "10005", new DateTime(2018, 7, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "Brown", "5678901234" },
                    { new Guid("3556edc7-5e78-4c6b-8a61-be1611f44a93"), "123 Main Street", "Apt 4B", new DateTime(1985, 6, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "john.doe@example.com", "John", "9876543210", "EMP001", "10001", new DateTime(2020, 1, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Doe", "1234567890" },
                    { new Guid("4b085a8f-030a-406f-a401-6d876e4ff170"), "654 Maple Drive", "Floor 3", new DateTime(1993, 11, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "sarah.wilson@example.com", "Sarah", "4321098765", "EMP006", "10006", new DateTime(2021, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Wilson", "6789012345" },
                    { new Guid("64e0e131-162b-4235-8f3d-550878a24d0b"), "789 Oak Avenue", "Unit 1D", new DateTime(1980, 12, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "michael.johnson@example.com", "Michael", "7654321098", "EMP003", "10003", new DateTime(2019, 5, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Johnson", "3456789012" },
                    { new Guid("70818b60-944f-4e63-ba6f-d50d0e47893c"), "321 Pine Lane", "", new DateTime(1995, 8, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "emily.davis@example.com", "Emily", "6543210987", "EMP004", "10004", new DateTime(2022, 2, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "Davis", "4567890123" },
                    { new Guid("70a20de0-d1f9-4871-9b3a-02aae234ec53"), "321 Birch Boulevard", "", new DateTime(1982, 7, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "david.lee@example.com", "David", "3210987654", "EMP007", "10007", new DateTime(2017, 12, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Lee", "789013456" },
                    { new Guid("911f6348-8b31-489d-94a8-3883c93a4c66"), "147 Cherry Lane", "Apartment 8A", new DateTime(1991, 9, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "anna.taylor@example.com", "Anna", "2109876543", "EMP008", "10008", new DateTime(2023, 4, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "Taylor", "8901234567" },
                    { new Guid("a74e4875-4c7d-49f6-ba1e-8e15dab7f27f"), "963 Cedar Street", "Unit B", new DateTime(1987, 10, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "james.martinez@example.com", "James", "1098765432", "EMP009", "10009", new DateTime(2019, 9, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Martinez", "9012345678" },
                    { new Guid("c304d43a-1e7c-4e66-8fdf-ca2e609d6e3d"), "456 Elm Street", "Suite 5C", new DateTime(1990, 4, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "jane.smith@example.com", "Jane", "8765432109", "EMP002", "10002", new DateTime(2021, 3, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Smith", "2345678901" },
                    { new Guid("d94b9d16-cdd9-4843-95b9-bec7bfea25a3"), "852 Aspen Circle", "House 4", new DateTime(1994, 5, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "sophia.garcia@example.com", "Sophia", "0987654321", "EMP010", "10010", new DateTime(2022, 8, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Garcia", "0123456789" }
                });
        }
    }
}
