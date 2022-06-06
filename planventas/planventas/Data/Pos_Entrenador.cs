using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace planventas.Data
{
    public class Pos_Entrenador
    {

        [Key]
        public long Cod_Entrenador { get; set; }
        [Required]
        [Display(Name = "Instalación")]
        [ForeignKey("Pos_Instalacion")]
        public long Cod_Instalacion { get; set; }
        [Display(Name = "Nombre")]
        [Required]
        [Column(TypeName = "varchar(900)")]
        public string Nom_Entrenador { get; set; }
        [Display(Name = "Perfil")]
        [Column(TypeName = "varchar(MAX)")]
        public string Des_Perfil { get; set; }
        [Display(Name = "Imágenes")]
        [Required]
        [Column(TypeName = "varchar(900)")]
        public string Dir_Imagen { get; set; }
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

        public virtual Pos_Instalacion Pos_Instalacion { get; set; }


    }
}
