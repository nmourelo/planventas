using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace planventas.Data
{
    public class Pos_Servicio
    {
        [Key]
        public long IdServicio { get; set; }
        [Required]
        public int Cod_Servicio { get; set; }
        [Required]
        [ForeignKey("Pos_Instalacion")]
        public long Cod_Instalacion { get; set; }
        [Required]
        public int CodDia { get; set; }
        [StringLength(25)]
        public string Dia { get; set; }
        [Required]
        [Column(TypeName = "varchar")]
        [StringLength(50)]
        public string Horario { get; set; }
        [Required]
        [Column(TypeName = "varchar")]
        [StringLength(25)]
        public string Categoria { get; set; }
        [Display(Name ="Servicio")]
        [Column(TypeName = "varchar")]
        [Required]
        [StringLength(750)]
        public string Des_Servicio { get; set; }
        [Required]
        [Display(Name = "Tarifa")]
        [Column(TypeName = "money")]
        public decimal Tarifa { get; set; }
        [Required]
        [Display(Name = "Cupos")]
        public int Cupos { get; set; }
        [Display(Name = "Moneda")]
        public int Cod_Moneda { get; set; }

        public virtual Pos_Instalacion Pos_Instalacion { get; set; }
 


    }
}
