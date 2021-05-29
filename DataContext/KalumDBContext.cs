using System.IO;
using Kalum2021.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Kalum2021.DataContext
{
    public class KalumDBContext : DbContext
    {
        public DbSet<Alumno> Alumnos {get;set;}
        public DbSet<Salon> Salones {get;set;}
        public DbSet<Horario> Horarios {get;set;}
        public DbSet<Instructor> Instructores {get;set;}
        public DbSet<CarreraTecnica> CarrerasTecnicas {get;set;}
        public DbSet<Clase> Clases {get;set;}
        public KalumDBContext(DbContextOptions<KalumDBContext> options)
            : base(options)
        {
            
        }

        public KalumDBContext()
        {
            
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();
            optionsBuilder.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Alumno>()
                .ToTable("Alumnos")  .HasKey(c => new {c.Carne});
            modelBuilder.Entity<Salon>()
                .ToTable("Salones").HasKey(s => new {s.SalonId});
            modelBuilder.Entity<Horario>()
                .ToTable("Horarios").HasKey(h => new {h.HorarioId});
            modelBuilder.Entity<Instructor>()
                .ToTable("Instructores").HasKey(i => new {i.InstructorId});
            modelBuilder.Entity<CarreraTecnica>()
                .ToTable("CarrerasTecnicas").HasKey(c => new {c.CarreraId});
            modelBuilder.Entity<Clase>()
                .ToTable("Clases").HasKey(c => new {c.ClaseId});
            modelBuilder.Entity<Clase>()
                .HasOne<CarreraTecnica>(c => c.CarreraTecnica)
                .WithMany(ct => ct.Clases)
                .HasForeignKey(c => c.CarreraId);
        }
    }
}