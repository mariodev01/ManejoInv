using ManejoInventario.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace ManejoInventario.Controllers
{
    public class InventarioController : Controller
    {
        private readonly ManejoContext context;

        public InventarioController(ManejoContext context)
        {
            this.context = context;
        }
        public IActionResult Index()
        {
            var inventarios = context.verInventariosp().ToList();
            return View(inventarios);
        }

        public IActionResult Crear()
        {
            ViewData["productos"] = new SelectList(context.Productos, "Id", "Nombre");
            return View();
        }

        [HttpPost]
        public IActionResult Crear(Inventario inventario)
        {
            context.AñadirInventario(inventario.EnExistencia, inventario.Cantidad, inventario.ProductoId);
            return RedirectToAction("Index");
        }
    }
}

