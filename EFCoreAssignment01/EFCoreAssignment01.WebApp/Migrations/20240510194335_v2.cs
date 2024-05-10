using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EFCoreAssignment01.WebApp.Migrations
{
    /// <inheritdoc />
    public partial class v2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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
                    { new Guid("10acba3f-2830-401b-b836-87ba2a041455"), "Software Development" },
                    { new Guid("97709cef-e3f4-4786-9e0b-fe0ed5826928"), "HR" },
                    { new Guid("d484d6be-4022-4cc6-bc0f-a4eea53c04d0"), "Accountant" },
                    { new Guid("ed8302f2-96c5-4755-90bf-b99e0018825f"), "Finance" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: new Guid("10acba3f-2830-401b-b836-87ba2a041455"));

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: new Guid("97709cef-e3f4-4786-9e0b-fe0ed5826928"));

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: new Guid("d484d6be-4022-4cc6-bc0f-a4eea53c04d0"));

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: new Guid("ed8302f2-96c5-4755-90bf-b99e0018825f"));

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
    }
}
