﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using YourHike.Models;

namespace YourHike.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20201025185248_ModelHike_Changes")]
    partial class ModelHike_Changes
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "5.0.0-rc.2.20475.6");

            modelBuilder.Entity("YourHike.Models.DTO.HikeDTO", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<double?>("Distance")
                        .HasColumnType("REAL");

                    b.Property<DateTime?>("EndDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("EndPlace")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("StartPlace")
                        .HasColumnType("TEXT");

                    b.Property<string>("Title")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Hiks");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Distance = 5.4000000000000004,
                            EndDate = new DateTime(2020, 10, 26, 19, 52, 47, 508, DateTimeKind.Local).AddTicks(3813),
                            EndPlace = "Las Kabacki",
                            StartDate = new DateTime(2020, 10, 25, 19, 52, 47, 500, DateTimeKind.Local).AddTicks(4915),
                            StartPlace = "Dom",
                            Title = "Las Kabacki"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}