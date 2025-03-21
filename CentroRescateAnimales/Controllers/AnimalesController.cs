using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CentroRescateAnimales.Data;
using CentroRescateAnimales.Models;

namespace CentroRescateAnimales.Controllers
{
    public class AnimalesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AnimalesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Animales
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Animales.Include(a => a.Adoptante);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Animales/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var animal = await _context.Animales
                .Include(a => a.Adoptante)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (animal == null)
            {
                return NotFound();
            }

            return View(animal);
        }

        // GET: Animales/Create
        public IActionResult Create()
        {
            ViewData["AdoptanteId"] = new SelectList(_context.Adoptantes, "Id", "Id");
            return View();
        }

        // POST: Animales/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nombre,Especie,Edad,Estado,AdoptanteId")] Animal animal)
        {
            if (ModelState.IsValid)
            {
                _context.Add(animal);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AdoptanteId"] = new SelectList(_context.Adoptantes, "Id", "Id", animal.AdoptanteId);
            return View(animal);
        }

        // GET: Animales/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var animal = await _context.Animales.FindAsync(id);
            if (animal == null)
            {
                return NotFound();
            }
            ViewData["AdoptanteId"] = new SelectList(_context.Adoptantes, "Id", "Id", animal.AdoptanteId);
            return View(animal);
        }

        // POST: Animales/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nombre,Especie,Edad,Estado,AdoptanteId")] Animal animal)
        {
            if (id != animal.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(animal);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AnimalExists(animal.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["AdoptanteId"] = new SelectList(_context.Adoptantes, "Id", "Id", animal.AdoptanteId);
            return View(animal);
        }

        // GET: Animales/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var animal = await _context.Animales
                .Include(a => a.Adoptante)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (animal == null)
            {
                return NotFound();
            }

            return View(animal);
        }

        // POST: Animales/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var animal = await _context.Animales.FindAsync(id);
            if (animal != null)
            {
                _context.Animales.Remove(animal);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AnimalExists(int id)
        {
            return _context.Animales.Any(e => e.Id == id);
        }
    }
}
