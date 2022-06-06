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
    public class Pos_Tipos_InstalacionController : Controller
    {
        private readonly Context _context;

        public Pos_Tipos_InstalacionController(Context context)
        {
            _context = context;
        }

        // GET: Pos_Tipos_Instalacion
        public async Task<IActionResult> Index()
        {
            return View(await _context.Pos_Tipos_Instalacion.ToListAsync());
        }

        // GET: Pos_Tipos_Instalacion/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pos_Tipo_Instalacion = await _context.Pos_Tipos_Instalacion
                .FirstOrDefaultAsync(m => m.Cod_TipoInstalacion == id);
            if (pos_Tipo_Instalacion == null)
            {
                return NotFound();
            }

            return View(pos_Tipo_Instalacion);
        }

        // GET: Pos_Tipos_Instalacion/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Pos_Tipos_Instalacion/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Cod_TipoInstalacion,Des_TipoInstalacion,Estado,Fecha_Registro,Usuario_Registro,Fecha_Borra,Usuario_Borra,Motivo_Borra")] Pos_Tipo_Instalacion pos_Tipo_Instalacion)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    pos_Tipo_Instalacion.Usuario_Registro = "nmourelo";
                    _context.Add(pos_Tipo_Instalacion);
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
            return View(pos_Tipo_Instalacion);
        }

        // GET: Pos_Tipos_Instalacion/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pos_Tipo_Instalacion = await _context.Pos_Tipos_Instalacion.FindAsync(id);
            if (pos_Tipo_Instalacion == null)
            {
                return NotFound();
            }
            return View(pos_Tipo_Instalacion);
        }

        // POST: Pos_Tipos_Instalacion/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("Cod_TipoInstalacion,Des_TipoInstalacion,Estado,Fecha_Registro,Usuario_Registro,Fecha_Borra,Usuario_Borra,Motivo_Borra")] Pos_Tipo_Instalacion pos_Tipo_Instalacion)
        {
            if (id != pos_Tipo_Instalacion.Cod_TipoInstalacion)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(pos_Tipo_Instalacion);
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
            return View(pos_Tipo_Instalacion);
        }


        // GET: Pos_Tipos_Instalacion/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var pos_Tipo_Instalacion = await _context.Pos_Tipos_Instalacion.FindAsync(id);
            if (pos_Tipo_Instalacion == null)
            {
                return NotFound();
            }
            _context.Pos_Tipos_Instalacion.Remove(pos_Tipo_Instalacion);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }


        private bool Pos_Tipo_InstalacionExists(long id)
        {
            return _context.Pos_Tipos_Instalacion.Any(e => e.Cod_TipoInstalacion == id);
        }
    }
}
