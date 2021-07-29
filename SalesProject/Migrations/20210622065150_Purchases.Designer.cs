﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SalesProject.DAL.Database;

namespace SalesProject.Migrations
{
    [DbContext(typeof(DbContainer))]
    [Migration("20210622065150_Purchases")]
    partial class Purchases
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.7")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("SalesProject.DAL.Entities.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CategoryName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhotoName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Category");
                });

            modelBuilder.Entity("SalesProject.DAL.Entities.Purchases", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<string>("PurchaseDetails")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PurchaseName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<float>("PurchaseQuantity")
                        .HasColumnType("real");

                    b.Property<float>("PurchasesTotalPrice")
                        .HasColumnType("real");

                    b.Property<float>("PurchasingPrice")
                        .HasColumnType("real");

                    b.Property<float>("SalesTotalPrice")
                        .HasColumnType("real");

                    b.Property<float>("SellingPrice")
                        .HasColumnType("real");

                    b.Property<int>("SupplierId")
                        .HasColumnType("int");

                    b.Property<float>("TotalProfit")
                        .HasColumnType("real");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.HasIndex("SupplierId");

                    b.ToTable("Purchases");
                });

            modelBuilder.Entity("SalesProject.DAL.Entities.Supplier", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SupplierName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Supplier");
                });

            modelBuilder.Entity("SalesProject.DAL.Entities.Purchases", b =>
                {
                    b.HasOne("SalesProject.DAL.Entities.Category", "Category")
                        .WithMany("Purchases")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SalesProject.DAL.Entities.Supplier", "Supplier")
                        .WithMany("Purchases")
                        .HasForeignKey("SupplierId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");

                    b.Navigation("Supplier");
                });

            modelBuilder.Entity("SalesProject.DAL.Entities.Category", b =>
                {
                    b.Navigation("Purchases");
                });

            modelBuilder.Entity("SalesProject.DAL.Entities.Supplier", b =>
                {
                    b.Navigation("Purchases");
                });
#pragma warning restore 612, 618
        }
    }
}
