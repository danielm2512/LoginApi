﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TesteLogin.Models.Usuarios
{
    public class LoginViewModelInput
    {
        [Required(ErrorMessage = "O Usuario é obrigatorio")]
        public string Usuario { get; set; }
        [Required(ErrorMessage = "A Senha é obrigatoria")]
        public string Senha { get; set; }
    }
}
