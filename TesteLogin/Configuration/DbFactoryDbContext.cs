using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using TesteLogin.Infraestruture.data;

namespace TesteLogin.Configuration
{
    public class DbFactoryDbContext : IDesignTimeDbContextFactory<SkyDbContext>
    {
        public SkyDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<SkyDbContext>();
            optionsBuilder.UseSqlServer("Server=localhost;Database=Curso;Trusted_Connection = True");
            SkyDbContext contexto = new SkyDbContext(optionsBuilder.Options);

            return contexto;
        }
    }
}
