using ContatosMVC.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace ContatosMVC.Map
{
    public class ContatoMap : IEntityTypeConfiguration<ContatoModel>
    {
        public void Configure(EntityTypeBuilder<ContatoModel> builder)
        {
            builder.ToTable("contatos");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).HasColumnName("id").IsRequired();
            builder.Property(x => x.Nome).HasColumnName("nome").HasColumnType("varchar(100)");
            builder.Property(x => x.Email).HasColumnName("email").HasColumnType("varchar(100)");
            builder.Property(x => x.Telefone).HasColumnName("telefone").HasColumnType("varchar(60)");
        }
    }
}