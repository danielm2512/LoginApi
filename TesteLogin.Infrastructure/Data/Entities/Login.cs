using System;
using System.Collections.Generic;
using System.Text;

namespace TesteLogin.Infrastructure.Data.Entities
{
    public class Login
    {
        public int Id { get; set; }
        public string Usuario { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
    }
}
