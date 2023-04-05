using ManejoInventario.Models;
using Microsoft.EntityFrameworkCore;

namespace ManejoInventario
{
    public class ManejoContext:DbContext
    {
        public ManejoContext(DbContextOptions<ManejoContext> options):base(options)
        {

        }

        public DbSet<Producto> Productos { get; set; }
        public DbSet<Inventario> Inventarios { get; set; }
    }
}
