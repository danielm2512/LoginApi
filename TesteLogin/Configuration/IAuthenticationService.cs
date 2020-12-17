using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TesteLogin.Models.Usuarios;

namespace TesteLogin.Configuration
{
    public interface IAuthenticationService
    {
        string GerarToken(UsuarioViewModelOutput usuarioViewModelOutput);
    }
}
