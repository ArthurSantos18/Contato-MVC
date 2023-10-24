using ContatoMVC.Models;

namespace ContatoMVC.Repository.Interface
{
    public interface IUsuarioRepository
    {
        Task<UsuarioModel> BuscarAsync(string login);
        Task<UsuarioModel> BuscarAsync(string login, string email);
        Task<UsuarioModel> BuscarAsync(int id);
        Task<List<UsuarioModel>> BuscarTodosAsync();
        Task<UsuarioModel> AdicionarAsync(UsuarioModel usuario);
        Task<UsuarioModel> EditarAsync(UsuarioModel usuario);
        Task<UsuarioModel> EditarAsync(EditarSenhaModel editarSenha);
        Task<bool> DeletarAsync(int id);
    }
}
