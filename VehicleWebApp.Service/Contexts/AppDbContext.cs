using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using VehicleWebApp.Service.Models;

namespace VehicleWebApp.Service.Contexts
{
    public class AppDbContext : DbContext
    {
        // Properties
        public DbSet<VehicleMake> VehicleMakes { get; set; }
        public DbSet<VehicleModel> VehicleModels { get; set; }

        // Constructor (calls constructor of base class with options parameter)
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        // overrides the OnModelCreating method of base DbContext class
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            // Vehicle Makes DbSet configuration
            builder.Entity<VehicleMake>().ToTable("VehicleMakes");
            builder.Entity<VehicleMake>().HasKey(p => p.Id);
            builder.Entity<VehicleMake>().HasMany(p => p.Models)
                                         .WithOne(p => p.Make)
                                         .HasForeignKey(p => p.MakeId);

            // Vehicle Models DbSet configuration
            builder.Entity<VehicleModel>().ToTable("VehicleModels");
            builder.Entity<VehicleModel>().HasKey(p => p.Id);

            // Seed initial data to database
            builder.Entity<VehicleModel>().HasData
            (
                new VehicleModel { Id = Guid.NewGuid(), Name = "206", MakeId = new Guid("00000000-0000-0000-0000-000000000001") },
                new VehicleModel { Id = Guid.NewGuid(), Name = "207", Abbreviation = "Dvjestosedmica", MakeId = new Guid("00000000-0000-0000-0000-000000000001") },
                new VehicleModel { Id = Guid.NewGuid(), Name = "M4", MakeId = new Guid("00000000-0000-0000-0000-000000000002") }
            );

            builder.Entity<VehicleMake>().HasData
            (
                new VehicleMake { Id = new Guid ("00000000-0000-0000-0000-000000000001"), Name = "Peugeot" },
                new VehicleMake { Id = new Guid("00000000-0000-0000-0000-000000000002"), Name = "BMW", Abbreviation = "Bembara" }
            );
        }
    }
}
