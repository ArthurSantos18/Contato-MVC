using ContatosMVC.Models;
using Microsoft.EntityFrameworkCore;

namespace ContatosMVC.Data
{
    public class ContatoContext : DbContext
    {
        public DbSet<ContatoModel> Contato {  get; set; }

        public ContatoContext(DbContextOptions option) : base(option)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
        }
    }
}
