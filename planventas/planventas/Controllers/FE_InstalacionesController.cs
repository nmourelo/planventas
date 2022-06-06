using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using planventas.Models.DBContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Globalization;

namespace planventas.Controllers
{
    public class FE_InstalacionesController : Controller
    {

        private readonly Context _context;

        public FE_InstalacionesController(Context context)
        {
            _context = context;
        }


        public async Task<IActionResult> Index(int id)
        {
            var TipoInsta = _context.Pos_Tipos_Instalacion.FirstOrDefault(x => x.Cod_TipoInstalacion == id);

            if (TipoInsta != null) {  
            ViewData["TipoInsta"] = TipoInsta.Des_TipoInstalacion;
            }
            var comiteContext = _context.Pos_Instalaciones.Include(p => p.Pos_Tipo_Instalacion).Where(x => x.Cod_TipoInstalacion == id && x.Estado == "G");
            return View(await comiteContext.ToListAsync());
        }

        public IActionResult Productos(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var Insta = _context.Pos_Instalaciones.FirstOrDefault(x => x.Cod_Instalacion == id);

            ViewData["Insta"] = Insta.Des_Instalacion;
            
            var servi = _context.Pos_Servicios.Where(x => x.Cod_Instalacion == id).OrderBy(x=> x.Categoria);
            return View(servi.ToList());
        }

    }
}
