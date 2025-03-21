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
    public class AdoptantesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AdoptantesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Adoptantes
        public async Task<IActionResult> Index()
        {
            return View(await _context.Adoptantes.ToListAsync());
        }

        // GET: Adoptantes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var adoptante = await _context.Adoptantes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (adoptante == null)
            {
                return NotFound();
            }

            return View(adoptante);
        }

        // GET: Adoptantes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Adoptantes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nombre,Email,Telefono")] Adoptante adoptante)
        {
            if (ModelState.IsValid)
            {
                _context.Add(adoptante);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(adoptante);
        }

        // GET: Adoptantes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var adoptante = await _context.Adoptantes.FindAsync(id);
            if (adoptante == null)
            {
                return NotFound();
            }
            return View(adoptante);
        }

        // POST: Adoptantes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nombre,Email,Telefono")] Adoptante adoptante)
        {
            if (id != adoptante.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(adoptante);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AdoptanteExists(adoptante.Id))
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
            return View(adoptante);
        }

        // GET: Adoptantes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var adoptante = await _context.Adoptantes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (adoptante == null)
            {
                return NotFound();
            }

            return View(adoptante);
        }

        // POST: Adoptantes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var adoptante = await _context.Adoptantes.FindAsync(id);
            if (adoptante != null)
            {
                _context.Adoptantes.Remove(adoptante);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AdoptanteExists(int id)
        {
            return _context.Adoptantes.Any(e => e.Id == id);
        }
    }
}
