using ContatoMVC.Models;
using ContatoMVC.Services;
using Microsoft.EntityFrameworkCore;

namespace ContatoMVC.Data
{
    public static class SeedingContext
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            ContatoModel c1 = new ContatoModel
            {
                Id = 1,
                Nome = "Rudolf",
                Email = "rudolf@gmail.com",
                Telefone = "00 0000-0000",
                UsuarioId = 2
            };

            ContatoModel c2 = new ContatoModel
            {
                Id = 2,
                Nome = "Kyrie",
                Email = "kyrie@gmail.com",
                Telefone = "00 0000-0110",
                UsuarioId = 2
            };

            ContatoModel c3 = new ContatoModel
            {
                Id = 3,
                Nome = "Maria",
                Email = "maria@gmail.com",
                Telefone = "00 1010-1110",
                UsuarioId = 3
            };

            UsuarioModel u1 = new UsuarioModel
            {
                Id = 1,
                Nome = "Administrador",
                Login = "adm",
                Email = "nieeg18@gmail.com",
                Perfil = Models.Enums.PerfilEnum.Admin,
                Senha = "123".GerarHash(),
                DataCadastro = DateTime.Now
            };

            UsuarioModel u2 = new UsuarioModel
            {
                Id = 2,
                Nome = "Battler",
                Login = "BATTLER",
                Email = "battler@gmail.com",
                Perfil = Models.Enums.PerfilEnum.Padrao,
                Senha = "123".GerarHash(),
                DataCadastro = DateTime.Now
            };

            UsuarioModel u3 = new UsuarioModel
            {
                Id = 3,
                Nome = "Beatrice",
                Login = "BEATRICE",
                Email = "beatrice@gmail.com",
                Perfil = Models.Enums.PerfilEnum.Padrao,
                Senha = "123".GerarHash(),
                DataCadastro = DateTime.Now
            };

            modelBuilder.Entity<UsuarioModel>().HasData(u1, u2, u3);
            modelBuilder.Entity<ContatoModel>().HasData(c1, c2, c3);
        }
    }
}
