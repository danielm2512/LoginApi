using System;
using System.Collections.Generic;
using System.Text;
using TesteLogin.Domain.Stores;

namespace TesteLogin.Application.Dto
{
    public class LoginDto
    {
        public int Id { get; set; }
        public string Usuario { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public LoginDto() { }

        public LoginDto(Login login)
        {
            Id = login.Id;
            Usuario = login.Usuario;
            Password = login.Password;
            Email = login.Email;
        }
    }
}
