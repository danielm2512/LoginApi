using System;
using System.Collections.Generic;
using System.Text;

namespace TesteLogin.Domain.Stores
{
    public sealed class Login
    {
        public int Id { get; private set; }
        public string Usuario { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }

        private Login() { }

        public static Login Load(int id, string usuario, string password, string email)
        {
            Login obj = new Login();
            obj.Id = id;
            obj.Usuario = usuario;
            obj.Password = password;
            obj.Email = email;
            return obj;
        }
    }
}
