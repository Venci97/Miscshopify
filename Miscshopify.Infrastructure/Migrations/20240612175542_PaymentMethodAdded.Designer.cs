﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Miscshopify.Infrastructure.Data;

#nullable disable

namespace Miscshopify.Infrastructure.Migrations
{
    [DbContext(typeof(MiscshopifyContext))]
    [Migration("20240612175542_PaymentMethodAdded")]
    partial class PaymentMethodAdded
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);

                    b.HasData(
                        new
                        {
                            Id = "6608f09f-5112-4e35-8451-07bf78b97af5",
                            Name = "Administrator",
                            NormalizedName = "ADMINISTRATOR"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderKey")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);

                    b.HasData(
                        new
                        {
                            UserId = "87a3d0b8-01be-488f-a903-2e424de4b10b",
                            RoleId = "6608f09f-5112-4e35-8451-07bf78b97af5"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Name")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("Miscshopify.Infrastructure.Data.Models.ApplicationUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<int>("Gender")
                        .HasColumnType("int");

                    b.Property<string>("ImagePath")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("PostCode")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers", (string)null);

                    b.HasData(
                        new
                        {
                            Id = "87a3d0b8-01be-488f-a903-2e424de4b10b",
                            AccessFailedCount = 0,
                            Address = "Admin",
                            City = "Admin",
                            ConcurrencyStamp = "9df58699-55da-478f-9752-a89a5f195c86",
                            CreationDate = new DateTime(2024, 6, 12, 18, 55, 38, 369, DateTimeKind.Local).AddTicks(7828),
                            Email = "admin@admin.com",
                            EmailConfirmed = true,
                            FirstName = "Admin",
                            Gender = 1,
                            ImagePath = "uploads/userImg/userPhoto.png",
                            IsActive = true,
                            LastName = "Admin",
                            LockoutEnabled = false,
                            NormalizedEmail = "ADMIN@ADMIN.COM",
                            NormalizedUserName = "ADMIN@ADMIN.COM",
                            PasswordHash = "AQAAAAIAAYagAAAAEMdauLlame1rJ5wIHi7nwmKWBRH1Gkyp0LA+BYPzwdZYbfJzhfdR408GnJvjSr4Ibg==",
                            PhoneNumber = "1234567890",
                            PhoneNumberConfirmed = false,
                            PostCode = "1234",
                            SecurityStamp = "09efc767-4ea2-4001-b66e-90c7796cd424",
                            TwoFactorEnabled = false,
                            UserName = "admin@admin.com"
                        });
                });

            modelBuilder.Entity("Miscshopify.Infrastructure.Data.Models.Cart", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("CustomerId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Carts");
                });

            modelBuilder.Entity("Miscshopify.Infrastructure.Data.Models.CartItem", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int?>("CartId")
                        .HasColumnType("int");

                    b.Property<string>("CustomerId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImagePath")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("ProductID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("ProductName")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<decimal>("UnitPrice")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("CartId");

                    b.ToTable("CartItem");
                });

            modelBuilder.Entity("Miscshopify.Infrastructure.Data.Models.Category", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<string>("ImagePath")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            Id = new Guid("266a6cbb-56cd-4500-efd8-08dadfcbf404"),
                            Description = "All New Android and IOS phones",
                            ImagePath = "uploads/categoryImg/f02bef4482dc4cc9bc8de673601224bc.jfif",
                            Name = "Phones"
                        },
                        new
                        {
                            Id = new Guid("be2ed17b-0c49-4a87-4db8-08dae039c34b"),
                            Description = "All new brands Laptops",
                            ImagePath = "uploads/categoryImg/bac73bf3eded4024a2995334e5d1f22f.jpg",
                            Name = "Laptops"
                        },
                        new
                        {
                            Id = new Guid("cf06817a-292e-458d-4db9-08dae039c34b"),
                            Description = "Bring the cinema into your home",
                            ImagePath = "uploads/categoryImg/4c513095d9a14724af468f5b942f7d81.jpg",
                            Name = "Tv"
                        },
                        new
                        {
                            Id = new Guid("a7d777ad-9b16-48be-4dba-08dae039c34b"),
                            Description = "Choose your gaming PC and run every new games.",
                            ImagePath = "uploads/categoryImg/ccd5063b68cf4a9ca2cb2f8f3cb532fd.jpg",
                            Name = "PC"
                        },
                        new
                        {
                            Id = new Guid("0a681278-e942-47f9-0c19-08dae1128df6"),
                            Description = "We have all kind of clothes just choose from newest and fasionable clothes, or what you like.",
                            ImagePath = "uploads/categoryImg/01f40465ed9148c693aab57c06394621.jpeg",
                            Name = "Clothes"
                        });
                });

            modelBuilder.Entity("Miscshopify.Infrastructure.Data.Models.Order", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CustomerName")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<int>("PaymentMethod")
                        .HasColumnType("int");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("Miscshopify.Infrastructure.Data.Models.OrderItem", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CustomerId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImagePath")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("OrderId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<Guid>("ProductId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("ProductName")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("OrderId");

                    b.ToTable("OrderItem");
                });

            modelBuilder.Entity("Miscshopify.Infrastructure.Data.Models.Product", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CategoryId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<string>("ImagePath")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            Id = new Guid("ab40e33a-24d3-47d4-b570-08dadfcc0e2c"),
                            CategoryId = new Guid("266a6cbb-56cd-4500-efd8-08dadfcbf404"),
                            Description = "8GB RAM 256GB ROM. 108MP Triple camera.CPU: Qualcomm® Kryo™ 660,Octa-core,up to 2.2HzGPU: Qualcomm® Adreno™ 619. 5000 mAh Battery.",
                            ImagePath = "uploads/productImg/54a276f14b3c44e6ae7f51d02ba7e1af.webp",
                            IsActive = true,
                            Name = "Xiaomi POCO X4 PRO 5G",
                            Price = 599.99m
                        },
                        new
                        {
                            Id = new Guid("8747cde3-f434-45ee-389f-08dadfe174ee"),
                            CategoryId = new Guid("266a6cbb-56cd-4500-efd8-08dadfcbf404"),
                            Description = "8GB RAM 128GB ROM.",
                            ImagePath = "uploads/productImg/0007a5a4edb44fe4a91dcc59d1f0410e.jpg",
                            IsActive = true,
                            Name = "Nothing Phone 1",
                            Price = 799.99m
                        },
                        new
                        {
                            Id = new Guid("b4b4eaf9-0a08-45c8-d150-08dae03a344b"),
                            CategoryId = new Guid("be2ed17b-0c49-4a87-4db8-08dae039c34b"),
                            Description = "Notebook with AMD FX-7500 Radeon R7, 10 Compute Cores 4C + 6G, 2.10Ghz with 3.30Ghz in turbo mode with 2GB Dedicated videocard - Radeon R5 m260DX",
                            ImagePath = "uploads/productImg/930aef3d621b4f7ebc6a59a248ef0db9.jpg",
                            IsActive = true,
                            Name = "Lenovo Z50-75",
                            Price = 799.99m
                        },
                        new
                        {
                            Id = new Guid("d4796ccb-b909-468b-135a-08dae0fd13bc"),
                            CategoryId = new Guid("be2ed17b-0c49-4a87-4db8-08dae039c34b"),
                            Description = "Intel Pentium T4400 (2.20GHz, 1MB L2 cache, 800MHz FSB). RAM 4GB (2x2048MB) DDR 2 800Mhz. ROM 500GB SATA 5400 rpm",
                            ImagePath = "uploads/productImg/36adca4afd4b4368bcf590774f5b5660.jpg",
                            IsActive = true,
                            Name = "Dell Inspiron 1545 15.6 Inch",
                            Price = 1009.99m
                        },
                        new
                        {
                            Id = new Guid("3b188390-8db6-4783-135b-08dae0fd13bc"),
                            CategoryId = new Guid("cf06817a-292e-458d-4db9-08dae039c34b"),
                            Description = "Finding is better than searching. So customise your Android TV home screen to show you exactly the apps, films, and shows you want to watch. Now you can continue watching movies after interruptions, start new episodes or jump to another show without having to go back and forth. Everything is really easy with your go-to app.",
                            ImagePath = "uploads/productImg/dac30fa37ac348a893f97c94b74f2bcb.webp",
                            IsActive = true,
                            Name = "Sharp Aquos 50 Inch",
                            Price = 729.99m
                        },
                        new
                        {
                            Id = new Guid("9086399c-0be5-42ff-135c-08dae0fd13bc"),
                            CategoryId = new Guid("cf06817a-292e-458d-4db9-08dae039c34b"),
                            Description = "Choosing your next TV just got easy. When you're looking for superb picture and sound, easy connectivity and responsive, hassle-free gaming—you're looking for The One. Plus you get Ambilight for an immersive experience like no other.",
                            ImagePath = "uploads/productImg/4660f20a482942a28ab64fd2295ce8eb.jpg",
                            IsActive = true,
                            Name = "Phillips 4K UHD LED Android TV",
                            Price = 1599.99m
                        },
                        new
                        {
                            Id = new Guid("ceac6396-3da0-4944-135d-08dae0fd13bc"),
                            CategoryId = new Guid("a7d777ad-9b16-48be-4dba-08dae039c34b"),
                            Description = "AMD Ryzen 9 3900X 3.8GHz, RTX 3090 24GB, 32GB 3600mhz RGB Memory, 1TB Gen4 SSD, 360mm AIO",
                            ImagePath = "CEAC6396-3DA0-4944-135D-08DAE0FD13BC",
                            IsActive = true,
                            Name = "Skytech Prism II Gaming PC Desktop",
                            Price = 2099.99m
                        },
                        new
                        {
                            Id = new Guid("5709db41-e129-490b-135e-08dae0fd13bc"),
                            CategoryId = new Guid("a7d777ad-9b16-48be-4dba-08dae039c34b"),
                            Description = "I7-3770 3.4GHz,GTX 1050TI 4GB GPU,16GB DDR3 RAM,256GB NVME M.2 SSD,1TB HDD,500W PSU,LEGEND ARGB CASE,600Mbps WiFi,Windows 10",
                            ImagePath = "uploads/productImg/cd047469af474a5887904f8f2b99a8d8.jpg",
                            IsActive = true,
                            Name = "XUM Gaming PC Desktop Computer",
                            Price = 1699.99m
                        },
                        new
                        {
                            Id = new Guid("8355a0dd-a683-42ae-135f-08dae0fd13bc"),
                            CategoryId = new Guid("0a681278-e942-47f9-0c19-08dae1128df6"),
                            Description = "T-Shirt with cool graffity",
                            ImagePath = "uploads/productImg/dd5ff5b4634448cd9f519045bdcdd49e.jpeg",
                            IsActive = true,
                            Name = "Nerd T-Shirt",
                            Price = 20.99m
                        },
                        new
                        {
                            Id = new Guid("df12aeb6-18be-4385-1360-08dae0fd13bc"),
                            CategoryId = new Guid("0a681278-e942-47f9-0c19-08dae1128df6"),
                            Description = "Cool Shirt",
                            ImagePath = "uploads/productImg/6f21e499fabd46a8bf30072cc91a2c82.webp",
                            IsActive = true,
                            Name = "Shirt with Graffiti",
                            Price = 21.99m
                        },
                        new
                        {
                            Id = new Guid("56532f98-112b-474a-1361-08dae0fd13bc"),
                            CategoryId = new Guid("0a681278-e942-47f9-0c19-08dae1128df6"),
                            Description = "Cool black Jeans",
                            ImagePath = "uploads/productImg/e5ed61b227b246aab73c600bcd4229f5.gif",
                            IsActive = true,
                            Name = "Black Jeans",
                            Price = 45.99m
                        },
                        new
                        {
                            Id = new Guid("6468f6ad-5de5-4a34-1362-08dae0fd13bc"),
                            CategoryId = new Guid("0a681278-e942-47f9-0c19-08dae1128df6"),
                            Description = "Cool Green Shoes",
                            ImagePath = "uploads/productImg/05dd0ffaa4304479829228080a078ad2.jpg",
                            IsActive = true,
                            Name = "Green Shoes",
                            Price = 57.99m
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Miscshopify.Infrastructure.Data.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Miscshopify.Infrastructure.Data.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Miscshopify.Infrastructure.Data.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Miscshopify.Infrastructure.Data.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Miscshopify.Infrastructure.Data.Models.CartItem", b =>
                {
                    b.HasOne("Miscshopify.Infrastructure.Data.Models.Cart", null)
                        .WithMany("Items")
                        .HasForeignKey("CartId");
                });

            modelBuilder.Entity("Miscshopify.Infrastructure.Data.Models.Order", b =>
                {
                    b.HasOne("Miscshopify.Infrastructure.Data.Models.ApplicationUser", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("Miscshopify.Infrastructure.Data.Models.OrderItem", b =>
                {
                    b.HasOne("Miscshopify.Infrastructure.Data.Models.Order", "Order")
                        .WithMany("Items")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Order");
                });

            modelBuilder.Entity("Miscshopify.Infrastructure.Data.Models.Product", b =>
                {
                    b.HasOne("Miscshopify.Infrastructure.Data.Models.Category", "Category")
                        .WithMany("Products")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");
                });

            modelBuilder.Entity("Miscshopify.Infrastructure.Data.Models.Cart", b =>
                {
                    b.Navigation("Items");
                });

            modelBuilder.Entity("Miscshopify.Infrastructure.Data.Models.Category", b =>
                {
                    b.Navigation("Products");
                });

            modelBuilder.Entity("Miscshopify.Infrastructure.Data.Models.Order", b =>
                {
                    b.Navigation("Items");
                });
#pragma warning restore 612, 618
        }
    }
}