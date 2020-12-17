using System.Linq;
using System.Threading.Tasks;
using TesteLogin.Business.Entities;
using TesteLogin.Business.Repositories;

namespace TesteLogin.Infraestruture.data.repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly SkyDbContext _contexto;

        public UsuarioRepository(SkyDbContext contexto)
        {
            _contexto = contexto;
        }

        public void Adicionar(Usuario usuario)
        {
            _contexto.Usuario.Add(usuario);
        }

        public void Commit()
        {
            _contexto.SaveChanges();
        }

        public async Task<Usuario> ObterUsuario(string login)
        {
            return _contexto.Usuario.FirstOrDefault(u => u.Login == login);
        }
    }
}
