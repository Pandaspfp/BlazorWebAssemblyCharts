using System;
using System.Collections.Generic;
using HorizonLab.DataLayer.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace HorizonLab.DataLayer.Context
{
    public partial class greenhouse_dbContext : DbContext
    {
        public greenhouse_dbContext()
        {
        }

        public greenhouse_dbContext(DbContextOptions<greenhouse_dbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Device> Devices { get; set; } = null!;
        public virtual DbSet<Greenhouse> Greenhouses { get; set; } = null!;
        public virtual DbSet<MeasurementLight> MeasurementLights { get; set; } = null!;
        public virtual DbSet<MeasurementTemperature> MeasurementTemperatures { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseMySql("server=192.168.1.2;database=greenhouse_db;user=dk25;password=dk25Pass;", ServerVersion.Parse("10.5.16-mariadb"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.UseCollation("utf8_general_ci")
                .HasCharSet("utf8");

            modelBuilder.Entity<Device>(entity =>
            {
                entity.ToTable("devices");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("id");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("createdAt");

                entity.Property(e => e.Hostname)
                    .HasMaxLength(255)
                    .HasColumnName("hostname");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("updatedAt");
            });

            modelBuilder.Entity<Greenhouse>(entity =>
            {
                entity.ToTable("greenhouses");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("id");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("createdAt");

                entity.Property(e => e.FkDevicesId)
                    .HasColumnType("int(11)")
                    .HasColumnName("FK_devices_id");

                entity.Property(e => e.Name)
                    .HasMaxLength(255)
                    .HasColumnName("name");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("updatedAt");
            });

            modelBuilder.Entity<MeasurementLight>(entity =>
            {
                entity.ToTable("measurement_lights");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("id");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("createdAt");

                entity.Property(e => e.FkGreenhousesId)
                    .HasColumnType("int(11)")
                    .HasColumnName("FK_greenhouses_id");

                entity.Property(e => e.LightOn).HasColumnName("light_on");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("updatedAt");
            });

            modelBuilder.Entity<MeasurementTemperature>(entity =>
            {
                entity.ToTable("measurement_temperatures");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("id");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("createdAt");

                entity.Property(e => e.FkGreenhousesId)
                    .HasColumnType("int(11)")
                    .HasColumnName("FK_greenhouses_id");

                entity.Property(e => e.Temperature).HasColumnName("temperature");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("updatedAt");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
