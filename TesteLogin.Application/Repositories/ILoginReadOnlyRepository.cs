using System.Threading.Tasks;
using TesteLogin.Domain.Stores;

namespace TesteLogin.Application.Repositories
{
    public interface ILoginReadOnlyRepository
    {
        Task<Login> Get(string login, string password);
    }
}
