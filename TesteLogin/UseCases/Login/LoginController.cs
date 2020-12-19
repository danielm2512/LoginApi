using Dapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Swashbuckle.AspNetCore.Annotations;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using TesteLogin.Business.Entities;
using TesteLogin.Filter;
using TesteLogin.Infraestruture.data;
using TesteLogin.Models.Usuarios;
using TesteLogin.Application.UseCases.Login;
using TesteLogin.Application.Repositories;
using TesteLogin.Domain.Stores;
using TesteLogin.Controllers;

namespace TesteLogin.UseCases.Login
{
    [Route("[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly Configuration.IAuthenticationService _authenticationService;
        private readonly ILoginReadOnlyRepository _loginReadOnlyRepository;

        public LoginController(
            Configuration.IAuthenticationService authenticationService,
            ILoginReadOnlyRepository loginReadOnlyRepository)
        {
            _authenticationService = authenticationService;
            _loginReadOnlyRepository = loginReadOnlyRepository;
        }

        /// <summary>
        /// Este serviço permite autenticar um usuário cadastrado e ativo
        /// </summary>
        /// <param name="loginViewModelInput">View model do login</param>
        /// <returns>Retorna ok, dados do ususario e o token em caso de sucesso</returns>
        [SwaggerResponse(statusCode: 200, description: "Sucesso ao autenticar", Type = typeof(LoginViewModelInput))]
        [SwaggerResponse(statusCode: 400, description: "Campos obrigatorios", Type = typeof(ValidaCampoViewModelOutput))]
        [SwaggerResponse(statusCode: 500, description: "Erro interno", Type = typeof(ErrorGenericoViewModel))]
        [HttpPost]
        [Route("logar")]
        [ValidacaoModelStateCustomizado]
        public async Task<IActionResult> Logar(LoginRequest login)
        {

            var optionsBuilder = new DbContextOptionsBuilder<SkyDbContext>();
            optionsBuilder.UseSqlServer("Server=localhost\\SQLEXPRESS;Database=Curso;Trusted_Connection = True");
            SkyDbContext contexto = new SkyDbContext(optionsBuilder.Options);



            var usuario = _loginReadOnlyRepository.Get(login.Usuario, login.Password);


            //var usuarioViewModelOutput = new UsuarioViewModelOutput()
            //{
            //    Codigo = usuario.Id,
            //    Login = usuario.,
            //    Email = usuario.Email

            //};

            //var token = _authenticationService.GerarToken(usuario);

            return Ok(new
            {
                //Token = token,
                Usuario = usuario
            });
        }

        [HttpPost]
        [Route("Registrar")]
        [ValidacaoModelStateCustomizado]
        public IActionResult Registrar(RegistroViewModelInput loginViewModelInput)
        {

            var optionsBuilder = new DbContextOptionsBuilder<SkyDbContext>();
            optionsBuilder.UseSqlServer("Server=localhost\\SQLEXPRESS;Database=Curso;Trusted_Connection = True");
            SkyDbContext contexto = new SkyDbContext(optionsBuilder.Options);


            var usuario = new Usuario();
            usuario.Login = loginViewModelInput.Login;
            usuario.Senha = loginViewModelInput.Senha;
            usuario.Email = loginViewModelInput.Email;
            contexto.Add(usuario);
            contexto.SaveChanges();



            return Created("", loginViewModelInput);
        }
    }
}
