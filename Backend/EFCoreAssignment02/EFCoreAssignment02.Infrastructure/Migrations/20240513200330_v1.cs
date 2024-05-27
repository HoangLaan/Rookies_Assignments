using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EFCoreAssignment02.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class v1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: new Guid("5f6d5e4e-bca8-4469-a51d-13a598eb674d"));

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: new Guid("8beb8476-5efe-4777-a23a-67fe02d50467"));

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: new Guid("9d049218-dc8a-4bcd-b677-0b8d5b216915"));

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: new Guid("eb0192c4-49dc-42cb-bc5b-9198ef15ae86"));

            migrationBuilder.InsertData(
                table: "Departments",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("1526e33f-eaee-4d9a-967b-34a5432762aa"), "Accountant" },
                    { new Guid("5bd36ced-0273-4e69-a296-8d352130586f"), "Finance" },
                    { new Guid("693b47b3-d4fb-4a10-8483-09e1d99d54a7"), "Software Development" },
                    { new Guid("bf777f01-6e19-4514-9e09-0f2b17aceaf8"), "HR" }
                });

            migrationBuilder.InsertData(
                table: "Projects",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("9a50909f-a798-40e6-b314-f591d232c894"), "Techcombank" },
                    { new Guid("b179318b-a357-4288-9003-68734cf6bdfc"), "Vietinbank" },
                    { new Guid("dc0a1aad-9c68-48e1-9a89-e3f98d08fbaa"), "MB Bank" },
                    { new Guid("f9f79a32-3e49-4b40-9ff0-4f59c78e805b"), "HSCB" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: new Guid("1526e33f-eaee-4d9a-967b-34a5432762aa"));

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: new Guid("5bd36ced-0273-4e69-a296-8d352130586f"));

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: new Guid("693b47b3-d4fb-4a10-8483-09e1d99d54a7"));

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: new Guid("bf777f01-6e19-4514-9e09-0f2b17aceaf8"));

            migrationBuilder.DeleteData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: new Guid("9a50909f-a798-40e6-b314-f591d232c894"));

            migrationBuilder.DeleteData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: new Guid("b179318b-a357-4288-9003-68734cf6bdfc"));

            migrationBuilder.DeleteData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: new Guid("dc0a1aad-9c68-48e1-9a89-e3f98d08fbaa"));

            migrationBuilder.DeleteData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: new Guid("f9f79a32-3e49-4b40-9ff0-4f59c78e805b"));

            migrationBuilder.InsertData(
                table: "Departments",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("5f6d5e4e-bca8-4469-a51d-13a598eb674d"), "Finance" },
                    { new Guid("8beb8476-5efe-4777-a23a-67fe02d50467"), "Software Development" },
                    { new Guid("9d049218-dc8a-4bcd-b677-0b8d5b216915"), "Accountant" },
                    { new Guid("eb0192c4-49dc-42cb-bc5b-9198ef15ae86"), "HR" }
                });
        }
    }
}
