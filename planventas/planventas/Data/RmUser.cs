using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace planventas.Data
{
    public partial class RmUser
    {
        [Key]
        public long Id { get; set; }
        public string Usuario { get; set; }
        public string Password { get; set; }
        public string Nombre { get; set; }
        public string Estado { get; set; }
        public string Usuario_Registro { get; set; }
        public string Role { get; set; }
        public string Email { get; set; }
    }
}
