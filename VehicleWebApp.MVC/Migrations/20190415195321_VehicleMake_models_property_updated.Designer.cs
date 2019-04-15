﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using VehicleWebApp.Service.Contexts;

namespace VehicleWebApp.MVC.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20190415195321_VehicleMake_models_property_updated")]
    partial class VehicleMake_models_property_updated
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.4-servicing-10062")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("VehicleWebApp.Service.Models.VehicleMake", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Abbreviation");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(20);

                    b.HasKey("Id");

                    b.ToTable("VehicleMakes");

                    b.HasData(
                        new
                        {
                            Id = new Guid("00000000-0000-0000-0000-000000000001"),
                            Name = "Peugeot"
                        },
                        new
                        {
                            Id = new Guid("00000000-0000-0000-0000-000000000002"),
                            Abbreviation = "Bembara",
                            Name = "BMW"
                        });
                });

            modelBuilder.Entity("VehicleWebApp.Service.Models.VehicleModel", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Abbreviation");

                    b.Property<Guid>("MakeId");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(20);

                    b.HasKey("Id");

                    b.HasIndex("MakeId");

                    b.ToTable("VehicleModels");

                    b.HasData(
                        new
                        {
                            Id = new Guid("0f6ec4b0-24fe-4e98-96a0-5c479d8e180b"),
                            MakeId = new Guid("00000000-0000-0000-0000-000000000001"),
                            Name = "206"
                        },
                        new
                        {
                            Id = new Guid("ea226a52-0e48-4d4f-8a68-a7407d93c45c"),
                            Abbreviation = "Dvjestosedmica",
                            MakeId = new Guid("00000000-0000-0000-0000-000000000001"),
                            Name = "207"
                        },
                        new
                        {
                            Id = new Guid("c1e973d2-88b0-414d-a1f2-69b87f9a5d3c"),
                            MakeId = new Guid("00000000-0000-0000-0000-000000000002"),
                            Name = "M4"
                        });
                });

            modelBuilder.Entity("VehicleWebApp.Service.Models.VehicleModel", b =>
                {
                    b.HasOne("VehicleWebApp.Service.Models.VehicleMake", "Make")
                        .WithMany("Models")
                        .HasForeignKey("MakeId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}