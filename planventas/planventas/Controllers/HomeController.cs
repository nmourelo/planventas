using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using planventas.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using planventas.Models.DBContext;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using planventas.Utilitarios;

namespace planventas.Controllers
{
    public class HomeController : Controller
    {

        private readonly Context _hsjdContext;

        public HomeController(Context hsjdContext)
        {

            _hsjdContext = hsjdContext;
        }

        public IActionResult Index()
        {
            return View();
        }

        //metodo para llamar el login al ingresar a las opciones del sistema
        [HttpGet]
        public IActionResult Sistema()
        {
            ViewData["RegresaDir"] = "/Home/Privacy";
            return View("Sistema");
        }

        [HttpPost("Sistema")]
        public async Task<IActionResult> LoginValidation(string usuario, string password, string returnUrl)
        {
            ViewData["RegresaDir"] = returnUrl;

            //para llamar el procedimiento que encripta la contraseña con el sha256.  
            //procedimiento llamado desde el ejemplo del sistema de ventas.
            var contra = Encriptar.Getsha256(password);
            //TODO- cuando se agregue un usuario hay que utilizar este procedimiento para que la contraseña quede con esta encriptacion
            //Todavia no se esta utilizando,  hay que crear la ventana para crear usuarios en el nuevo sistema y que el usuario actualice su contraseña.
            //la opcción olvidó la contraseña.
            var Myuser = _hsjdContext.Rm_Usuarios.Where(f => f.Usuario == usuario && f.Password == password).FirstOrDefault();
            if (Myuser != null)
            {
                var claims = new List<Claim>
                {
                    new Claim("usuario", usuario),
                    new Claim(ClaimTypes.NameIdentifier, Myuser.Usuario),
                    new Claim(ClaimTypes.Name, Myuser.Nombre),
                    new Claim(ClaimTypes.Role, Myuser.Role),
                    new Claim(ClaimTypes.Email, Myuser.Email)
                };
                var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                var claimsPrincipal = new ClaimsPrincipal(claimsIdentity);
                await HttpContext.SignInAsync(claimsPrincipal,  new AuthenticationProperties { IsPersistent  = true});
                return Redirect(returnUrl);
            }
            else
            {
                ViewData["Error"] = "Usuario o contraseña incorrectos...";
                return View("Sistema");
            }
        }


        [Route("error/404")]
        public IActionResult Error404()
        {
            return View();
        }


        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
