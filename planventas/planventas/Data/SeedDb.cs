using planventas.Enums;
using planventas.Helpers;
using planventas.Models.DBContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace planventas.Data
{
    public class SeedDb
    {
        private readonly Context _context;
        private readonly IUserHelper _userHelper;

        public SeedDb(Context context, IUserHelper userHelper)
        {
            _context = context;
            _userHelper = userHelper;
        }

        public async Task SeedAsync()
        {
            await _context.Database.EnsureCreatedAsync();
            await CheckTiposInstalacionAsync();
            await CheckRolesAsync();
            await CheckUserAsync("204300495", "Néstor", "Mourelo", "nmourelo@yopmail.com", "8383-3087", UserType.Admin);


        }

        private async Task<User> CheckUserAsync(
            string document,
            string firstName,
            string lastName,
            string email,
            string phone,
            UserType userType)
        {
            User user = await _userHelper.GetUserAsync(email);
            if (user == null)
            {
                user = new User
                {
                    FirstName = firstName,
                    LastName = lastName,
                    Email = email,
                    UserName = email,
                    PhoneNumber = phone,
                    Document = document,
                    UserType = userType,
                };

                await _userHelper.AddUserAsync(user, "condorito");
                await _userHelper.AddUserToRoleAsync(user, userType.ToString());
            }

            return user;
        }


        private async Task CheckRolesAsync()
        {
            await _userHelper.CheckRoleAsync(UserType.Admin.ToString());
            await _userHelper.CheckRoleAsync(UserType.User.ToString());
        }

        private async Task CheckTiposInstalacionAsync()
        {
            if (!_context.Pos_Tipos_Instalacion.Any())
            {
                _context.Pos_Tipos_Instalacion.Add(new Pos_Tipo_Instalacion { Des_TipoInstalacion = "Centros Acuáticos", Usuario_Registro = "nmourelo" });
                _context.Pos_Tipos_Instalacion.Add(new Pos_Tipo_Instalacion { Des_TipoInstalacion = "Canchas de Fútbol", Usuario_Registro = "nmourelo" });
                _context.Pos_Tipos_Instalacion.Add(new Pos_Tipo_Instalacion { Des_TipoInstalacion = "Gimnasios", Usuario_Registro = "nmourelo" });
                _context.Pos_Tipos_Instalacion.Add(new Pos_Tipo_Instalacion { Des_TipoInstalacion = "Pista Atletismo", Usuario_Registro = "nmourelo" });
                _context.Pos_Tipos_Instalacion.Add(new Pos_Tipo_Instalacion { Des_TipoInstalacion = "Activides Varias", Usuario_Registro = "nmourelo" });
            }

            await _context.SaveChangesAsync();
        }
    }
}
