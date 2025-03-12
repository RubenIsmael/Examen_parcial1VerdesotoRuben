using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Examen_Parcial1_Verdesoto_Ruben.Models; 

namespace Examen_Parcial1_Verdesoto_Ruben.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }     
        public DbSet<Chef> Chefs { get; set; }
        public DbSet<Ingrediente> Ingredientes { get; set; }
        public DbSet<Receta> Recetas { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);                     
            modelBuilder.Entity<Ingrediente>()
                .Property(i => i.Cantidad)
                .HasColumnType("decimal(18, 2)"); 
        }
    }
}