using ContatoMVC.Models;

namespace ContatoMVC.Repository.Interface
{
    public interface IUsuarioRepository
    {
        Task<UsuarioModel> BuscarPorLogin(string login);
        Task<UsuarioModel> AdicionarAsync(UsuarioModel usuario);
        Task<List<UsuarioModel>> BuscarTodosAsync();
        Task<UsuarioModel> BuscarPorIdAsync(int id);
        Task<UsuarioModel> EditarAsync(UsuarioModel usuario);
        Task<bool> DeletarAsync(int id);
    }
}
