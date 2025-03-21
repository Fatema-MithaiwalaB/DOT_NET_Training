﻿// <auto-generated />
using System;
using EmployeeProjectAPI.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace EF_Assignment_6.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20250313093744_Adding_Schema_Seeding_Data")]
    partial class Adding_Schema_Seeding_Data
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("EF_Assignment_6.Models.Entity.Department", b =>
                {
                    b.Property<int>("DepartmentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("DepartmentId"));

                    b.Property<string>("DepartmentName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("DepartmentId");

                    b.ToTable("Departments");

                    b.HasData(
                        new
                        {
                            DepartmentId = 1,
                            DepartmentName = "Software Development"
                        },
                        new
                        {
                            DepartmentId = 2,
                            DepartmentName = "Marketing"
                        },
                        new
                        {
                            DepartmentId = 3,
                            DepartmentName = "Finance"
                        });
                });

            modelBuilder.Entity("EF_Assignment_6.Models.Entity.Employee", b =>
                {
                    b.Property<int>("EmployeeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("EmployeeId"));

                    b.Property<int>("DepartmentId")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("EmployeeId");

                    b.HasIndex("DepartmentId");

                    b.ToTable("Employees");

                    b.HasData(
                        new
                        {
                            EmployeeId = 1,
                            DepartmentId = 1,
                            Email = "alice@example.com",
                            Name = "Alice Johnson"
                        },
                        new
                        {
                            EmployeeId = 2,
                            DepartmentId = 1,
                            Email = "bob@example.com",
                            Name = "Bob Smith"
                        },
                        new
                        {
                            EmployeeId = 3,
                            DepartmentId = 2,
                            Email = "charlie@example.com",
                            Name = "Charlie Brown"
                        },
                        new
                        {
                            EmployeeId = 4,
                            DepartmentId = 3,
                            Email = "diana@example.com",
                            Name = "Diana Adams"
                        },
                        new
                        {
                            EmployeeId = 5,
                            DepartmentId = 1,
                            Email = "ethan@example.com",
                            Name = "Ethan White"
                        });
                });

            modelBuilder.Entity("EF_Assignment_6.Models.Entity.EmployeeProject", b =>
                {
                    b.Property<int>("EmployeeId")
                        .HasColumnType("int");

                    b.Property<int>("ProjectId")
                        .HasColumnType("int");

                    b.Property<string>("Role")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("EmployeeId", "ProjectId");

                    b.HasIndex("ProjectId");

                    b.ToTable("EmployeeProjects");

                    b.HasData(
                        new
                        {
                            EmployeeId = 1,
                            ProjectId = 1,
                            Role = "Frontend Developer"
                        },
                        new
                        {
                            EmployeeId = 1,
                            ProjectId = 2,
                            Role = "Backend Developer"
                        },
                        new
                        {
                            EmployeeId = 2,
                            ProjectId = 1,
                            Role = "Full Stack Developer"
                        },
                        new
                        {
                            EmployeeId = 2,
                            ProjectId = 4,
                            Role = "Cloud Architect"
                        },
                        new
                        {
                            EmployeeId = 3,
                            ProjectId = 3,
                            Role = "Marketing Specialist"
                        },
                        new
                        {
                            EmployeeId = 4,
                            ProjectId = 5,
                            Role = "Security Analyst"
                        },
                        new
                        {
                            EmployeeId = 5,
                            ProjectId = 2,
                            Role = "Mobile App Developer"
                        });
                });

            modelBuilder.Entity("EF_Assignment_6.Models.Entity.Project", b =>
                {
                    b.Property<int>("ProjectId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ProjectId"));

                    b.Property<string>("ProjectName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.HasKey("ProjectId");

                    b.ToTable("Projects");

                    b.HasData(
                        new
                        {
                            ProjectId = 1,
                            ProjectName = "E-Commerce Website",
                            StartDate = new DateTime(2025, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            ProjectId = 2,
                            ProjectName = "Mobile Banking App",
                            StartDate = new DateTime(2025, 4, 10, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            ProjectId = 3,
                            ProjectName = "SEO Campaign",
                            StartDate = new DateTime(2025, 5, 15, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            ProjectId = 4,
                            ProjectName = "Cloud Migration",
                            StartDate = new DateTime(2025, 6, 20, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            ProjectId = 5,
                            ProjectName = "Cybersecurity Upgrade",
                            StartDate = new DateTime(2025, 7, 5, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        });
                });

            modelBuilder.Entity("EF_Assignment_6.Models.Entity.Employee", b =>
                {
                    b.HasOne("EF_Assignment_6.Models.Entity.Department", "Department")
                        .WithMany("Employees")
                        .HasForeignKey("DepartmentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Department");
                });

            modelBuilder.Entity("EF_Assignment_6.Models.Entity.EmployeeProject", b =>
                {
                    b.HasOne("EF_Assignment_6.Models.Entity.Employee", "Employee")
                        .WithMany("EmployeeProjects")
                        .HasForeignKey("EmployeeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EF_Assignment_6.Models.Entity.Project", "Project")
                        .WithMany("EmployeeProjects")
                        .HasForeignKey("ProjectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Employee");

                    b.Navigation("Project");
                });

            modelBuilder.Entity("EF_Assignment_6.Models.Entity.Department", b =>
                {
                    b.Navigation("Employees");
                });

            modelBuilder.Entity("EF_Assignment_6.Models.Entity.Employee", b =>
                {
                    b.Navigation("EmployeeProjects");
                });

            modelBuilder.Entity("EF_Assignment_6.Models.Entity.Project", b =>
                {
                    b.Navigation("EmployeeProjects");
                });
#pragma warning restore 612, 618
        }
    }
}
