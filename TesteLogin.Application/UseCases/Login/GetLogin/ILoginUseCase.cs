using System.Threading.Tasks;
using TesteLogin.Application.Dto;

namespace TesteLogin.Application.UseCases.Login.GetLogin
{
    public interface ILoginUseCase
    {
        Task<LoginDto> Execute(string usuario, string password);
    }
}
