using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using planventas.Data;
using planventas.Models.DBContext;

namespace planventas.Controllers
{
    public class Pos_InstalacionesController : Controller
    {
        private readonly Context _context;

        public Pos_InstalacionesController(Context context)
        {
            _context = context;
        }

        // GET: Pos_Instalaciones
        public async Task<IActionResult> Index()
        {
            var comiteContext = _context.Pos_Instalaciones.Include(p => p.Pos_Tipo_Instalacion);
            return View(await comiteContext.ToListAsync());
        }

        // GET: Pos_Instalaciones/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pos_Instalacion = await _context.Pos_Instalaciones
                .Include(p => p.Pos_Tipo_Instalacion)
                .FirstOrDefaultAsync(m => m.Cod_Instalacion == id);
            if (pos_Instalacion == null)
            {
                return NotFound();
            }

            return View(pos_Instalacion);
        }

        // GET: Pos_Instalaciones/Create
        public IActionResult Create()
        {
            ViewData["Cod_TipoInstalacion"] = new SelectList(_context.Pos_Tipos_Instalacion, "Cod_TipoInstalacion", "Des_TipoInstalacion");
            return View();
        }

        // POST: Pos_Instalaciones/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Cod_Instalacion,Cod_TipoInstalacion,Des_Instalacion,Des_Direccion,Num_Telefono,Dir_Imagenes,Estado,Fecha_Registro,Usuario_Registro,Fecha_Borra,Usuario_Borra,Motivo_Borra")] Pos_Instalacion pos_Instalacion)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    pos_Instalacion.Usuario_Registro = "nmourelo";
                    _context.Add(pos_Instalacion);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                catch (DbUpdateException dbUpdateException)
                {
                    if (dbUpdateException.InnerException.Message.Contains("duplicate"))
                    {
                        ModelState.AddModelError(string.Empty, "Ya existe este código registrado en la base de datos.");
                    }
                    else
                    {
                        ModelState.AddModelError(string.Empty, dbUpdateException.InnerException.Message);
                    }
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError(string.Empty, ex.Message);
                }
            }
            ViewData["Cod_TipoInstalacion"] = new SelectList(_context.Pos_Tipos_Instalacion, "Cod_TipoInstalacion", "Des_TipoInstalacion", pos_Instalacion.Cod_TipoInstalacion);
            return View(pos_Instalacion);
        }

        // GET: Pos_Instalaciones/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var pos_Instalacion = await _context.Pos_Instalaciones.FindAsync(id);
            if (pos_Instalacion == null)
            {
                return NotFound();
            }
            ViewData["Cod_TipoInstalacion"] = new SelectList(_context.Pos_Tipos_Instalacion, "Cod_TipoInstalacion", "Des_TipoInstalacion", pos_Instalacion.Cod_TipoInstalacion);
            return View(pos_Instalacion);
        }

        // POST: Pos_Instalaciones/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("Cod_Instalacion,Cod_TipoInstalacion,Des_Instalacion,Des_Direccion,Num_Telefono,Dir_Imagenes,Estado,Fecha_Registro,Usuario_Registro,Fecha_Borra,Usuario_Borra,Motivo_Borra")] Pos_Instalacion pos_Instalacion)
        {
            
            if (id != pos_Instalacion.Cod_Instalacion)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(pos_Instalacion);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                catch (DbUpdateException dbUpdateException)
                {
                    if (dbUpdateException.InnerException.Message.Contains("duplicate"))
                    {
                        ModelState.AddModelError(string.Empty, "Ya existe este código registrado en la base de datos.");
                    }
                    else
                    {
                        ModelState.AddModelError(string.Empty, dbUpdateException.InnerException.Message);
                    }
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError(string.Empty, ex.Message);
                }
            }
            ViewData["Cod_TipoInstalacion"] = new SelectList(_context.Pos_Tipos_Instalacion, "Cod_TipoInstalacion", "Des_TipoInstalacion", pos_Instalacion.Cod_TipoInstalacion);
            return View(pos_Instalacion);
        }

        // GET: RhPuestos/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pos_Instalacion = await _context.Pos_Instalaciones
                .Include(p => p.Pos_Tipo_Instalacion)
                .FirstOrDefaultAsync(m => m.Cod_Instalacion == id);
            if (pos_Instalacion == null)
            {
                return NotFound();
            }
            _context.Pos_Instalaciones.Remove(pos_Instalacion);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));

        }

        private bool Pos_InstalacionExists(long id)
        {
            return _context.Pos_Instalaciones.Any(e => e.Cod_Instalacion == id);
        }
    }
}
