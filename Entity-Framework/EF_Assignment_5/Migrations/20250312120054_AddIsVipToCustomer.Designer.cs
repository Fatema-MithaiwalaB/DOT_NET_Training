﻿// <auto-generated />
using System;
using EF_Assignment_5.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace EF_Assignment_5.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20250312120054_AddIsVipToCustomer")]
    partial class AddIsVipToCustomer
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("EF_Assignment_5.Models.Entity.Customer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsVIP")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.ToTable("Customers");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CreatedDate = new DateTime(2025, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "john@example.com",
                            IsVIP = true,
                            Name = "John Doe"
                        },
                        new
                        {
                            Id = 2,
                            CreatedDate = new DateTime(2025, 3, 5, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "alice@example.com",
                            IsVIP = false,
                            Name = "Alice Smith"
                        },
                        new
                        {
                            Id = 3,
                            CreatedDate = new DateTime(2025, 2, 15, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "michael@example.com",
                            IsVIP = true,
                            Name = "Michael Johnson"
                        },
                        new
                        {
                            Id = 4,
                            CreatedDate = new DateTime(2025, 1, 20, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "emma@example.com",
                            IsVIP = false,
                            Name = "Emma Brown"
                        },
                        new
                        {
                            Id = 5,
                            CreatedDate = new DateTime(2025, 3, 10, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "olivia@example.com",
                            IsVIP = true,
                            Name = "Olivia Wilson"
                        });
                });

            modelBuilder.Entity("EF_Assignment_5.Models.Entity.Order", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CustomerId")
                        .HasColumnType("int");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<DateTime>("OrderDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("CustomerId");

                    b.ToTable("Orders");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CustomerId = 1,
                            IsDeleted = false,
                            OrderDate = new DateTime(2025, 3, 2, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 2,
                            CustomerId = 2,
                            IsDeleted = false,
                            OrderDate = new DateTime(2025, 3, 8, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 3,
                            CustomerId = 3,
                            IsDeleted = false,
                            OrderDate = new DateTime(2025, 2, 20, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 4,
                            CustomerId = 4,
                            IsDeleted = false,
                            OrderDate = new DateTime(2025, 1, 25, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 5,
                            CustomerId = 5,
                            IsDeleted = false,
                            OrderDate = new DateTime(2025, 3, 12, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        });
                });

            modelBuilder.Entity("EF_Assignment_5.Models.Entity.OrderProduct", b =>
                {
                    b.Property<int>("OrderId")
                        .HasColumnType("int");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.HasKey("OrderId", "ProductId");

                    b.HasIndex("ProductId");

                    b.ToTable("OrderProducts");

                    b.HasData(
                        new
                        {
                            OrderId = 1,
                            ProductId = 1,
                            Id = 0,
                            Quantity = 2
                        },
                        new
                        {
                            OrderId = 1,
                            ProductId = 2,
                            Id = 0,
                            Quantity = 1
                        },
                        new
                        {
                            OrderId = 2,
                            ProductId = 2,
                            Id = 0,
                            Quantity = 3
                        },
                        new
                        {
                            OrderId = 3,
                            ProductId = 3,
                            Id = 0,
                            Quantity = 2
                        },
                        new
                        {
                            OrderId = 4,
                            ProductId = 4,
                            Id = 0,
                            Quantity = 1
                        },
                        new
                        {
                            OrderId = 5,
                            ProductId = 5,
                            Id = 0,
                            Quantity = 4
                        });
                });

            modelBuilder.Entity("EF_Assignment_5.Models.Entity.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("Stock")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Laptop",
                            Price = 1000m,
                            Stock = 50
                        },
                        new
                        {
                            Id = 2,
                            Name = "Phone",
                            Price = 500m,
                            Stock = 30
                        },
                        new
                        {
                            Id = 3,
                            Name = "Tablet",
                            Price = 300m,
                            Stock = 20
                        },
                        new
                        {
                            Id = 4,
                            Name = "Monitor",
                            Price = 250m,
                            Stock = 15
                        },
                        new
                        {
                            Id = 5,
                            Name = "Keyboard",
                            Price = 50m,
                            Stock = 100
                        });
                });

            modelBuilder.Entity("EF_Assignment_5.Models.Entity.Order", b =>
                {
                    b.HasOne("EF_Assignment_5.Models.Entity.Customer", "Customer")
                        .WithMany("Orders")
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Customer");
                });

            modelBuilder.Entity("EF_Assignment_5.Models.Entity.OrderProduct", b =>
                {
                    b.HasOne("EF_Assignment_5.Models.Entity.Order", "Order")
                        .WithMany("OrderProducts")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EF_Assignment_5.Models.Entity.Product", "Product")
                        .WithMany("OrderProducts")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Order");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("EF_Assignment_5.Models.Entity.Customer", b =>
                {
                    b.Navigation("Orders");
                });

            modelBuilder.Entity("EF_Assignment_5.Models.Entity.Order", b =>
                {
                    b.Navigation("OrderProducts");
                });

            modelBuilder.Entity("EF_Assignment_5.Models.Entity.Product", b =>
                {
                    b.Navigation("OrderProducts");
                });
#pragma warning restore 612, 618
        }
    }
}
