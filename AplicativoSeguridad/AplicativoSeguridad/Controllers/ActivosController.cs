﻿using System;
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
    public class ActivosController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ActivosController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Activos
        public async Task<IActionResult> Index()
        {
              return _context.Activo != null ? 
                          View(await _context.Activo.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.Activo'  is null.");
        }

        // GET: Activos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Activo == null)
            {
                return NotFound();
            }

            var activo = await _context.Activo
                .FirstOrDefaultAsync(m => m.Id == id);
            if (activo == null)
            {
                return NotFound();
            }

            return View(activo);
        }

        // GET: Activos/Create
        public IActionResult Create()
        {
            List<string> tipos = new List<string> { "Software", "Hardware", "Red", "Talento Humano" };
            ViewBag.TipoList = new SelectList(tipos);
            return View();
        }

        // POST: Activos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Identificador,Ubicacion,Proceso,NombreActivo,Descripcion,Tipo,Responsable,Clasificacion,ValEconomico,ValOps,ValLegal,ValRep,ValPriv,ValSeg,Criticidad")] Activo activo)
        {
            if (ModelState.IsValid)
            {
                activo = CalculoCriticidad(activo);
                _context.Add(activo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            List<string> tipos = new List<string> { "Software", "Hardware", "Red", "Talento Humano" };
            ViewBag.TipoList = new SelectList(tipos);

            return View(activo);
        }

        // GET: Activos/Edit/5
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

            List<string> tipos = new List<string> { "Software", "Hardware", "Red", "Talento Humano" };
            ViewBag.TipoList = new SelectList(tipos);

            return View(activo);
        }

        // POST: Activos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Identificador,Ubicacion,Proceso,NombreActivo,Descripcion,Tipo,Responsable,Clasificacion,ValEconomico,ValOps,ValLegal,ValRep,ValPriv,ValSeg,Criticidad")] Activo activo)
        {
            if (id != activo.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    activo = CalculoCriticidad(activo);
                    _context.Update(activo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ActivoExists(activo.Id))
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

            List<string> tipos = new List<string> { "Software", "Hardware", "Red", "Talento Humano" };
            ViewBag.TipoList = new SelectList(tipos);

            return View(activo);
        }

        // GET: Activos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Activo == null)
            {
                return NotFound();
            }

            var activo = await _context.Activo
                .FirstOrDefaultAsync(m => m.Id == id);
            if (activo == null)
            {
                return NotFound();
            }

            return View(activo);
        }

        // POST: Activos/Delete/5
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
          return (_context.Activo?.Any(e => e.Id == id)).GetValueOrDefault();
        }

        private Activo CalculoCriticidad(Activo activo)
        {
            float criticidadCalculo = (float)((activo.ValEconomico + activo.ValLegal + activo.ValOps + activo.ValPriv + activo.ValRep + activo.ValSeg) / 6.0);
            if (criticidadCalculo >= 1 && criticidadCalculo < 1.5)
            {
                criticidadCalculo = 1;
            }
            else if (criticidadCalculo >= 1.5 && criticidadCalculo < 2.5)
            {
                criticidadCalculo = 2;
            }
            else if (criticidadCalculo >= 2.5)
            {
                criticidadCalculo = 3;
            }
            activo.Criticidad = (int)criticidadCalculo;
            string clasificacion;
            if (criticidadCalculo == 1)
            {
                clasificacion = "No crítico";
            }
            else
            {
                clasificacion = "Crítico";
            }
            activo.Clasificacion = clasificacion;
            return activo;
        }

    }
}
