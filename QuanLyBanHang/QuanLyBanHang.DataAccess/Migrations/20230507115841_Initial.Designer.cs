﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using QuanLyBanHang.DataAccess;

#nullable disable

namespace QuanLyBanHang.DataAccess.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20230507115841_Initial")]
    partial class Initial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
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
                            Id = "133f85fc-3e0c-4bd0-a820-d379c0bf9dc5",
                            Name = "Admin",
                            NormalizedName = "ADMIN"
                        },
                        new
                        {
                            Id = "13ae282b-4fbc-49e6-8deb-4a5e4e8bb130",
                            Name = "Manager",
                            NormalizedName = "MANAGER"
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

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

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
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

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
                            Id = "f139186b-6419-4cb1-8c80-32755a3f7c01",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "bfd9e814-c807-4f00-8004-41e3d6dce1f2",
                            Email = "nvt@gmail.com",
                            EmailConfirmed = false,
                            LockoutEnabled = false,
                            NormalizedEmail = "NVT@GMAIL.COM",
                            NormalizedUserName = "VANTIN",
                            PasswordHash = "AQAAAAIAAYagAAAAEFlTA3AwcuF3rrweD6Ni8TtyL15Yd04+YDk3NebyFh7zv6u6S5A8/Bkfus8xPOYTyw==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "510e0ee8-f407-44ab-964b-9e5ad8fdc8aa",
                            TwoFactorEnabled = false,
                            UserName = "VanTin"
                        });
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
                            UserId = "f139186b-6419-4cb1-8c80-32755a3f7c01",
                            RoleId = "133f85fc-3e0c-4bd0-a820-d379c0bf9dc5"
                        },
                        new
                        {
                            UserId = "f139186b-6419-4cb1-8c80-32755a3f7c01",
                            RoleId = "13ae282b-4fbc-49e6-8deb-4a5e4e8bb130"
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

            modelBuilder.Entity("QuanLyBanHang.Entity.Cart", b =>
                {
                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("CustomernameofUser")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<int>("proId")
                        .HasColumnType("int");

                    b.Property<string>("proImage")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("proName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("proPrice")
                        .HasColumnType("bigint");

                    b.HasKey("UserName");

                    b.HasIndex("CustomernameofUser");

                    b.ToTable("Carts");
                });

            modelBuilder.Entity("QuanLyBanHang.Entity.Customer", b =>
                {
                    b.Property<string>("nameofUser")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("cusAddress")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("cusEmail")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("cusFullName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("cusGender")
                        .HasColumnType("int");

                    b.Property<string>("cusPhone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("paymentMethod")
                        .HasColumnType("int");

                    b.HasKey("nameofUser");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("QuanLyBanHang.Entity.Order", b =>
                {
                    b.Property<int>("orderID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("orderID"));

                    b.Property<string>("CustomernameofUser")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("cusAddress")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("cusPhone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("orderDateTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("orderMessage")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("orderStatus")
                        .HasColumnType("int");

                    b.Property<long>("orderTotal")
                        .HasColumnType("bigint");

                    b.HasKey("orderID");

                    b.HasIndex("CustomernameofUser");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("QuanLyBanHang.Entity.OrderDetail", b =>
                {
                    b.Property<int>("orderID")
                        .HasColumnType("int");

                    b.Property<int>("proID")
                        .HasColumnType("int");

                    b.Property<long>("ordtsItemPrice")
                        .HasColumnType("bigint");

                    b.Property<int>("ordtsQuantity")
                        .HasColumnType("int");

                    b.Property<long>("ordtsTotal")
                        .HasColumnType("bigint");

                    b.HasKey("orderID", "proID");

                    b.HasIndex("orderID")
                        .IsUnique();

                    b.ToTable("OrderDetails");
                });

            modelBuilder.Entity("QuanLyBanHang.Entity.Product", b =>
                {
                    b.Property<int>("proID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("proID"));

                    b.Property<string>("ImageUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("OrderDetailorderID")
                        .HasColumnType("int");

                    b.Property<int?>("OrderDetailproID")
                        .HasColumnType("int");

                    b.Property<string>("Producer")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<float?>("Rate")
                        .HasColumnType("real");

                    b.Property<int>("forGender")
                        .HasColumnType("int");

                    b.Property<int?>("pdcID")
                        .HasColumnType("int");

                    b.Property<string>("proDescription")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("proDiscount")
                        .HasColumnType("int");

                    b.Property<string>("proName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("proPrice")
                        .HasColumnType("bigint");

                    b.Property<string>("proSize")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("proStatus")
                        .HasColumnType("int");

                    b.Property<DateTime>("proUpdateDate")
                        .HasColumnType("datetime2");

                    b.Property<int?>("typeID")
                        .HasColumnType("int");

                    b.HasKey("proID");

                    b.HasIndex("OrderDetailorderID", "OrderDetailproID");

                    b.ToTable("Products");
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
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
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

                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("QuanLyBanHang.Entity.Cart", b =>
                {
                    b.HasOne("QuanLyBanHang.Entity.Customer", "Customer")
                        .WithMany()
                        .HasForeignKey("CustomernameofUser");

                    b.Navigation("Customer");
                });

            modelBuilder.Entity("QuanLyBanHang.Entity.Order", b =>
                {
                    b.HasOne("QuanLyBanHang.Entity.Customer", "Customer")
                        .WithMany("OrderList")
                        .HasForeignKey("CustomernameofUser");

                    b.Navigation("Customer");
                });

            modelBuilder.Entity("QuanLyBanHang.Entity.OrderDetail", b =>
                {
                    b.HasOne("QuanLyBanHang.Entity.Order", "Order")
                        .WithOne("OrderDetails")
                        .HasForeignKey("QuanLyBanHang.Entity.OrderDetail", "orderID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Order");
                });

            modelBuilder.Entity("QuanLyBanHang.Entity.Product", b =>
                {
                    b.HasOne("QuanLyBanHang.Entity.OrderDetail", null)
                        .WithMany("Product")
                        .HasForeignKey("OrderDetailorderID", "OrderDetailproID");
                });

            modelBuilder.Entity("QuanLyBanHang.Entity.Customer", b =>
                {
                    b.Navigation("OrderList");
                });

            modelBuilder.Entity("QuanLyBanHang.Entity.Order", b =>
                {
                    b.Navigation("OrderDetails")
                        .IsRequired();
                });

            modelBuilder.Entity("QuanLyBanHang.Entity.OrderDetail", b =>
                {
                    b.Navigation("Product");
                });
#pragma warning restore 612, 618
        }
    }
}