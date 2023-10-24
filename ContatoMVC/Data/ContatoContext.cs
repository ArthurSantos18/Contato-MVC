using ContatoMVC.Models;
using Microsoft.EntityFrameworkCore;

namespace ContatoMVC.Data
{
    public class ContatoContext : DbContext
    {
        public DbSet<ContatoModel> Contatos {  get; set; }
        public DbSet<UsuarioModel> Usuarios { get; set; }

        public ContatoContext(DbContextOptions option) : base(option)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);

            modelBuilder.Seed();
        }
    }
}
