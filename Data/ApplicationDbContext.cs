using Microsoft.EntityFrameworkCore;
using WebApiNet.Models;

namespace WebApiNet.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> contextOptions) : base(contextOptions) 
        {

        }
        
        public DbSet<Villa> Villas { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Villa>().HasData(
                new Villa()
                {
                    Id = 1,
                    Nombre = "Villa",
                    Detalle = "Detalle de la villa",
                    ImagenUrl="",
                    Ocupantes = 5,
                    MetrosCuadrados = 50,
                    Tarifa = 200,
                    Amenidad = "",
                    FechaCreacion = DateTime.Now,
                    FechaActualizacion = DateTime.Now,
                },
                new Villa()
                {
                    Id = 2,
                    Nombre = "Prueba de viilla",
                    Detalle = "Detalle de la villa prueba n1",
                    ImagenUrl="",
                    Ocupantes = 5,
                    MetrosCuadrados = 30,
                    Tarifa = 100,
                    Amenidad = "",
                    FechaCreacion = DateTime.Now,
                    FechaActualizacion = DateTime.Now,
                }
                );
        }

    }
}
