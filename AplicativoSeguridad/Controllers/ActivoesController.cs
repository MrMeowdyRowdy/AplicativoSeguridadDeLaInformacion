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
    public class ActivoesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ActivoesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Activoes
        public async Task<IActionResult> Index()
        {
              return _context.Activo != null ? 
                          View(await _context.Activo.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.Activo'  is null.");
        }

        // GET: Activoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Activo == null)
            {
                return NotFound();
            }

            var activo = await _context.Activo
                .FirstOrDefaultAsync(m => m.ActivoID == id);
            if (activo == null)
            {
                return NotFound();
            }

            return View(activo);
        }

        // GET: Activoes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Activoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("activoID,identificador,ubicacion,proceso,nombreActivo,descripcion,responsable,clasificacion,valEconomica,valOps,valLegal,valRep,valPriv,valSeg,criticidad")] Activo activo)
        {
            if (ModelState.IsValid)
            {
                _context.Add(activo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(activo);
        }

        // GET: Activoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Activo == null)
            {
                return NotFound();
            }

            var activo = await _context.Activo.FindAsync(id);
            if (activo == null)
            {
                return NotFound();
            }
            return View(activo);
        }

        // POST: Activoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("activoID,identificador,ubicacion,proceso,nombreActivo,descripcion,responsable,clasificacion,valEconomica,valOps,valLegal,valRep,valPriv,valSeg,criticidad")] Activo activo)
        {
            if (id != activo.ActivoID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(activo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ActivoExists(activo.ActivoID))
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
            return View(activo);
        }

        // GET: Activoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Activo == null)
            {
                return NotFound();
            }

            var activo = await _context.Activo
                .FirstOrDefaultAsync(m => m.ActivoID == id);
            if (activo == null)
            {
                return NotFound();
            }

            return View(activo);
        }

        // POST: Activoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Activo == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Activo'  is null.");
            }
            var activo = await _context.Activo.FindAsync(id);
            if (activo != null)
            {
                _context.Activo.Remove(activo);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ActivoExists(int id)
        {
          return (_context.Activo?.Any(e => e.ActivoID == id)).GetValueOrDefault();
        }
    }
}
