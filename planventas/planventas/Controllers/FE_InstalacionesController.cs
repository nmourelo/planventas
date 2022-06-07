using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using planventas.Models.DBContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Globalization;
using planventas.Data;
using planventas.ViewModels;

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

        public async Task<IActionResult> ListProductos(int? id)
        {
            List<Pos_Servicio>? products = await _context.Pos_Servicios.Where(w=>w.Cod_Instalacion == id).Include(p => p.Pos_Instalacion)
                .OrderBy(p => p.Des_Servicio)
                .ToListAsync();

            if (id != null) { 
                var Insta = _context.Pos_Instalaciones.FirstOrDefault(x => x.Cod_Instalacion == id);
                ViewData["Insta"] = Insta.Des_Instalacion;
            }
            HomeViewModel model = new() { Products = products };
            string Identi = "204300495";
            //User user = await _userHelper.GetUserAsync(User.Identity.Name);
            if (Identi != null)
            {
                model.Quantity = await _context.TemporalSales
                    .Where(ts => ts.Identificacion == Identi)
                    .SumAsync(ts => ts.Quantity);
            }
            return View(model);
        }

        public async Task<IActionResult> Add(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            //TODO Esto es para que no pueda agregar al carrito si no he registrado la id..
            //if (!User.Identity.IsAuthenticated)
            //{
            //    return RedirectToAction("Index", "Home");
            //}

            Pos_Servicio product = await _context.Pos_Servicios.FindAsync(Convert.ToInt64(id));
            if (product == null)
            {
                return NotFound();
            }
            //TODO el usuario registrado hay que ver como manejamos la persona que se registra
            //User user = await _userHelper.GetUserAsync(User.Identity.Name);
            //if (user == null)
            //{
            //    return NotFound();
            //}

            TemporalSale temporalSale = new()
            {
                Product = product,
                Quantity = 1,
                Identificacion = "204300495"
            };
            int Insta = (int)product.Cod_Instalacion;
            _context.TemporalSales.Add(temporalSale);
            await _context.SaveChangesAsync();
            return RedirectToAction("ListProductos", new { id = Insta });
        }





    }
}
