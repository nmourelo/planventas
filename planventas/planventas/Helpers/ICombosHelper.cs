using Microsoft.AspNetCore.Mvc.Rendering;
using planventas.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace planventas.Helpers
{
    interface ICombosHelper
    {
        Task<IEnumerable<SelectListItem>> GetComboTiposInstalacionesAsync();
        //Codigo Util. sobrecargamos el metodo para enviarle un filtro y que devuelva solo las que no estan en el filtro
        Task<IEnumerable<SelectListItem>> GetComboTiposInstalacionesAsync(IEnumerable<Pos_Tipo_Instalacion> filtro);

        Task<IEnumerable<SelectListItem>> GetComboInstalacionesAsync(int Cod_TipoInstalacion);
    }
}
