using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Swashbuckle.AspNetCore.Annotations;
using System.Data;
using System.Threading.Tasks;
using TesteLogin.Business.Entities;
using TesteLogin.Business.Repositories;
using TesteLogin.Filter;
using TesteLogin.Models.Usuarios;
using Dapper;
using Microsoft.EntityFrameworkCore;
using TesteLogin.Infraestruture.data;
using System.Linq;

namespace TesteLogin.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioRepository _usuariorepository;
        private readonly Configuration.IAuthenticationService _authenticationService;

        public UsuarioController(
            IUsuarioRepository usuariorepository,
            Configuration.IAuthenticationService authenticationService)
        {
            _usuariorepository = usuariorepository;
            _authenticationService = authenticationService;
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
        public async Task<IActionResult> Logar(LoginViewModelInput loginViewModelInput)
        {

            var optionsBuilder = new DbContextOptionsBuilder<SkyDbContext>();
            optionsBuilder.UseSqlServer("Server=localhost\\SQLEXPRESS;Database=Curso;Trusted_Connection = True");
            SkyDbContext contexto = new SkyDbContext(optionsBuilder.Options);

            //if (usuario == null)
            //{
            //    return BadRequest("Houve um erro ao tentar acessar.");
            //}

            using (IDbConnection db = new SqlConnection("Server=localhost\\SQLEXPRESS;Database = Curso;Trusted_Connection = True"))
            {
                string sql = @"SELECT * FROM TB_USUARIO where Login = @login and Senha = @senha";
                Usuario login = db
                    .QueryFirstOrDefault<Usuario>(sql, new { Login = loginViewModelInput.Login, Senha = loginViewModelInput.Senha });

                if (login == null)
                    return BadRequest("Houve um erro ao tentar acessar.");
            }
        

            Usuario usuario = contexto.Usuario.FirstOrDefault(u => u.Login == loginViewModelInput.Login);

            var usuarioViewModelOutput = new UsuarioViewModelOutput()
            {
                Codigo = usuario.Codigo,
                Login = loginViewModelInput.Login,
                Email = usuario.Email

            };

            var token = _authenticationService.GerarToken(usuarioViewModelOutput);

            return Ok(new
            {
                Token = token,
                Usuario = usuarioViewModelOutput
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
