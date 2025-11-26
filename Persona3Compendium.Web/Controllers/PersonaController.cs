using System.ComponentModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Persona3Compendium.Web.Data;
using Persona3Compendium.Web.Models;

namespace Persona3Compendium.Web.Controllers
{
    public class PersonaController : Controller
    {
        private readonly PersonaCompendiumDbContext _context;
        public PersonaController(PersonaCompendiumDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index(string? search, string? arcana)
        {            
            var personas = _context.Personas
            .Include(p => p.Arcana)
            .Include(p => p.Weaknesses)
            .Include(p => p.Absorbs)
            .Include(p => p.Resists)
            .Include(p => p.Reflects)
            .Include(p => p.Nullifies)
            .AsQueryable();

            if (!string.IsNullOrWhiteSpace(search))
            {
                personas = personas.Where(p => p.Name.ToLower().Contains(search.ToLower()));
            }

            if (!string.IsNullOrWhiteSpace(arcana))
            {
                personas = personas.Where(p => p.Arcana.Name == arcana);
            }

            //Applying pagination
            int totalitems = await personas.CountAsync();

            ViewBag.Arcanas = await _context.Arcanas.ToListAsync();
            return View(await personas.ToListAsync());
        }
        public IActionResult Details(int id)
        {
            var persona = _context.Personas
                        .Include(p => p.Arcana)
                        .Include(p => p.Weaknesses).ThenInclude(w => w.Element)
                        .Include(p => p.Resists).ThenInclude(r => r.Element)
                        .Include(p => p.Reflects).ThenInclude(r => r.Element)
                        .Include(p => p.Absorbs).ThenInclude(a => a.Element)
                        .Include(p => p.Nullifies).ThenInclude(n => n.Element)
                        .FirstOrDefault(x => x.Id == id);
            
            if (persona == null)
            {
                return NotFound();
            }

            var viewModel = new PersonaViewModel
            {
                Persona = persona,
                Weaknesses = persona.Weaknesses.Select(w => w.Element).ToList(),
                Absorbs = persona.Absorbs.Select(a => a.Element).ToList(),
                Resists = persona.Resists.Select(r => r.Element).ToList(),
                Reflects = persona.Reflects.Select(r => r.Element).ToList(),
                Nullifies = persona.Nullifies.Select(n => n.Element).ToList()
            };

            return View(viewModel);
        }
    }
}
