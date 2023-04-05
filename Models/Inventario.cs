namespace ManejoInventario.Models
{
    public class Inventario
    {
        public int Id { get; set; }
        public bool EnExistencia { get; set; }

        public int Cantidad { get; set; }

        public int ProductoId { get; set; }

        public virtual Producto Producto { get; set; }
    }
}
