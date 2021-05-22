using System.IO;
using Kalum2021.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Kalum2021.DataContext
{
    public class KalumDBContext : DbContext
    {
        public DbSet<Alumno> Alumnos {get;set;}
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
        }
    }
}