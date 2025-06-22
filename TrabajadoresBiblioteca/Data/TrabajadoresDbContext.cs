using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using TrabajadoresBiblioteca.Models;

namespace TrabajadoresBiblioteca.Data
{
    public class TrabajadoresDbContext : DbContext
    {
        public TrabajadoresDbContext(DbContextOptions<TrabajadoresDbContext> options) : base(options)
        { }

        // Db sets
        public DbSet<Departamento> Departamentos { get; set; }
        public DbSet<Provincia> Provincias { get; set; }
        public DbSet<Distrito> Distritos { get; set; }
        public DbSet<Trabajador> Trabajadores { get; set; }
        public DbSet<TrabajadorListado> TrabajadorListado { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Tabla Trabajadores
            modelBuilder.Entity<Trabajador>(e =>
            {
                e.ToTable("Trabajadores");
                e.HasKey(t => t.Id);
                e.Property(t => t.TipoDocumento).HasMaxLength(3);
                e.Property(t => t.NumeroDocumento).HasMaxLength(50);
                e.Property(t => t.Nombres).HasMaxLength(500);
                e.Property(t => t.Sexo).HasColumnType("char(1)");

                e.HasOne(t => t.Departamento)
                 .WithMany()
                 .HasForeignKey(t => t.IdDepartamento);
                e.HasOne(t => t.Provincia)
                 .WithMany()
                 .HasForeignKey(t => t.IdProvincia);
                e.HasOne(t => t.Distrito)
                 .WithMany()
                 .HasForeignKey(t => t.IdDistrito);
            });

            // Lookup tables
            modelBuilder.Entity<Departamento>()
                .ToTable("Departamento")
                .HasKey(d => d.Id);
            modelBuilder.Entity<Provincia>()
                .ToTable("Provincia")
                .HasKey(p => p.Id);
            modelBuilder.Entity<Distrito>()
                .ToTable("Distrito")
                .HasKey(d => d.Id);

            // Configurar entidad para SP (sin clave)
            modelBuilder.Entity<TrabajadorListado>()
                .HasNoKey()
                .ToView(null); // no mapea a tabla física
        }
    }
}
