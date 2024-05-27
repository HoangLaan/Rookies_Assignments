using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EFCoreAssignment02.Infrastructure.Migrations
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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
    }
}
