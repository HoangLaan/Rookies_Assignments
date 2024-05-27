using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EFCoreAssignment01.WebApp.Migrations
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
                    { new Guid("49fc70da-35d9-47e2-b7bf-fae7f454a19e"), "Software Development" },
                    { new Guid("4e22243b-e90c-4596-a61d-4acabe07e6a5"), "Finance" },
                    { new Guid("a1026499-d1dc-4342-b8a8-402242062115"), "Accountant" },
                    { new Guid("a1fe6d77-5e7d-496f-ac18-899b105dd90e"), "HR" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: new Guid("49fc70da-35d9-47e2-b7bf-fae7f454a19e"));

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: new Guid("4e22243b-e90c-4596-a61d-4acabe07e6a5"));

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: new Guid("a1026499-d1dc-4342-b8a8-402242062115"));

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: new Guid("a1fe6d77-5e7d-496f-ac18-899b105dd90e"));

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
    }
}
