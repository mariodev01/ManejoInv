using ManejoInventario.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ManejoInventario.Controllers
{
    public class ProductoController : Controller
    {
        private readonly ManejoContext context;

        public ProductoController(ManejoContext context)
        {
            this.context = context;
        }
        public async Task<IActionResult> Index()
        {
            var productos = await context.Productos.ToListAsync(); 
            return View(productos);
        }

        public IActionResult Crear()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Crear(Producto producto)
        {
            context.Add(producto);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Editar(int id)
        {
            var producto =  context.Productos.FirstOrDefault(p=>p.Id == id);

            if(producto == null)
            {
                return NotFound();
            }
            return View(producto);
        }
        [HttpPost]
        public IActionResult Editar(int id, Producto producto)
        {
            if (id != producto.Id)
            {
                return NotFound();
            }

            context.Update(producto);
            context.SaveChanges();

            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            var producto = context.Productos.Find(id);
            if (producto != null)
            {
                context.Remove(producto);
                context.SaveChanges();
            }
            return RedirectToAction("Index");
        }
    }
}
