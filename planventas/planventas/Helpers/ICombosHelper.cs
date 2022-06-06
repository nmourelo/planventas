using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace planventas.Helpers
{
    interface ICombosHelper
    {
        Task<IEnumerable<SelectListItem>> GetComboTiposInstalacionesAsync();

        Task<IEnumerable<SelectListItem>> GetComboInstalacionesAsync(int Cod_TipoInstalacion);
    }
}
