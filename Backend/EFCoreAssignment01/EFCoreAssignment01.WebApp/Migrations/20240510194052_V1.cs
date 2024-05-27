using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EFCoreAssignment01.WebApp.Migrations
{
    /// <inheritdoc />
    public partial class V1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: new Guid("2217ab1f-977f-482c-9239-abcc15803d4e"));

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: new Guid("56cb1980-2f91-433a-a205-7f92c4484481"));

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: new Guid("80ae243f-5d68-476a-998b-fd5fc52d6c4e"));

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: new Guid("f3f58362-696f-4d29-9260-324fd8496597"));

            migrationBuilder.InsertData(
                table: "Departments",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("390cfc95-9a0b-4567-834d-e5d41a5155e5"), "HR" },
                    { new Guid("4b07443f-34f7-4248-be61-2d5710ee0ec5"), "Software Development" },
                    { new Guid("7b8a2d2a-0889-4eac-b0bb-5c6b6c368023"), "Finance" },
                    { new Guid("89643d52-03a3-4df5-9ab7-7b97fb4bff75"), "Accountant" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: new Guid("390cfc95-9a0b-4567-834d-e5d41a5155e5"));

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: new Guid("4b07443f-34f7-4248-be61-2d5710ee0ec5"));

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: new Guid("7b8a2d2a-0889-4eac-b0bb-5c6b6c368023"));

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: new Guid("89643d52-03a3-4df5-9ab7-7b97fb4bff75"));

            migrationBuilder.InsertData(
                table: "Departments",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("2217ab1f-977f-482c-9239-abcc15803d4e"), "Software Development" },
                    { new Guid("56cb1980-2f91-433a-a205-7f92c4484481"), "Accountant" },
                    { new Guid("80ae243f-5d68-476a-998b-fd5fc52d6c4e"), "Finance" },
                    { new Guid("f3f58362-696f-4d29-9260-324fd8496597"), "HR" }
                });
        }
    }
}
