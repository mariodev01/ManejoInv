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


        public List<Inventario> verInventariosp()
        {
            return Inventarios.FromSqlRaw("exec sp_ver_Inventario").ToList();
        }

        public void AñadirInventario(bool EnExistencia,int Cantidad,int ProductoId)
        {
            Database.ExecuteSqlRaw("exec sp_Añadir_Inventario {0},{1},{2}",EnExistencia, Cantidad, ProductoId);
        }
    }
}
