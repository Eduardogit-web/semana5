using CentroRescateAnimales.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CentroRescateAnimales.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public DbSet<Animal> Animales { get; set; }
    public DbSet<Adoptante> Adoptantes { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Datos semilla para Adoptante
        modelBuilder.Entity<Adoptante>().HasData(
            new Adoptante
            {
                Id = 1,
                Nombre = "Juan Pérez",
                Email = "juan.perez@example.com",
                Telefono = "555-123-4567"
            },
            new Adoptante
            {
                Id = 2,
                Nombre = "María Gómez",
                Email = "maria.gomez@example.com",
                Telefono = "555-987-6543"
            }
        );
    }
}
