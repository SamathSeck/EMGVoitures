using Microsoft.AspNetCore.Mvc;
using EMGVoitures.Data;
using EMGVoitures.Models;
using Microsoft.EntityFrameworkCore;

namespace EMGVoitures.Controllers
{
    public class VoituresController : Controller
    {
        private readonly ApplicationDbContext _context;

        public VoituresController(ApplicationDbContext context)
        {
            _context = context;
        }

        // Afficher la liste des voitures
        public async Task<IActionResult> Index()
        {
            return View(await _context.Voitures.ToListAsync());
        }

        // Afficher le formulaire pour ajouter une voiture
        public IActionResult Create()
        {
            return View();
        }

        // Ajouter une voiture
        [HttpPost]
        public async Task<IActionResult> Create(Voiture voiture)
        {
            if (ModelState.IsValid)
            {
                _context.Add(voiture);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(voiture);
        }

        // Afficher le formulaire pour modifier une voiture
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var voiture = await _context.Voitures.FindAsync(id);
            if (voiture == null)
            {
                return NotFound();
            }
            return View(voiture);
        }

        // Modifier une voiture
        [HttpPost]
        public async Task<IActionResult> Edit(int id, Voiture voiture)
        {
            if (id != voiture.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _context.Update(voiture);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(voiture);
        }

        // Marquer une voiture comme vendue
        public async Task<IActionResult> MarkAsSold(int id)
        {
            var voiture = await _context.Voitures.FindAsync(id);
            if (voiture == null)
            {
                return NotFound();
            }

            voiture.EstVendue = true;
            _context.Update(voiture);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}