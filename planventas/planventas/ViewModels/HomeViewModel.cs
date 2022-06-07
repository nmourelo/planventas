using planventas.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace planventas.ViewModels
{
    public class HomeViewModel
    {
        public ICollection<Pos_Servicio> Products { get; set; }

        public float Quantity { get; set; }
    }
}
