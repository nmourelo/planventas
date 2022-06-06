using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using planventas.Data;
using planventas.Models.DBContext;
using System.Linq;

namespace planventas.Utilitarios
{
    public class Utilities
    {
        //public static string GetJefe(string Usuario, Context db)
        //{
        //    string Resultado = db.Fn_Devuelve_Usuario_Jefe.FromSqlInterpolated($"select dbo.Fn_Devuelve_Usuario_Jefe ({Usuario}) as UsuarioJefe").FirstOrDefault().UsuarioJefe.ToString();       
        //    return Resultado;
        //}

        //Devuelve el usuario solicitante de la solicitud de asistencia.
        //primero selecciona la identificacion de la  tabla empleados a partir del id del empleado.
        //Segundo devuelve el usuario  con la identificacion obtenida en el primer select
        //public static string GetUserEmployee(string dIdenti, Context db)
        //{
        //    var MyIdenti = db.Vw_Empleados.FirstOrDefault(x=>x.ID.ToString() == dIdenti).Identificacion.ToString();


        //    var uEmploy = db.UsuariosPlan2000.Where(f => f.Identificacion == MyIdenti).FirstOrDefault().Usuario.ToString();
        //    return uEmploy;
        //}

        //public static string GetIdentiFromUser(string dUser, Context db)
        //{
        //    var MyIdenti = db.UsuariosPlan2000.FirstOrDefault(x => x.Usuario == dUser).Identificacion.ToString();
        //    return MyIdenti;
        //}


        //Nestor Util cuando se utiliza cuentas de usuario en la aplicacion de nueva y se personaliza.
        //public class MyErrorDescriber : IdentityErrorDescriber
        //{
        //    public override IdentityError InvalidEmail(string email)
        //    {
        //        return new IdentityError
        //        {
        //            Code = nameof(InvalidEmail),
        //            Description = "El formato de la dirección de correo no es válida"

        //        };
        //    }
        //}


    }
}
