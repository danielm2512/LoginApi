using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TesteLogin.Infrastructure.Data.Entities;
using TesteLogin.Models.Usuarios;

namespace TesteLogin.Configuration
{
    public interface IAuthenticationService
    {
        string GerarToken(Login login);
    }
}
