﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using testSite.Data;

namespace testSite.Migrations
{
    [DbContext(typeof(AppDBContent))]
    [Migration("20191009132451_ShopCart")]
    partial class ShopCart
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.11-servicing-32099")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("testSite.Data.Models.Car", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Avalibale");

                    b.Property<int>("CategoryID");

                    b.Property<string>("Img");

                    b.Property<bool>("IsFavorite");

                    b.Property<string>("LongDecription");

                    b.Property<string>("Name");

                    b.Property<int>("Price");

                    b.Property<string>("ShortDecription");

                    b.HasKey("ID");

                    b.HasIndex("CategoryID");

                    b.ToTable("Car");
                });

            modelBuilder.Entity("testSite.Data.Models.Category", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Decription");

                    b.Property<string>("Name");

                    b.HasKey("ID");

                    b.ToTable("Category");
                });

            modelBuilder.Entity("testSite.Data.Models.ShopCartItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("CarID");

                    b.Property<int>("Price");

                    b.Property<string>("ShopCartId");

                    b.HasKey("Id");

                    b.HasIndex("CarID");

                    b.ToTable("ShopCartItem");
                });

            modelBuilder.Entity("testSite.Data.Models.Car", b =>
                {
                    b.HasOne("testSite.Data.Models.Category", "Category")
                        .WithMany("Cars")
                        .HasForeignKey("CategoryID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("testSite.Data.Models.ShopCartItem", b =>
                {
                    b.HasOne("testSite.Data.Models.Car", "Car")
                        .WithMany()
                        .HasForeignKey("CarID");
                });
#pragma warning restore 612, 618
        }
    }
}
