using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace ManejoInventario.Models
{
    public class Producto
    {
        public int Id { get; set; }
        [MaxLength(50)]
        public string? Nombre { get; set; }
        [MaxLength(70)]
        public string? Descripcion { get; set; }
        [Precision(precision:8,scale:2)]
        public decimal Precio { get; set; }

        public virtual ICollection<Inventario> Inventarios { get; set; }
    }
}
