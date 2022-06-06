using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace planventas.Data
{
    public class Pos_Tipo_Instalacion
    {

        public Pos_Tipo_Instalacion()
        {
            Instalaciones = new HashSet<Pos_Instalacion>();
        }
        [Key]
        public long Cod_TipoInstalacion { get; set; }
        [Display(Name = "Descripción")]
        [Required]
        [Column(TypeName = "varchar(500)")]
        public string Des_TipoInstalacion { get; set; }
        [Display(Name = "Estado")]
        [Column(TypeName = "varchar(1)")]
        [DefaultValue("G")]
        public string Estado { get; set; }
        [DefaultValue("(GetDate())")]
        public DateTime? Fecha_Registro { get; set; }
        [Column(TypeName = "varchar(50)")]
        public string Usuario_Registro { get; set; }
        public DateTime? Fecha_Borra { get; set; }
        [Column(TypeName = "varchar(50)")]
        public string Usuario_Borra { get; set; }
        [Column(TypeName = "varchar(500)")]
        public string Motivo_Borra { get; set; }

         public virtual ICollection<Pos_Instalacion> Instalaciones { get; set; } 

    }
}
