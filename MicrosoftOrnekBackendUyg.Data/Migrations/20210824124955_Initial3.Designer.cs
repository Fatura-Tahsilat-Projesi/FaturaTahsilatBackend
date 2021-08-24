﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MicrosoftOrnekBackendUyg.Data;

namespace MicrosoftOrnekBackendUyg.Data.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20210824124955_Initial3")]
    partial class Initial3
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.9")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("MicrosoftOrnekBackendUyg.Core.Models.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:IdentityIncrement", 1)
                        .HasAnnotation("SqlServer:IdentitySeed", 1)
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            IsDeleted = false,
                            Name = "Kalemler"
                        },
                        new
                        {
                            Id = 2,
                            IsDeleted = false,
                            Name = "Defterler"
                        });
                });

            modelBuilder.Entity("MicrosoftOrnekBackendUyg.Core.Models.Fatura", b =>
                {
                    b.Property<int>("FaturaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:IdentityIncrement", 1)
                        .HasAnnotation("SqlServer:IdentitySeed", 1)
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("IsComplete")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("icerik")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("kdvsizfiyat")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("odendi")
                        .HasColumnType("int");

                    b.Property<DateTime>("son_odeme")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("topkdv")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("tutar")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("FaturaId");

                    b.ToTable("Faturalar");

                    b.HasData(
                        new
                        {
                            FaturaId = 1,
                            IsComplete = 0,
                            Name = "Su Faturası",
                            icerik = "Su",
                            kdvsizfiyat = 30m,
                            odendi = 0,
                            son_odeme = new DateTime(2021, 10, 10, 23, 59, 0, 0, DateTimeKind.Unspecified),
                            topkdv = 70m,
                            tutar = 100m
                        },
                        new
                        {
                            FaturaId = 2,
                            IsComplete = 0,
                            Name = "Elektrik Faturası",
                            icerik = "Elektrik",
                            kdvsizfiyat = 60m,
                            odendi = 0,
                            son_odeme = new DateTime(2021, 12, 10, 18, 0, 0, 0, DateTimeKind.Unspecified),
                            topkdv = 60m,
                            tutar = 120m
                        });
                });

            modelBuilder.Entity("MicrosoftOrnekBackendUyg.Core.Models.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:IdentityIncrement", 1)
                        .HasAnnotation("SqlServer:IdentitySeed", 1)
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<string>("InnerBarcode")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("Stock")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CategoryId = 1,
                            IsDeleted = false,
                            Name = "Pilot Kalem",
                            Price = 12.50m,
                            Stock = 100
                        },
                        new
                        {
                            Id = 2,
                            CategoryId = 1,
                            IsDeleted = false,
                            Name = "Kurşun Kalem",
                            Price = 40.50m,
                            Stock = 200
                        },
                        new
                        {
                            Id = 3,
                            CategoryId = 1,
                            IsDeleted = false,
                            Name = "Tükenmez Kalem",
                            Price = 500m,
                            Stock = 300
                        },
                        new
                        {
                            Id = 4,
                            CategoryId = 2,
                            IsDeleted = false,
                            Name = "Küçük Boy Defter",
                            Price = 8m,
                            Stock = 250
                        },
                        new
                        {
                            Id = 5,
                            CategoryId = 2,
                            IsDeleted = false,
                            Name = "Orta Boy Defter",
                            Price = 10m,
                            Stock = 250
                        },
                        new
                        {
                            Id = 6,
                            CategoryId = 2,
                            IsDeleted = false,
                            Name = "Büyük Boy Defter",
                            Price = 12m,
                            Stock = 250
                        });
                });

            modelBuilder.Entity("MicrosoftOrnekBackendUyg.Core.Models.Product", b =>
                {
                    b.HasOne("MicrosoftOrnekBackendUyg.Core.Models.Category", "Category")
                        .WithMany("Products")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");
                });

            modelBuilder.Entity("MicrosoftOrnekBackendUyg.Core.Models.Category", b =>
                {
                    b.Navigation("Products");
                });
#pragma warning restore 612, 618
        }
    }
}
