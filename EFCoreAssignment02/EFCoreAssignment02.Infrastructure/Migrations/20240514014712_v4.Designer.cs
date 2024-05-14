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
    [Migration("20240514014712_v4")]
    partial class v4
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
                            Id = new Guid("6755fa6d-07c9-4a71-9397-5398771e4ea2"),
                            Name = "Software Development"
                        },
                        new
                        {
                            Id = new Guid("1fa6b23a-7d56-488c-81fc-42d6aedf95e2"),
                            Name = "Finance"
                        },
                        new
                        {
                            Id = new Guid("7a063f4c-5f38-4610-b9e3-9ac7541cfe73"),
                            Name = "Accountant"
                        },
                        new
                        {
                            Id = new Guid("95e879ce-21eb-42b7-99f6-3df779c443b1"),
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

                    b.HasData(
                        new
                        {
                            Id = new Guid("37623881-742d-4368-9e49-b7763426452e"),
                            Name = "MB Bank"
                        },
                        new
                        {
                            Id = new Guid("56b51f6b-cd11-405f-86da-39d7adee0937"),
                            Name = "Techcombank"
                        });
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
