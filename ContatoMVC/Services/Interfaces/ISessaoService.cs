using ContatoMVC.Models;

namespace ContatoMVC.Services.Interfaces
{
    public interface ISessaoService
    {
        void CriarSessao(UsuarioModel usuario);
        void RemoverSessao();
        UsuarioModel BuscarSessao();
    }
}
