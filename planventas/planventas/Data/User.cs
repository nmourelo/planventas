using Microsoft.AspNetCore.Identity;
using planventas.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace planventas.Data
{
    public class User : IdentityUser
    {

        [Display(Name = "Documento")]
        [MaxLength(25, ErrorMessage = "El campo {0} debe tener máximo {1} caractéres.")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        [Column(TypeName = "varchar(25)")]
        public string Document { get; set; }

        [Display(Name = "Nombre")]
        [MaxLength(50, ErrorMessage = "El campo {0} debe tener máximo {1} caractéres.")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        [Column(TypeName = "varchar(50)")]
        public string FirstName { get; set; }

        [Display(Name = "Primer Apellido")]
        [MaxLength(70, ErrorMessage = "El campo {0} debe tener máximo {1} caractéres.")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        [Column(TypeName = "varchar(70)")]
        public string LastName { get; set; }

        [Display(Name = "Segundo Apellido")]
        [MaxLength(70, ErrorMessage = "El campo {0} debe tener máximo {1} caractéres.")]
        [Column(TypeName = "varchar(70)")]
        public string LastName2 { get; set; }

        [Display(Name = "Género")]
        [Column(TypeName = "varchar(10)")]
        public string Sexo { get; set; }

        //[Display(Name = "Foto")]
        //public Guid ImageId { get; set; }

        ////TODO: Pending to put the correct paths
        //[Display(Name = "Foto")]
        //public string ImageFullPath => ImageId == Guid.Empty
        //    ? $"https://localhost:7057/images/noimage.png"
        //    : $"https://shoppingprep.blob.core.windows.net/users/{ImageId}";


        [Display(Name = "Tipo de usuario")]
        public UserType UserType { get; set; }

        //[Display(Name = "Ciudad")]
        //public City City { get; set; }

        [Display(Name = "Usuario")]
        public string FullName => $"{FirstName} {LastName} {LastName2}";

        [Display(Name = "Usuario")]
        public string FullNameWithDocument => $"{FirstName} {LastName} - {Document}";

    }
}
