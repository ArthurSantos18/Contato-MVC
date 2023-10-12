using ContatoMVC.Models;

namespace ContatoMVC.Repository.Interface
{
    public interface IContatoRepository
    {
        Task<ContatoModel> AdicionarAsync(ContatoModel contato);
        Task<List<ContatoModel>> BuscarTodosAsync();
        Task<ContatoModel> BuscarPorIdAsync(int id);
        Task<ContatoModel> EditarAsync(ContatoModel contato);
        Task<bool> DeletarAsync(int id);
    }
}
