using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AplicativoSeguridad.Data;
using AplicativoSeguridad.Models;

namespace AplicativoSeguridad.Controllers
{
    public class AmenazasController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AmenazasController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Amenazas
        public async Task<IActionResult> Index()
        {
              return _context.Amenaza != null ? 
                          View(await _context.Amenaza.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.Amenaza'  is null.");
        }

        // GET: Amenazas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Amenaza == null)
            {
                return NotFound();
            }

            var amenaza = await _context.Amenaza
                .FirstOrDefaultAsync(m => m.Id == id);
            if (amenaza == null)
            {
                return NotFound();
            }

            return View(amenaza);
        }

        // GET: Amenazas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Amenazas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Tipo,Origen,Codigo,Hardware,Software,Redes,TH")] Amenaza amenaza)
        {
            if (ModelState.IsValid)
            {
                _context.Add(amenaza);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(amenaza);
        }

        // GET: Amenazas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Amenaza == null)
            {
                return NotFound();
            }

            var amenaza = await _context.Amenaza.FindAsync(id);
            if (amenaza == null)
            {
                return NotFound();
            }
            return View(amenaza);
        }

        // POST: Amenazas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Tipo,Origen,Codigo,Hardware,Software,Redes,TH")] Amenaza amenaza)
        {
            if (id != amenaza.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(amenaza);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AmenazaExists(amenaza.Id))
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
            return View(amenaza);
        }

        // GET: Amenazas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Amenaza == null)
            {
                return NotFound();
            }

            var amenaza = await _context.Amenaza
                .FirstOrDefaultAsync(m => m.Id == id);
            if (amenaza == null)
            {
                return NotFound();
            }

            return View(amenaza);
        }

        // POST: Amenazas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Amenaza == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Amenaza'  is null.");
            }
            var amenaza = await _context.Amenaza.FindAsync(id);
            if (amenaza != null)
            {
                _context.Amenaza.Remove(amenaza);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AmenazaExists(int id)
        {
          return (_context.Amenaza?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
