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
    public class RiesgoResidualsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public RiesgoResidualsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: RiesgoResiduals
        public async Task<IActionResult> Index()
        {
              return _context.RiesgoResidual != null ? 
                          View(await _context.RiesgoResidual.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.RiesgoResidual'  is null.");
        }

        // GET: RiesgoResiduals/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.RiesgoResidual == null)
            {
                return NotFound();
            }

            var riesgoResidual = await _context.RiesgoResidual
                .FirstOrDefaultAsync(m => m.Id == id);
            if (riesgoResidual == null)
            {
                return NotFound();
            }

            return View(riesgoResidual);
        }

        // GET: RiesgoResiduals/Create
        public async Task<IActionResult> CreateAsync()
        {
            //List<string> tol = new List<string> { "<10%", "<30%", "<50%" };
            //ViewBag.TipoTol = new SelectList(tol);
            //var activos = await _context.Activo.Select(m => m.Identificador).Distinct().ToListAsync();
            //ViewBag.ActivoList = new SelectList(activos);
            //var vulnerabilidad = await _context.Vulnerabilidad.Select(m => m.Codigo).Distinct().ToListAsync();
            //ViewBag.VulnerabilidadList = new SelectList(vulnerabilidad);
            var control = await _context.Control.Select(m => m.Codigo).Distinct().ToListAsync();
            ViewBag.ControlList = new SelectList(control);

            return View();
        }

        // POST: RiesgoResiduals/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Activo,Vulnerabilidad,Responsable,Tolerancia,NuevoControl,RiesgoRes,NuevoNivRiesgo")] RiesgoResidual riesgoResidual)
        {
            if (ModelState.IsValid)
            {
                //riesgoResidual = CalculoRiesgo(riesgoResidual);
                _context.Add(riesgoResidual);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            //List<string> tol = new List<string> { "<10%", "<30%", "<50%" };
            //ViewBag.TipoTol = new SelectList(tol);
            //var activos = await _context.Activo.Select(m => m.Identificador).Distinct().ToListAsync();
            //ViewBag.ActivoList = new SelectList(activos);
            //var vulnerabilidad = await _context.Vulnerabilidad.Select(m => m.Codigo).Distinct().ToListAsync();
            //ViewBag.VulnerabilidadList = new SelectList(vulnerabilidad);
            var control = await _context.Control.Select(m => m.Codigo).Distinct().ToListAsync();
            ViewBag.ControlList = new SelectList(control);

            return View(riesgoResidual);
        }

        // GET: RiesgoResiduals/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.RiesgoResidual == null)
            {
                return NotFound();
            }

            var riesgoResidual = await _context.RiesgoResidual.FindAsync(id);
            if (riesgoResidual == null)
            {
                return NotFound();
            }

            List<string> tol = new List<string> { "<10%", "<30%", "<50%"};
            ViewBag.TipoTol = new SelectList(tol);
            var activos = await _context.Activo.Select(m => m.Identificador).Distinct().ToListAsync();
            ViewBag.ActivoList = new SelectList(activos);
            var vulnerabilidad = await _context.Vulnerabilidad.Select(m => m.Codigo).Distinct().ToListAsync();
            ViewBag.VulnerabilidadList = new SelectList(vulnerabilidad);
            var control = await _context.Control.Select(m => m.Codigo).Distinct().ToListAsync();
            ViewBag.ControlList = new SelectList(control);

            return View(riesgoResidual);
        }

        // POST: RiesgoResiduals/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Activo,Vulnerabilidad,Responsable,Tolerancia,NuevoControl,RiesgoRes,NuevoNivRiesgo")] RiesgoResidual riesgoResidual)
        {
            if (id != riesgoResidual.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    riesgoResidual = CalculoRiesgo(riesgoResidual);
                    _context.Update(riesgoResidual);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RiesgoResidualExists(riesgoResidual.Id))
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

            //List<string> tol = new List<string> { "<10%", "<30%", "<50%" };
            //ViewBag.TipoTol = new SelectList(tol);
            //var activos = await _context.Activo.Select(m => m.Identificador).Distinct().ToListAsync();
            //ViewBag.ActivoList = new SelectList(activos);
            //var vulnerabilidad = await _context.Vulnerabilidad.Select(m => m.Codigo).Distinct().ToListAsync();
            //ViewBag.VulnerabilidadList = new SelectList(vulnerabilidad);
            var control = await _context.Control.Select(m => m.Codigo).Distinct().ToListAsync();
            ViewBag.ControlList = new SelectList(control);

            return View(riesgoResidual);
        }

        // GET: RiesgoResiduals/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.RiesgoResidual == null)
            {
                return NotFound();
            }

            var riesgoResidual = await _context.RiesgoResidual
                .FirstOrDefaultAsync(m => m.Id == id);
            if (riesgoResidual == null)
            {
                return NotFound();
            }

            return View(riesgoResidual);
        }

        // POST: RiesgoResiduals/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.RiesgoResidual == null)
            {
                return Problem("Entity set 'ApplicationDbContext.RiesgoResidual'  is null.");
            }
            var riesgoResidual = await _context.RiesgoResidual.FindAsync(id);
            if (riesgoResidual != null)
            {
                _context.RiesgoResidual.Remove(riesgoResidual);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RiesgoResidualExists(int id)
        {
          return (_context.RiesgoResidual?.Any(e => e.Id == id)).GetValueOrDefault();
        }

        private RiesgoResidual CalculoRiesgo(RiesgoResidual riesgoResidual)
        {
            SQLController scon = new SQLController();
            List<Activo> activos = new List<Activo>();
            List<Control> controles = new List<Control>();
            List<Vulnerabilidad> vulnerabilidades = new List<Vulnerabilidad>();

            int criticidad = 0;
            int eficiencia = 0;
            int nivAmenaza = 0;
            int nivVul = 0;
            int tol = 0;
            activos = scon.GetDataAct();
            controles = scon.GetDataContr();
            vulnerabilidades = scon.GetDataVul();

            foreach (var item in activos)
            {
                if (item.Identificador.Equals(riesgoResidual.Activo))
                {
                    criticidad = item.Criticidad;
                }
            }

            foreach (var item1 in controles)
            {
                if (item1.Codigo.Equals(riesgoResidual.NuevoControl))
                {
                    eficiencia = item1.Eficiencia;
                }
            }

            foreach (var item1 in vulnerabilidades)
            {
                if (item1.Codigo.Equals(riesgoResidual.Vulnerabilidad))
                {
                    nivAmenaza = item1.NivAmenaza;
                    nivVul = item1.NivVulnerabilidad;
                }
            }

            int riesgoCalculo = nivAmenaza * nivVul * criticidad;

            if (riesgoResidual.Tolerancia.Equals("<10%"))
            {
                tol = 5;
            }
            else if (riesgoResidual.Tolerancia.Equals("<30%"))
            {
                tol = 10;
            }
            else
            {
                tol = 15;
            }

            int riesgoRes = riesgoCalculo - tol - eficiencia;

            if (riesgoRes > 0)
            {
                riesgoResidual.RiesgoRes = riesgoRes;
            }
            else
            {
                riesgoResidual.RiesgoRes = 1;
                riesgoRes = 1;
            }

            string riesgo;

            if (riesgoRes >= 1 && riesgoRes < 4)
            {
                riesgo = "Bajo";
            }
            else if (riesgoRes >= 4 && riesgoRes < 9)
            {
                riesgo = "Medio";
            }
            else
            {
                riesgo = "Alto";
            }

            riesgoResidual.NuevoNivRiesgo = riesgo;

            return riesgoResidual;
        }
    }
}
