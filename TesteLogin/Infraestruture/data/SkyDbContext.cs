using Microsoft.EntityFrameworkCore;
using TesteLogin.Infraestruture.data.mapping;
using TesteLogin.Business.Entities;

namespace TesteLogin.Infraestruture.data

{
    public class SkyDbContext : DbContext
    {
        public SkyDbContext(DbContextOptions<SkyDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UsuarioMapping());
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Usuario> Usuario { get; set; }
    }
}
