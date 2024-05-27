using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EFCoreAssignment02.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class v3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: new Guid("2faf7048-f98c-4c54-9f21-d1229c11b802"));

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: new Guid("7eaa4322-5797-492c-90bd-4b0ed8d7874d"));

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: new Guid("cdaa25b3-e336-443f-822f-f36b9ac0b3b0"));

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: new Guid("d50a908d-41ff-4e44-9143-f9f4f90292af"));

            migrationBuilder.DeleteData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: new Guid("331d9fa2-e8df-4e3d-9cc9-b0b564c24cf9"));

            migrationBuilder.DeleteData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: new Guid("fa71b49d-c041-4164-98ce-ebf7f4d218ac"));

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
                    { new Guid("2faf7048-f98c-4c54-9f21-d1229c11b802"), "Software Development" },
                    { new Guid("7eaa4322-5797-492c-90bd-4b0ed8d7874d"), "Accountant" },
                    { new Guid("cdaa25b3-e336-443f-822f-f36b9ac0b3b0"), "HR" },
                    { new Guid("d50a908d-41ff-4e44-9143-f9f4f90292af"), "Finance" }
                });

            migrationBuilder.InsertData(
                table: "Projects",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("331d9fa2-e8df-4e3d-9cc9-b0b564c24cf9"), "MB Bank" },
                    { new Guid("fa71b49d-c041-4164-98ce-ebf7f4d218ac"), "Techcombank" }
                });
        }
    }
}
