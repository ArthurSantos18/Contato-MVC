using ContatoMVC.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ContatoMVC.Map
{
    public class UsuarioMap : IEntityTypeConfiguration<UsuarioModel>
    {
        public void Configure(EntityTypeBuilder<UsuarioModel> builder)
        {
            builder.ToTable("usuarios");

            builder.HasKey(x => x.Id);
            
            builder.Property(x => x.Id).HasColumnName("id");
            builder.Property(x => x.Nome).HasColumnName("nome").HasColumnType("varchar(100)");
            builder.Property(x => x.Login).HasColumnName("login").HasColumnType("varchar(30)");
            builder.Property(x => x.Email).HasColumnName("email").HasColumnType("varchar(100)");
            builder.Property(x => x.Perfil).HasColumnName("perfil");
            builder.Property(x => x.Senha).HasColumnName("senha").HasColumnType("varchar(16)");
            builder.Property(x => x.DataCadastro).HasColumnName("data_cadastro");
            builder.Property(x => x.DataAtualizacao).HasColumnName("data_atualizacao");
            
        }
    }
}
