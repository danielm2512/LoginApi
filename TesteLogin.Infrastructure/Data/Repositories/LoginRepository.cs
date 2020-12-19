using System.Data;
using System.Threading.Tasks;
using Dapper;
using System.Data.SqlClient;
using TesteLogin.Domain.Stores;
using System;
using TesteLogin.Application.Repositories;

namespace TesteLogin.Infrastructure.Data.Repositories
{
    public class LoginRepository : ILoginReadOnlyRepository
    {
        private readonly string connectionString;

        public LoginRepository(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public async Task<Login> Get(string usuario, string password)
        {
            try
            {
                using (IDbConnection db = new SqlConnection(connectionString))
                {
                    string accountSQL = @"SELECT * FROM TB_USUARIO where Usuario = @usuario and Password = @password";
                    Entities.Login obj = await db
                        .QueryFirstOrDefaultAsync<Entities.Login>(accountSQL, new { usuario, password });

                    if (obj == null)
                        return null;

                    return Login.Load(obj.Id, obj.Usuario, obj.Password, obj.Email);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
