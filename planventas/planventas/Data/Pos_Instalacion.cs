using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace planventas.Data
{
    public class Pos_Instalacion
    {
        public Pos_Instalacion()
        {
            Entrenadores = new HashSet<Pos_Entrenador>();
        }

        [Key]
        public long Cod_Instalacion { get; set; }
        [Required]
        [Display(Name = "Tipo de Instalación")]
        [ForeignKey("Pos_Tipo_Instalacion")]
        public long Cod_TipoInstalacion { get; set; }
        [Display(Name = "Nombre")]
        [Required]
        [Column(TypeName = "varchar(900)")]
        public string Des_Instalacion { get; set; }
        [Display(Name = "Dirección")]
        [Required]
        [Column(TypeName = "varchar(900)")]
        public string Des_Direccion { get; set; }
        [Display(Name = "Teléfono")]
        [Required]
        [Column(TypeName = "varchar(20)")]
        public string Num_Telefono { get; set; }
        [Display(Name = "Imágenes")]
        [Required]
        [Column(TypeName = "varchar(900)")]
        public string Dir_Imagenes { get; set; }
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

 
        public virtual Pos_Tipo_Instalacion Pos_Tipo_Instalacion { get; set; }
        public virtual ICollection<Pos_Entrenador> Entrenadores { get; set; }
        public virtual ICollection<Pos_Servicio> Servicios { get; set; }
    }
}
