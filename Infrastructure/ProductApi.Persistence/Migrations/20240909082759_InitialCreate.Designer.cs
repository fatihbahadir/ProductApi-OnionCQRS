﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ProductApi.Persistence.Context;

#nullable disable

namespace ProductApi.Persistence.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20240909082759_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("CategoryProduct", b =>
                {
                    b.Property<int>("CategoriesId")
                        .HasColumnType("int");

                    b.Property<int>("ProductsId")
                        .HasColumnType("int");

                    b.HasKey("CategoriesId", "ProductsId");

                    b.HasIndex("ProductsId");

                    b.ToTable("CategoryProduct");
                });

            modelBuilder.Entity("ProductApi.Domain.Entities.Brand", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.ToTable("Brands");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CreatedDate = new DateTime(2024, 9, 9, 11, 27, 59, 333, DateTimeKind.Local).AddTicks(3887),
                            IsDeleted = false,
                            Name = "Kids & Shoes"
                        },
                        new
                        {
                            Id = 2,
                            CreatedDate = new DateTime(2024, 9, 9, 11, 27, 59, 333, DateTimeKind.Local).AddTicks(4027),
                            IsDeleted = false,
                            Name = "Beauty & Movies"
                        },
                        new
                        {
                            Id = 3,
                            CreatedDate = new DateTime(2024, 9, 9, 11, 27, 59, 333, DateTimeKind.Local).AddTicks(4043),
                            IsDeleted = true,
                            Name = "Jewelery"
                        });
                });

            modelBuilder.Entity("ProductApi.Domain.Entities.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ParentId")
                        .HasColumnType("int");

                    b.Property<int>("Priority")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CreatedDate = new DateTime(2024, 9, 9, 11, 27, 59, 333, DateTimeKind.Local).AddTicks(8055),
                            IsDeleted = false,
                            Name = "Elektrik",
                            ParentId = 0,
                            Priority = 1
                        },
                        new
                        {
                            Id = 2,
                            CreatedDate = new DateTime(2024, 9, 9, 11, 27, 59, 333, DateTimeKind.Local).AddTicks(8056),
                            IsDeleted = false,
                            Name = "Moda",
                            ParentId = 0,
                            Priority = 2
                        },
                        new
                        {
                            Id = 3,
                            CreatedDate = new DateTime(2024, 9, 9, 11, 27, 59, 333, DateTimeKind.Local).AddTicks(8058),
                            IsDeleted = false,
                            Name = "Bilgisayar",
                            ParentId = 1,
                            Priority = 1
                        },
                        new
                        {
                            Id = 4,
                            CreatedDate = new DateTime(2024, 9, 9, 11, 27, 59, 333, DateTimeKind.Local).AddTicks(8060),
                            IsDeleted = false,
                            Name = "Kadın",
                            ParentId = 2,
                            Priority = 1
                        });
                });

            modelBuilder.Entity("ProductApi.Domain.Entities.Detail", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("Details");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CategoryId = 1,
                            CreatedDate = new DateTime(2024, 9, 9, 11, 27, 59, 338, DateTimeKind.Local).AddTicks(2077),
                            Description = "Sit koşuyorlar salladı koyun ab.",
                            IsDeleted = false,
                            Title = "Ad."
                        },
                        new
                        {
                            Id = 2,
                            CategoryId = 3,
                            CreatedDate = new DateTime(2024, 9, 9, 11, 27, 59, 338, DateTimeKind.Local).AddTicks(2333),
                            Description = "Sandalye bundan sevindi sed doloremque.",
                            IsDeleted = true,
                            Title = "Consequuntur çobanın."
                        },
                        new
                        {
                            Id = 3,
                            CategoryId = 4,
                            CreatedDate = new DateTime(2024, 9, 9, 11, 27, 59, 338, DateTimeKind.Local).AddTicks(2367),
                            Description = "Ad masanın labore bundan nesciunt.",
                            IsDeleted = false,
                            Title = "Koyun."
                        });
                });

            modelBuilder.Entity("ProductApi.Domain.Entities.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("BrandId")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Discount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("BrandId");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            BrandId = 1,
                            CreatedDate = new DateTime(2024, 9, 9, 11, 27, 59, 341, DateTimeKind.Local).AddTicks(6476),
                            Description = "The Apollotech B340 is an affordable wireless mouse with reliable connectivity, 12 months battery life and modern design",
                            Discount = 1.705362073633350m,
                            IsDeleted = false,
                            Price = 702.54m,
                            Title = "Practical Fresh Ball"
                        },
                        new
                        {
                            Id = 2,
                            BrandId = 3,
                            CreatedDate = new DateTime(2024, 9, 9, 11, 27, 59, 341, DateTimeKind.Local).AddTicks(6505),
                            Description = "The slim & simple Maple Gaming Keyboard from Dev Byte comes with a sleek body and 7- Color RGB LED Back-lighting for smart functionality",
                            Discount = 7.728357075032660m,
                            IsDeleted = false,
                            Price = 678.46m,
                            Title = "Unbranded Rubber Pants"
                        });
                });

            modelBuilder.Entity("CategoryProduct", b =>
                {
                    b.HasOne("ProductApi.Domain.Entities.Category", null)
                        .WithMany()
                        .HasForeignKey("CategoriesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ProductApi.Domain.Entities.Product", null)
                        .WithMany()
                        .HasForeignKey("ProductsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ProductApi.Domain.Entities.Detail", b =>
                {
                    b.HasOne("ProductApi.Domain.Entities.Category", "Category")
                        .WithMany("Details")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");
                });

            modelBuilder.Entity("ProductApi.Domain.Entities.Product", b =>
                {
                    b.HasOne("ProductApi.Domain.Entities.Brand", "Brand")
                        .WithMany()
                        .HasForeignKey("BrandId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Brand");
                });

            modelBuilder.Entity("ProductApi.Domain.Entities.Category", b =>
                {
                    b.Navigation("Details");
                });
#pragma warning restore 612, 618
        }
    }
}
