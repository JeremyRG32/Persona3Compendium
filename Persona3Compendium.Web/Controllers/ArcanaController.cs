using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
            var arcanas = _context.Arcanas.ToList();
            return View(arcanas);
        }
        public IActionResult Details(int id)
        {
            var arcana = _context.Arcanas
                        .Include(a => a.Personas)        
                        .FirstOrDefault(x => x.Id == id);
            
            if (arcana == null)
            {
                return NotFound();
            }

            return View(arcana);
        }
    }
}
