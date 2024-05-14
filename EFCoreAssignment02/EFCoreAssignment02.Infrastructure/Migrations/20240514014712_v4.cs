using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EFCoreAssignment02.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class v4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: new Guid("2d23e418-7ea8-4020-8908-fbbfb325dec7"));

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: new Guid("81b43805-3f0a-4786-8d42-64d6ca3fe9cf"));

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: new Guid("9ec0165f-8ab8-42f4-8c1b-4e3e201c673d"));

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: new Guid("aa733daf-6357-4e8a-8829-4b83af4f570c"));

            migrationBuilder.DeleteData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: new Guid("8c012bcd-9d66-4209-a8e8-bfcc4dca9aa6"));

            migrationBuilder.DeleteData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: new Guid("ffc0818e-2662-4e5c-b49c-91a84257893a"));

            migrationBuilder.DeleteData(
                table: "Salaries",
                keyColumn: "Id",
                keyValue: new Guid("46472e10-c263-4acf-b586-61015fc19179"));

            migrationBuilder.DeleteData(
                table: "Salaries",
                keyColumn: "Id",
                keyValue: new Guid("d0de663c-0795-4b95-9eba-7a7746fdb3a7"));

            migrationBuilder.InsertData(
                table: "Departments",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("1fa6b23a-7d56-488c-81fc-42d6aedf95e2"), "Finance" },
                    { new Guid("6755fa6d-07c9-4a71-9397-5398771e4ea2"), "Software Development" },
                    { new Guid("7a063f4c-5f38-4610-b9e3-9ac7541cfe73"), "Accountant" },
                    { new Guid("95e879ce-21eb-42b7-99f6-3df779c443b1"), "HR" }
                });

            migrationBuilder.InsertData(
                table: "Projects",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("37623881-742d-4368-9e49-b7763426452e"), "MB Bank" },
                    { new Guid("56b51f6b-cd11-405f-86da-39d7adee0937"), "Techcombank" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: new Guid("1fa6b23a-7d56-488c-81fc-42d6aedf95e2"));

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: new Guid("6755fa6d-07c9-4a71-9397-5398771e4ea2"));

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: new Guid("7a063f4c-5f38-4610-b9e3-9ac7541cfe73"));

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: new Guid("95e879ce-21eb-42b7-99f6-3df779c443b1"));

            migrationBuilder.DeleteData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: new Guid("37623881-742d-4368-9e49-b7763426452e"));

            migrationBuilder.DeleteData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: new Guid("56b51f6b-cd11-405f-86da-39d7adee0937"));

            migrationBuilder.InsertData(
                table: "Departments",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("2d23e418-7ea8-4020-8908-fbbfb325dec7"), "Accountant" },
                    { new Guid("81b43805-3f0a-4786-8d42-64d6ca3fe9cf"), "HR" },
                    { new Guid("9ec0165f-8ab8-42f4-8c1b-4e3e201c673d"), "Finance" },
                    { new Guid("aa733daf-6357-4e8a-8829-4b83af4f570c"), "Software Development" }
                });

            migrationBuilder.InsertData(
                table: "Projects",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("8c012bcd-9d66-4209-a8e8-bfcc4dca9aa6"), "Techcombank" },
                    { new Guid("ffc0818e-2662-4e5c-b49c-91a84257893a"), "MB Bank" }
                });

            migrationBuilder.InsertData(
                table: "Salaries",
                columns: new[] { "Id", "EmployeeId", "Salary" },
                values: new object[,]
                {
                    { new Guid("46472e10-c263-4acf-b586-61015fc19179"), new Guid("00000000-0000-0000-0000-000000000000"), 5000.0 },
                    { new Guid("d0de663c-0795-4b95-9eba-7a7746fdb3a7"), new Guid("00000000-0000-0000-0000-000000000000"), 4000.0 }
                });
        }
    }
}
