using ContatoMVC.Models.Enums;
using ContatoMVC.Services;

namespace ContatoMVC.Models
{
    public class UsuarioModel
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Login { get; set;}
        public string Email { get; set; }
        public PerfilEnum Perfil { get; set; }
        public string Senha { get; set; }
        public DateTime DataCadastro { get; set; }
        public DateTime? DataAtualizacao { get; set; }
        public List<ContatoModel> Contatos { get; set; } = new List<ContatoModel>();

        public bool ValidacaoSenha(string senha)
        {
            return Senha == senha.GerarHash();
        }

        public void NovaSenha(string novaSenha)
        {
            Senha = novaSenha.GerarHash();
        }

        public void SenhaHash()
        {
            Senha = Senha.GerarHash();
        }

        public string GerarSenhaAleatoria()
        {
            string novaSenha = Guid.NewGuid().ToString().Substring(0, 8);
            Senha = novaSenha.GerarHash();
            
            return novaSenha;
        }
    }
}
