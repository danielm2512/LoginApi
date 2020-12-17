using System.Threading.Tasks;
using TesteLogin.Business.Entities;

namespace TesteLogin.Business.Repositories
{
    public interface IUsuarioRepository
    {
        void Adicionar(Usuario usuario);
        void Commit();
        Task<Usuario> ObterUsuario(string login);
    }
}
