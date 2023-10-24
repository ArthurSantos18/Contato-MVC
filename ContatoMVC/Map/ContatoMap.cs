using ContatoMVC.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace ContatoMVC.Map
{
    public class ContatoMap : IEntityTypeConfiguration<ContatoModel>
    {
        public void Configure(EntityTypeBuilder<ContatoModel> builder)
        {
            builder.ToTable("contatos");

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).HasColumnName("id");
            builder.Property(x => x.Nome).HasColumnName("nome").HasColumnType("varchar(100)");
            builder.Property(x => x.Email).HasColumnName("email").HasColumnType("varchar(100)");
            builder.Property(x => x.Telefone).HasColumnName("telefone").HasColumnType("varchar(60)");

            builder.Property(x => x.UsuarioId).HasColumnName("usuario_id");
            builder.HasOne(x => x.Usuario).WithMany(x => x.Contatos).HasForeignKey(x => x.UsuarioId);
        }
    }
}