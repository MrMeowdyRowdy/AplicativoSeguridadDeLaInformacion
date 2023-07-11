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
    public class VulnerabilidadsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public VulnerabilidadsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Vulnerabilidads
        public async Task<IActionResult> Index()
        {
              return _context.Vulnerabilidad != null ? 
                          View(await _context.Vulnerabilidad.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.Vulnerabilidad'  is null.");
        }

        // GET: Vulnerabilidads/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Vulnerabilidad == null)
            {
                return NotFound();
            }

            var vulnerabilidad = await _context.Vulnerabilidad
                .FirstOrDefaultAsync(m => m.Id == id);
            if (vulnerabilidad == null)
            {
                return NotFound();
            }

            return View(vulnerabilidad);
        }

        // GET: Vulnerabilidads/Create
        public async Task<IActionResult> CreateAsync()
        {
            List<string> tolerancia = new List<string> { "<50%", "<30%", "<10%" };
            ViewBag.TipoList = new SelectList(tolerancia);
            var activos = await _context.Activo.Select(m => m.Identificador).Distinct().ToListAsync();
            ViewBag.ActivoList = new SelectList(activos);
            var amenaza = await _context.Amenaza.Select(m => m.Codigo).Distinct().ToListAsync();
            ViewBag.AmenazaList = new SelectList(amenaza);
            var control = await _context.Control.Select(m => m.Codigo).Distinct().ToListAsync();
            ViewBag.ControlList = new SelectList(control);

            return View();
        }

        // POST: Vulnerabilidads/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Amenaza,Activo,Codigo,NivAmenaza,NivVulnerabilidad,Tolerancia,Control,RiesgoResidual,NivRiesgo")] Vulnerabilidad vulnerabilidad)
        {
            if (ModelState.IsValid)
            {
                vulnerabilidad = CalculoRiesgo(vulnerabilidad);
                _context.Add(vulnerabilidad);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            List<string> tolerancia = new List<string> { "<50%", "<30%", "<10%"};
            ViewBag.TipoList = new SelectList(tolerancia);
            var activos = await _context.Activo.Select(m => m.Identificador).Distinct().ToListAsync();
            ViewBag.ActivoList = new SelectList(activos);
            var amenaza = await _context.Amenaza.Select(m => m.Codigo).Distinct().ToListAsync();
            ViewBag.AmenazaList = new SelectList(amenaza);
            var control = await _context.Control.Select(m => m.Codigo).Distinct().ToListAsync();
            ViewBag.ControlList = new SelectList(control);

            return View(vulnerabilidad);
        }

        // GET: Vulnerabilidads/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Vulnerabilidad == null)
            {
                return NotFound();
            }

            var vulnerabilidad = await _context.Vulnerabilidad.FindAsync(id);
            if (vulnerabilidad == null)
            {
                return NotFound();
            }

            List<string> tolerancia = new List<string> { "<50%", "<30%", "<10%" };
            ViewBag.TipoList = new SelectList(tolerancia);
            var activos = await _context.Activo.Select(m => m.Identificador).Distinct().ToListAsync();
            ViewBag.ActivoList = new SelectList(activos);
            var amenaza = await _context.Amenaza.Select(m => m.Codigo).Distinct().ToListAsync();
            ViewBag.AmenazaList = new SelectList(amenaza);
            var control = await _context.Control.Select(m => m.Codigo).Distinct().ToListAsync();
            ViewBag.ControlList = new SelectList(control);

            return View(vulnerabilidad);
        }

        // POST: Vulnerabilidads/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Amenaza,Activo,Codigo,NivAmenaza,NivVulnerabilidad,Tolerancia,Control,RiesgoResidual,NivRiesgo")] Vulnerabilidad vulnerabilidad)
        {
            if (id != vulnerabilidad.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    vulnerabilidad = CalculoRiesgo(vulnerabilidad);
                    _context.Update(vulnerabilidad);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VulnerabilidadExists(vulnerabilidad.Id))
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

            List<string> tolerancia = new List<string> { "<50%", "<30%", "<10%" };
            ViewBag.TipoList = new SelectList(tolerancia);
            var activos = await _context.Activo.Select(m => m.Identificador).Distinct().ToListAsync();
            ViewBag.ActivoList = new SelectList(activos);
            var amenaza = await _context.Amenaza.Select(m => m.Codigo).Distinct().ToListAsync();
            ViewBag.AmenazaList = new SelectList(amenaza);
            var control = await _context.Control.Select(m => m.Codigo).Distinct().ToListAsync();
            ViewBag.ControlList = new SelectList(control);

            return View(vulnerabilidad);
        }

        // GET: Vulnerabilidads/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Vulnerabilidad == null)
            {
                return NotFound();
            }

            var vulnerabilidad = await _context.Vulnerabilidad
                .FirstOrDefaultAsync(m => m.Id == id);
            if (vulnerabilidad == null)
            {
                return NotFound();
            }

            return View(vulnerabilidad);
        }

        // POST: Vulnerabilidads/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Vulnerabilidad == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Vulnerabilidad'  is null.");
            }
            var vulnerabilidad = await _context.Vulnerabilidad.FindAsync(id);
            if (vulnerabilidad != null)
            {
                _context.Vulnerabilidad.Remove(vulnerabilidad);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VulnerabilidadExists(int id)
        {
          return (_context.Vulnerabilidad?.Any(e => e.Id == id)).GetValueOrDefault();
        }

        private Vulnerabilidad CalculoRiesgo(Vulnerabilidad vulnerabilidades)
        {
            SQLController scon = new SQLController();
            List<Activo> activos = new List<Activo>();

            List<Control> controles = new List<Control>();

            int criticidad = 0;
            int eficiencia = 0;
            int tol = 0;
            activos = scon.GetDataAct();
            controles = scon.GetDataContr();

            foreach (var item in activos)
            {
                if (item.Identificador.Equals(vulnerabilidades.Activo))
                {
                    criticidad = item.Criticidad;
                }
            }

            foreach (var item1 in controles)
            {
                if (item1.Codigo.Equals(vulnerabilidades.Control))
                {
                    eficiencia = item1.Eficiencia;
                }
            }
            int riesgoCalculo = vulnerabilidades.NivAmenaza * vulnerabilidades.NivVulnerabilidad * criticidad;
            string riesgo;
            if (riesgoCalculo >= 1 && riesgoCalculo < 4)
            {
                riesgo = "Bajo";
            }
            else if (riesgoCalculo >= 4 && riesgoCalculo < 9)
            {
                riesgo = "Medio";
            }
            else
            {
                riesgo = "Alto";
            }
            vulnerabilidades.NivRiesgo = riesgo;

            if (vulnerabilidades.Tolerancia.Equals("<10%"))
            {
                tol = 5;
            }
            else if (vulnerabilidades.Tolerancia.Equals("<30%"))
            {
                tol = 10;
            }
            else
            {
                tol = 15;
            }

            int riesgoRes = riesgoCalculo-tol-eficiencia;
            if (riesgoRes > 0)
            {
                vulnerabilidades.RiesgoResidual = riesgoRes;
            }
            else
            {
                vulnerabilidades.RiesgoResidual = 1;
            }
            return vulnerabilidades;
        }
    }
}
