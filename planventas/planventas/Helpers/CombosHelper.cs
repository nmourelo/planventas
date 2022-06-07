using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using planventas.Data;
using planventas.Models.DBContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace planventas.Helpers
{
    public class CombosHelper : ICombosHelper
    {
        private readonly Context _context;

        public CombosHelper(Context context)
        {
            _context = context;
        }
        public async Task<IEnumerable<SelectListItem>> GetComboInstalacionesAsync(int Cod_TipoInstalacion)
        {
            List<SelectListItem> List = await _context.Pos_Instalaciones.Where(s => s.Cod_TipoInstalacion == Cod_TipoInstalacion).Select(c => new SelectListItem
            {
                Text = c.Des_Instalacion,
                Value = c.Cod_Instalacion.ToString()
            }).OrderBy(c=> c.Text).ToListAsync();

            List.Insert(0, new SelectListItem { Text = "[Seleccione una Instalación...]", Value = "0" });
            return List;

        }

        public async Task<IEnumerable<SelectListItem>> GetComboTiposInstalacionesAsync()
        {
            List<SelectListItem> List = await _context.Pos_Tipos_Instalacion.Select(c => new SelectListItem
            {
                Text = c.Des_TipoInstalacion,
                Value = c.Cod_TipoInstalacion.ToString()
            }).OrderBy(c => c.Text).ToListAsync();

            List.Insert(0, new SelectListItem { Text = "[Seleccione un tipo de Instalación...]", Value = "0" });
            return List;
        }

        //Codigo Util. Implementacion de la interface con el combo filtrado.  en el video Tutorial 68 - C# desde cero - Parte 016 - minuto 47 en adelante - de zuluaga se muestra como utilizarlo
        public async Task<IEnumerable<SelectListItem>> GetComboTiposInstalacionesAsync(IEnumerable<Pos_Tipo_Instalacion> filtro)
        {
            List<Pos_Tipo_Instalacion> Tipos_Instalacion = await _context.Pos_Tipos_Instalacion.ToListAsync();
            List<Pos_Tipo_Instalacion> Tipos_Instalacion_Filtered = new();

            foreach (Pos_Tipo_Instalacion pos_Tipo_Instalacion in Tipos_Instalacion)
            {
                if (filtro.Any(c => c.Cod_TipoInstalacion == pos_Tipo_Instalacion.Cod_TipoInstalacion))
                {
                    Tipos_Instalacion_Filtered.Add(pos_Tipo_Instalacion);
                }
            }
            List<SelectListItem> List = Tipos_Instalacion_Filtered.Select(c => new SelectListItem
            {
                Text = c.Des_TipoInstalacion,
                Value = c.Cod_TipoInstalacion.ToString()
            }).OrderBy(c => c.Text).ToList();

            List.Insert(0, new SelectListItem { Text = "[Seleccione un tipo de Instalación...]", Value = "0" });
            return List;
        }
    }
}
