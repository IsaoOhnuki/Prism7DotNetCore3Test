﻿// <auto-generated />
using System;
using DBMaigration;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DBMaigration.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.13")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ModelLibrary.Models.Database.MProduct", b =>
                {
                    b.Property<int>("MProductId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Optimist")
                        .HasColumnType("datetime2");

                    b.Property<string>("ProductMemo")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("ProductName")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<decimal>("ProductPrice")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("ProductPriceType")
                        .HasColumnType("int");

                    b.Property<string>("ProductShortName")
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.HasKey("MProductId");

                    b.ToTable("MProduct");
                });

            modelBuilder.Entity("ModelLibrary.Models.Database.TCustomer", b =>
                {
                    b.Property<int>("TCustomerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CustomerMemo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CustomerMemo1")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.Property<string>("MiddleName")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.Property<DateTime>("Optimist")
                        .HasColumnType("datetime2");

                    b.HasKey("TCustomerId");

                    b.ToTable("TCustomer");
                });

            modelBuilder.Entity("ModelLibrary.Models.Database.TProduct", b =>
                {
                    b.Property<int>("TProductId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("MProductId")
                        .HasColumnType("int");

                    b.Property<DateTime>("Optimist")
                        .HasColumnType("datetime2");

                    b.Property<string>("ProductMemo")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("ProductName")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<decimal>("ProductPrice")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("ProductPriceType")
                        .HasColumnType("int");

                    b.Property<string>("ProductShortName")
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.Property<int>("TReserveId")
                        .HasColumnType("int");

                    b.HasKey("TProductId");

                    b.ToTable("TProduct");
                });

            modelBuilder.Entity("ModelLibrary.Models.Database.TReserve", b =>
                {
                    b.Property<int>("ReserveId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("BlockEnd")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("BlockStart")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("Optimist")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("ReserveEnd")
                        .HasColumnType("datetime2");

                    b.Property<string>("ReserveMemo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ReserveMemo1")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<DateTime>("ReserveStart")
                        .HasColumnType("datetime2");

                    b.Property<int>("State")
                        .HasColumnType("int");

                    b.HasKey("ReserveId");

                    b.ToTable("TReserve");
                });
#pragma warning restore 612, 618
        }
    }
}