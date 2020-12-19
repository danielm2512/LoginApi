using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TesteLogin.UseCases.Login
{
    public sealed class LoginRequest
    {
        [Required(ErrorMessage = "O Usuario é obrigatorio")]
        public string Usuario { get; set; }
        [Required(ErrorMessage = "A Senha é obrigatoria")]
        public string Password { get; set; }
    }
}
