using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AplicativoSeguridad.Data;
using AplicativoSeguridad.Models;
using Microsoft.Data.SqlClient;

namespace AplicativoSeguridad.Controllers
{
    public class ControlController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ControlController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Control
        public async Task<IActionResult> Index()
        {
              return _context.Control != null ? 
                          View(await _context.Control.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.Control'  is null.");
        }

        // GET: Control/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Control == null)
            {
                return NotFound();
            }

            var control = await _context.Control
                .FirstOrDefaultAsync(m => m.Id == id);
            if (control == null)
            {
                return NotFound();
            }

            return View(control);
        }

        // GET: Control/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Control/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Codigo,Responsable,Periodicidad,Proposito,Definicion,Acciones,Eficiencia")] Control control)
        {
            if (ModelState.IsValid)
            {
                _context.Add(control);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(control);
        }

        // GET: Control/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Control == null)
            {
                return NotFound();
            }

            var control = await _context.Control.FindAsync(id);
            if (control == null)
            {
                return NotFound();
            }
            return View(control);
        }

        // POST: Control/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Codigo,Responsable,Periodicidad,Proposito,Definicion,Acciones,Eficiencia")] Control control)
        {
            if (id != control.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(control);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ControlExists(control.Id))
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
            return View(control);
        }

        // GET: Control/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Control == null)
            {
                return NotFound();
            }

            var control = await _context.Control
                .FirstOrDefaultAsync(m => m.Id == id);
            if (control == null)
            {
                return NotFound();
            }

            return View(control);
        }

        // POST: Control/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Control == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Control'  is null.");
            }
            var control = await _context.Control.FindAsync(id);
            if (control != null)
            {
                _context.Control.Remove(control);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ControlExists(int id)
        {
          return (_context.Control?.Any(e => e.Id == id)).GetValueOrDefault();
        }

    }
}
