using Microsoft.AspNetCore.Mvc;
using Persona3Compendium.Web.Data;

namespace Persona3Compendium.Web.Controllers
{
    public class ArcanaController : Controller
    {
        private readonly PersonaCompendiumDbContext _context;
        public ArcanaController(PersonaCompendiumDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var personas = _context.Personas.ToList();
            return View(personas);
        }
    }
}
