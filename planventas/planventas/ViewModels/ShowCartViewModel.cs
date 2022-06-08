using planventas.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace planventas.ViewModels
{
    public class ShowCartViewModel
    {
        public string Identificacion { get; set; }
        public long Cod_Instalacion { get; set; }
        [DataType(DataType.MultilineText)]
        [Display(Name = "Comentarios")]
        //TODO este era nulleable verificaar si quitndolo da error
        public string Remarks { get; set; }

        public ICollection<TemporalSale> TemporalSales { get; set; }

        [DisplayFormat(DataFormatString = "{0:N2}")]
        [Display(Name = "Cantidad")]
        public float Quantity => TemporalSales == null ? 0 : TemporalSales.Sum(ts => ts.Quantity);

        [DisplayFormat(DataFormatString = "{0:C2}")]
        [Display(Name = "Total")]
        public decimal Value => TemporalSales == null ? 0 : TemporalSales.Sum(ts => ts.Value);

    }
}
