using Microsoft.AspNetCore.Mvc;
using TesteLogin.Infrastructure.Data.Entities;
using TesteLogin.Domain.Stores;

namespace TesteLogin.UseCases.Login
{
    public sealed class LoginPresenter
    {
        public IActionResult ViewModel { get; private set; }

        public void Populate(LoginRequest output, Controller controller)
        {
            if (output == null)
            {
                ViewModel = new NoContentResult();
                return;
            }

            //var model = new Login(output.Id, output.UserId, output.FirstName, output.LastName, output.Email);
            //controller.HttpContext.Session.SetObjectAsJson("Login", model);
            //ViewModel = new ObjectResult(model);
        }
    }
}
