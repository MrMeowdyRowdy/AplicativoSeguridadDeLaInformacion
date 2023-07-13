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
        public async Task<IActionResult> Create([Bind("Id,Amenaza,Activo,Codigo,NivAmenaza,NivVulnerabilidad,ControlAplicado,ValorRiesgo,RiesgoInherente")] Vulnerabilidad vulnerabilidad)
        {
            if (ModelState.IsValid)
            {
                vulnerabilidad = CalculoRiesgo(vulnerabilidad);
                InsertRiesgoResidual(vulnerabilidad);
                _context.Add(vulnerabilidad);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

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
        public async Task<IActionResult> Edit(int id, [Bind("Id,Amenaza,Activo,Codigo,NivAmenaza,NivVulnerabilidad,ControlAplicado,ValorRiesgo,RiesgoInherente")] Vulnerabilidad vulnerabilidad)
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
            int riesgoIn = 0;
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
                if (item1.Codigo.Equals(vulnerabilidades.ControlAplicado))
                {
                    eficiencia = item1.Eficiencia;
                }
            }

            int riesgoCalculo = vulnerabilidades.NivAmenaza * vulnerabilidades.NivVulnerabilidad * criticidad;

            string riesgo;

            if (riesgoCalculo >= 1 && riesgoCalculo < 4)
            {
                riesgo = "Bajo";
                riesgoIn = riesgoCalculo;
            }
            else if (riesgoCalculo >= 4 && riesgoCalculo < 9)
            {
                riesgo = "Medio";
                riesgoIn = riesgoCalculo;
            }
            else
            {
                riesgo = "Alto";
                riesgoIn = riesgoCalculo;
            }
            vulnerabilidades.RiesgoInherente = riesgo;
            vulnerabilidades.ValorRiesgo = riesgoIn;

            return vulnerabilidades;
        }

        public ActionResult InsertRiesgoResidual(Vulnerabilidad model)
        {
            try
            {
                // Create an instance of the RiesgoResidual model and populate its properties
                RiesgoResidual riesgoResidual = new RiesgoResidual
                {
                    Activo = model.Activo,
                    Vulnerabilidad = model.Codigo,
                    Responsable = " ",
                    Tolerancia = " ",
                    NuevoControl = " ",
                    RiesgoRes = 0,
                    NuevoNivRiesgo = " "
                };

                // Establish a connection to your SQL database
                string connectionString = "YourConnectionString";
                using (SqlConnection connection = new SqlConnection("Server=DESKTOP-G6T119Q;Database=AplicativoSeguridad;Trusted_Connection=True;MultipleActiveResultSets=true"))
                {
                    connection.Open();

                    // Construct the SQL query/command to insert the data
                    string sqlQuery = "INSERT INTO RiesgoResidual (Activo, Vulnerabilidad, Responsable, Tolerancia, NuevoControl, RiesgoRes, NuevoNivRiesgo) " +
                                      "VALUES (@Activo, @Vulnerabilidad, @Responsable, @Tolerancia, @NuevoControl, @RiesgoRes, @NuevoNivRiesgo)";

                    using (SqlCommand command = new SqlCommand(sqlQuery, connection))
                    {
                        // Set parameter values
                        command.Parameters.AddWithValue("@Activo", riesgoResidual.Activo);
                        command.Parameters.AddWithValue("@Vulnerabilidad", riesgoResidual.Vulnerabilidad);
                        command.Parameters.AddWithValue("@Responsable", riesgoResidual.Responsable);
                        command.Parameters.AddWithValue("@Tolerancia", riesgoResidual.Tolerancia);
                        command.Parameters.AddWithValue("@NuevoControl", riesgoResidual.NuevoControl);
                        command.Parameters.AddWithValue("@RiesgoRes", riesgoResidual.RiesgoRes);
                        command.Parameters.AddWithValue("@NuevoNivRiesgo", riesgoResidual.NuevoNivRiesgo);

                        // Execute the SQL command to insert the data
                        command.ExecuteNonQuery();
                    }

                    connection.Close();
                }

                // Data inserted successfully
                return RedirectToAction("Index", "Home"); // Redirect to a success page or desired view
            }
            catch (Exception ex)
            {
                // Handle the error
                return View("Error"); // Show an error page or desired view
            }
        }
    }
}
