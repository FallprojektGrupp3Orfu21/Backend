﻿// <auto-generated />
using System;
using DAL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DAL.Migrations
{
    [DbContext(typeof(EconomiqContext))]
    [Migration("20220215105045_TestForPresentation")]
    partial class TestForPresentation
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("DAL.Models.Email", b =>
                {
                    b.Property<int>("UserNavId")
                        .HasColumnType("int");

                    b.Property<string>("Mail")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserNavId", "Mail");

                    b.ToTable("Email");

                    b.HasData(
                        new
                        {
                            UserNavId = 1,
                            Mail = "JuliaH@test.com"
                        },
                        new
                        {
                            UserNavId = 2,
                            Mail = "AlexV@test.com"
                        },
                        new
                        {
                            UserNavId = 3,
                            Mail = "Peppo@test.com"
                        },
                        new
                        {
                            UserNavId = 4,
                            Mail = "WinnieH@test.com"
                        },
                        new
                        {
                            UserNavId = 5,
                            Mail = "Ericx@test.com"
                        },
                        new
                        {
                            UserNavId = 6,
                            Mail = "AndersB@test.com"
                        },
                        new
                        {
                            UserNavId = 7,
                            Mail = "PeterH@test.com"
                        });
                });

            modelBuilder.Entity("DAL.Models.Expense", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<decimal>("Amount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int?>("CategoryNavId")
                        .HasColumnType("int");

                    b.Property<string>("Comment")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("ExpenseDate")
                        .HasColumnType("datetime2");

                    b.Property<int?>("RecipientId")
                        .HasColumnType("int");

                    b.Property<int>("UserNavId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CategoryNavId");

                    b.HasIndex("RecipientId");

                    b.HasIndex("UserNavId");

                    b.ToTable("Expenses");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Amount = 25m,
                            CategoryNavId = 2,
                            Comment = "Glass",
                            CreationDate = new DateTime(2022, 2, 15, 11, 50, 44, 895, DateTimeKind.Local).AddTicks(4698),
                            ExpenseDate = new DateTime(2022, 2, 15, 11, 50, 44, 895, DateTimeKind.Local).AddTicks(4703),
                            UserNavId = 1
                        });
                });

            modelBuilder.Entity("DAL.Models.ExpenseCategory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("CategoryName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("ExpensesCategory");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CategoryName = "Rent",
                            CreationDate = new DateTime(2022, 2, 15, 11, 50, 44, 895, DateTimeKind.Local).AddTicks(4599)
                        },
                        new
                        {
                            Id = 2,
                            CategoryName = "Food",
                            CreationDate = new DateTime(2022, 2, 15, 11, 50, 44, 895, DateTimeKind.Local).AddTicks(4607)
                        },
                        new
                        {
                            Id = 3,
                            CategoryName = "Transport",
                            CreationDate = new DateTime(2022, 2, 15, 11, 50, 44, 895, DateTimeKind.Local).AddTicks(4612)
                        },
                        new
                        {
                            Id = 4,
                            CategoryName = "Clothing",
                            CreationDate = new DateTime(2022, 2, 15, 11, 50, 44, 895, DateTimeKind.Local).AddTicks(4616)
                        },
                        new
                        {
                            Id = 5,
                            CategoryName = "Entertainment",
                            CreationDate = new DateTime(2022, 2, 15, 11, 50, 44, 895, DateTimeKind.Local).AddTicks(4620)
                        });
                });

            modelBuilder.Entity("DAL.Models.Recipient", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserNavId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserNavId");

                    b.ToTable("Recipients");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            City = "Örebro",
                            Name = "ICA",
                            UserNavId = 1
                        },
                        new
                        {
                            Id = 2,
                            City = "Stockholm",
                            Name = "H&M",
                            UserNavId = 5
                        },
                        new
                        {
                            Id = 3,
                            City = "Göteborg",
                            Name = "Alfred",
                            UserNavId = 3
                        },
                        new
                        {
                            Id = 4,
                            City = "Örebro",
                            Name = "Hanna",
                            UserNavId = 4
                        },
                        new
                        {
                            Id = 5,
                            City = "Nora",
                            Name = "ICA",
                            UserNavId = 7
                        },
                        new
                        {
                            Id = 6,
                            City = "Morgongåva",
                            Name = "Coop",
                            UserNavId = 7
                        });
                });

            modelBuilder.Entity("DAL.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Fname")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Gender")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsLoggedIn")
                        .HasColumnType("bit");

                    b.Property<string>("Lname")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            City = "Orebro",
                            CreationDate = new DateTime(2022, 2, 15, 11, 50, 44, 895, DateTimeKind.Local).AddTicks(4205),
                            Fname = "Julia",
                            Gender = "Female",
                            IsLoggedIn = false,
                            Lname = "Hook",
                            Password = "Testing123",
                            UserName = "JuliaH"
                        },
                        new
                        {
                            Id = 2,
                            City = "Orebro",
                            CreationDate = new DateTime(2022, 2, 15, 11, 50, 44, 895, DateTimeKind.Local).AddTicks(4262),
                            Fname = "Alexander",
                            Gender = "Male",
                            IsLoggedIn = false,
                            Lname = "Volonen",
                            Password = "Testing234",
                            UserName = "AlexV"
                        },
                        new
                        {
                            Id = 3,
                            City = "Orebro",
                            CreationDate = new DateTime(2022, 2, 15, 11, 50, 44, 895, DateTimeKind.Local).AddTicks(4268),
                            Fname = "Stefan",
                            Gender = "Male",
                            IsLoggedIn = false,
                            Lname = "Krakowsky",
                            Password = "Testing345",
                            UserName = "Peppo"
                        },
                        new
                        {
                            Id = 4,
                            City = "Orebro",
                            CreationDate = new DateTime(2022, 2, 15, 11, 50, 44, 895, DateTimeKind.Local).AddTicks(4272),
                            Fname = "Winnie",
                            Gender = "Female",
                            IsLoggedIn = false,
                            Lname = "Huynh",
                            Password = "Testing456",
                            UserName = "WinnieH"
                        },
                        new
                        {
                            Id = 5,
                            City = "Orebro",
                            CreationDate = new DateTime(2022, 2, 15, 11, 50, 44, 895, DateTimeKind.Local).AddTicks(4277),
                            Fname = "Eric",
                            Gender = "Male",
                            IsLoggedIn = false,
                            Lname = "Flodin",
                            Password = "Testing567",
                            UserName = "Ericx"
                        },
                        new
                        {
                            Id = 6,
                            City = "Fjugesta",
                            CreationDate = new DateTime(2022, 2, 15, 11, 50, 44, 895, DateTimeKind.Local).AddTicks(4282),
                            Fname = "Anders",
                            Gender = "Male",
                            IsLoggedIn = false,
                            Lname = "Bergstrom",
                            Password = "Testing678",
                            UserName = "AndersB"
                        },
                        new
                        {
                            Id = 7,
                            City = "Orebro",
                            CreationDate = new DateTime(2022, 2, 15, 11, 50, 44, 895, DateTimeKind.Local).AddTicks(4287),
                            Fname = "Peter",
                            Gender = "Male",
                            IsLoggedIn = false,
                            Lname = "Hafid",
                            Password = "Testing789",
                            UserName = "PeterH"
                        });
                });

            modelBuilder.Entity("ExpenseCategoryUser", b =>
                {
                    b.Property<int>("ExpensesCategoryNavId")
                        .HasColumnType("int");

                    b.Property<int>("UserNavId")
                        .HasColumnType("int");

                    b.HasKey("ExpensesCategoryNavId", "UserNavId");

                    b.HasIndex("UserNavId");

                    b.ToTable("ExpenseCategoryUser");

                    b.HasData(
                        new
                        {
                            ExpensesCategoryNavId = 1,
                            UserNavId = 1
                        },
                        new
                        {
                            ExpensesCategoryNavId = 1,
                            UserNavId = 2
                        },
                        new
                        {
                            ExpensesCategoryNavId = 1,
                            UserNavId = 3
                        },
                        new
                        {
                            ExpensesCategoryNavId = 1,
                            UserNavId = 4
                        },
                        new
                        {
                            ExpensesCategoryNavId = 1,
                            UserNavId = 5
                        },
                        new
                        {
                            ExpensesCategoryNavId = 1,
                            UserNavId = 6
                        },
                        new
                        {
                            ExpensesCategoryNavId = 1,
                            UserNavId = 7
                        },
                        new
                        {
                            ExpensesCategoryNavId = 2,
                            UserNavId = 1
                        },
                        new
                        {
                            ExpensesCategoryNavId = 2,
                            UserNavId = 2
                        },
                        new
                        {
                            ExpensesCategoryNavId = 2,
                            UserNavId = 3
                        },
                        new
                        {
                            ExpensesCategoryNavId = 2,
                            UserNavId = 4
                        },
                        new
                        {
                            ExpensesCategoryNavId = 2,
                            UserNavId = 5
                        },
                        new
                        {
                            ExpensesCategoryNavId = 2,
                            UserNavId = 6
                        },
                        new
                        {
                            ExpensesCategoryNavId = 2,
                            UserNavId = 7
                        },
                        new
                        {
                            ExpensesCategoryNavId = 3,
                            UserNavId = 1
                        },
                        new
                        {
                            ExpensesCategoryNavId = 3,
                            UserNavId = 2
                        },
                        new
                        {
                            ExpensesCategoryNavId = 3,
                            UserNavId = 3
                        },
                        new
                        {
                            ExpensesCategoryNavId = 3,
                            UserNavId = 4
                        },
                        new
                        {
                            ExpensesCategoryNavId = 3,
                            UserNavId = 5
                        },
                        new
                        {
                            ExpensesCategoryNavId = 3,
                            UserNavId = 6
                        },
                        new
                        {
                            ExpensesCategoryNavId = 3,
                            UserNavId = 7
                        },
                        new
                        {
                            ExpensesCategoryNavId = 4,
                            UserNavId = 1
                        },
                        new
                        {
                            ExpensesCategoryNavId = 4,
                            UserNavId = 2
                        },
                        new
                        {
                            ExpensesCategoryNavId = 4,
                            UserNavId = 3
                        },
                        new
                        {
                            ExpensesCategoryNavId = 4,
                            UserNavId = 4
                        },
                        new
                        {
                            ExpensesCategoryNavId = 4,
                            UserNavId = 5
                        },
                        new
                        {
                            ExpensesCategoryNavId = 4,
                            UserNavId = 6
                        },
                        new
                        {
                            ExpensesCategoryNavId = 4,
                            UserNavId = 7
                        },
                        new
                        {
                            ExpensesCategoryNavId = 5,
                            UserNavId = 1
                        },
                        new
                        {
                            ExpensesCategoryNavId = 5,
                            UserNavId = 2
                        },
                        new
                        {
                            ExpensesCategoryNavId = 5,
                            UserNavId = 3
                        },
                        new
                        {
                            ExpensesCategoryNavId = 5,
                            UserNavId = 4
                        },
                        new
                        {
                            ExpensesCategoryNavId = 5,
                            UserNavId = 5
                        },
                        new
                        {
                            ExpensesCategoryNavId = 5,
                            UserNavId = 6
                        },
                        new
                        {
                            ExpensesCategoryNavId = 5,
                            UserNavId = 7
                        });
                });

            modelBuilder.Entity("DAL.Models.Email", b =>
                {
                    b.HasOne("DAL.Models.User", "UserNav")
                        .WithMany("Emails")
                        .HasForeignKey("UserNavId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("UserNav");
                });

            modelBuilder.Entity("DAL.Models.Expense", b =>
                {
                    b.HasOne("DAL.Models.ExpenseCategory", "CategoryNav")
                        .WithMany("ExpensesNav")
                        .HasForeignKey("CategoryNavId")
                        .OnDelete(DeleteBehavior.NoAction);

                    b.HasOne("DAL.Models.Recipient", "Recipient")
                        .WithMany()
                        .HasForeignKey("RecipientId");

                    b.HasOne("DAL.Models.User", "UserNav")
                        .WithMany("UserExpensesNav")
                        .HasForeignKey("UserNavId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CategoryNav");

                    b.Navigation("Recipient");

                    b.Navigation("UserNav");
                });

            modelBuilder.Entity("DAL.Models.Recipient", b =>
                {
                    b.HasOne("DAL.Models.User", "UserNav")
                        .WithMany("RecipientNav")
                        .HasForeignKey("UserNavId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("UserNav");
                });

            modelBuilder.Entity("ExpenseCategoryUser", b =>
                {
                    b.HasOne("DAL.Models.ExpenseCategory", null)
                        .WithMany()
                        .HasForeignKey("ExpensesCategoryNavId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DAL.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UserNavId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("DAL.Models.ExpenseCategory", b =>
                {
                    b.Navigation("ExpensesNav");
                });

            modelBuilder.Entity("DAL.Models.User", b =>
                {
                    b.Navigation("Emails");

                    b.Navigation("RecipientNav");

                    b.Navigation("UserExpensesNav");
                });
#pragma warning restore 612, 618
        }
    }
}
