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
    public class Pos_EntrenadoresController : Controller
    {
        private readonly Context _context;

        public Pos_EntrenadoresController(Context context)
        {
            _context = context;
        }

        // GET: Pos_Entrenadores
        public async Task<IActionResult> Index()
        {
            var comiteContext = _context.Pos_Entrenadores.Include(p => p.Pos_Instalacion);
            return View(await comiteContext.ToListAsync());
        }

        // GET: Pos_Entrenadores/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pos_Entrenador = await _context.Pos_Entrenadores
                .Include(p => p.Pos_Instalacion)
                .FirstOrDefaultAsync(m => m.Cod_Entrenador == id);
            if (pos_Entrenador == null)
            {
                return NotFound();
            }

            return View(pos_Entrenador);
        }

        // GET: Pos_Entrenadores/Create
        public IActionResult Create()
        {
            ViewData["Cod_Instalacion"] = new SelectList(_context.Pos_Instalaciones, "Cod_Instalacion", "Des_Direccion");
            return View();
        }

        // POST: Pos_Entrenadores/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Cod_Entrenador,Cod_Instalacion,Nom_Entrenador,Des_Perfil,Dir_Imagen,Estado,Fecha_Registro,Usuario_Registro,Fecha_Borra,Usuario_Borra,Motivo_Borra")] Pos_Entrenador pos_Entrenador)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    pos_Entrenador.Usuario_Registro = "nmourelo";
                    _context.Add(pos_Entrenador);
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
            ViewData["Cod_Instalacion"] = new SelectList(_context.Pos_Instalaciones, "Cod_Instalacion", "Des_Direccion", pos_Entrenador.Cod_Instalacion);
            return View(pos_Entrenador);
        }

        // GET: Pos_Entrenadores/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pos_Entrenador = await _context.Pos_Entrenadores.FindAsync(id);
            if (pos_Entrenador == null)
            {
                return NotFound();
            }
            ViewData["Cod_Instalacion"] = new SelectList(_context.Pos_Instalaciones, "Cod_Instalacion", "Des_Direccion", pos_Entrenador.Cod_Instalacion);
            return View(pos_Entrenador);
        }

        // POST: Pos_Entrenadores/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("Cod_Entrenador,Cod_Instalacion,Nom_Entrenador,Des_Perfil,Dir_Imagen,Estado,Fecha_Registro,Usuario_Registro,Fecha_Borra,Usuario_Borra,Motivo_Borra")] Pos_Entrenador pos_Entrenador)
        {
            if (id != pos_Entrenador.Cod_Entrenador)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(pos_Entrenador);
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
            ViewData["Cod_Instalacion"] = new SelectList(_context.Pos_Instalaciones, "Cod_Instalacion", "Des_Direccion", pos_Entrenador.Cod_Instalacion);
            return View(pos_Entrenador);
        }

        // GET: RhPuestos/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pos_Entrenador = await _context.Pos_Entrenadores
                .Include(p => p.Cod_Entrenador)
                .FirstOrDefaultAsync(m => m.Cod_Instalacion == id);
            if (pos_Entrenador == null)
            {
                return NotFound();
            }
            _context.Pos_Entrenadores.Remove(pos_Entrenador);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));

        }


        private bool Pos_EntrenadorExists(long id)
        {
            return _context.Pos_Entrenadores.Any(e => e.Cod_Entrenador == id);
        }
    }
}
