using Microsoft.AspNetCore.Mvc;

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
    }
}
