using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace planventas.Data
{
    public class Pos_Padron
    {
        public long ID { get; set; }

        [Display(Name = "Documento")]
        [MaxLength(25, ErrorMessage = "El campo {0} debe tener máximo {1} caractéres.")]
        [Column(TypeName = "varchar(25)")]
        public string Document { get; set; }

        [Display(Name = "Nombre")]
        [MaxLength(50, ErrorMessage = "El campo {0} debe tener máximo {1} caractéres.")]
        [Column(TypeName = "varchar(50)")]
        public string FirstName { get; set; }

        [Display(Name = "Primer Apellido")]
        [MaxLength(70, ErrorMessage = "El campo {0} debe tener máximo {1} caractéres.")]
        [Column(TypeName = "varchar(70)")]
        public string LastName { get; set; }

        [Display(Name = "Segundo Apellido")]
        [MaxLength(70, ErrorMessage = "El campo {0} debe tener máximo {1} caractéres.")]
        [Column(TypeName = "varchar(70)")]
        public string LastName2 { get; set; }

    }
}
