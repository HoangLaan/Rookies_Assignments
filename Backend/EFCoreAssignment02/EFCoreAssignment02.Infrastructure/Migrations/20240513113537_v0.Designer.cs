﻿// <auto-generated />
using System;
using EFCoreAssignment02.WebApp.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace EFCoreAssignment02.Infrastructure.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20240513113537_v0")]
    partial class v0
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("EFCoreAssignment02.WebApp.Models.Departments", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Departments");

                    b.HasData(
                        new
                        {
                            Id = new Guid("8beb8476-5efe-4777-a23a-67fe02d50467"),
                            Name = "Software Development"
                        },
                        new
                        {
                            Id = new Guid("5f6d5e4e-bca8-4469-a51d-13a598eb674d"),
                            Name = "Finance"
                        },
                        new
                        {
                            Id = new Guid("9d049218-dc8a-4bcd-b677-0b8d5b216915"),
                            Name = "Accountant"
                        },
                        new
                        {
                            Id = new Guid("eb0192c4-49dc-42cb-bc5b-9198ef15ae86"),
                            Name = "HR"
                        });
                });

            modelBuilder.Entity("EFCoreAssignment02.WebApp.Models.Employees", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("DepartmentId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("JoinedDated")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.HasIndex("DepartmentId");

                    b.ToTable("Employees");
                });

            modelBuilder.Entity("EFCoreAssignment02.WebApp.Models.Project_Employee", b =>
                {
                    b.Property<Guid>("EmployeeId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ProjectId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("Enable")
                        .HasColumnType("bit");

                    b.HasKey("EmployeeId", "ProjectId");

                    b.HasIndex("ProjectId");

                    b.ToTable("ProjectEmployee");
                });

            modelBuilder.Entity("EFCoreAssignment02.WebApp.Models.Projects", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Projects");
                });

            modelBuilder.Entity("EFCoreAssignment02.WebApp.Models.Salaries", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("EmployeeId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<double>("Salary")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("EmployeeId")
                        .IsUnique();

                    b.ToTable("Salaries");
                });

            modelBuilder.Entity("EFCoreAssignment02.WebApp.Models.Employees", b =>
                {
                    b.HasOne("EFCoreAssignment02.WebApp.Models.Departments", "Department")
                        .WithMany("Employess")
                        .HasForeignKey("DepartmentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Department");
                });

            modelBuilder.Entity("EFCoreAssignment02.WebApp.Models.Project_Employee", b =>
                {
                    b.HasOne("EFCoreAssignment02.WebApp.Models.Employees", "Employee")
                        .WithMany("ProjectEmployees")
                        .HasForeignKey("EmployeeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EFCoreAssignment02.WebApp.Models.Projects", "Project")
                        .WithMany("ProjectEmployees")
                        .HasForeignKey("ProjectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Employee");

                    b.Navigation("Project");
                });

            modelBuilder.Entity("EFCoreAssignment02.WebApp.Models.Salaries", b =>
                {
                    b.HasOne("EFCoreAssignment02.WebApp.Models.Employees", "Employee")
                        .WithOne("Salary")
                        .HasForeignKey("EFCoreAssignment02.WebApp.Models.Salaries", "EmployeeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Employee");
                });

            modelBuilder.Entity("EFCoreAssignment02.WebApp.Models.Departments", b =>
                {
                    b.Navigation("Employess");
                });

            modelBuilder.Entity("EFCoreAssignment02.WebApp.Models.Employees", b =>
                {
                    b.Navigation("ProjectEmployees");

                    b.Navigation("Salary")
                        .IsRequired();
                });

            modelBuilder.Entity("EFCoreAssignment02.WebApp.Models.Projects", b =>
                {
                    b.Navigation("ProjectEmployees");
                });
#pragma warning restore 612, 618
        }
    }
}
