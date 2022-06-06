using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace planventas.Data
{
    public class Pos_Dia
    {
        [Key]
        [Required]
        [Display(Name ="Código")]
        public int CodDia { get; set; }
        [Required]
        [Display(Name = "Nombre")]
        [StringLength(35)]
        public string NomDia { get; set; }

        public virtual ICollection<Pos_Servicio> Servicios { get; set; }

    }
}
