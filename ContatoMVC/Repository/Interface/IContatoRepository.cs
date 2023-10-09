using ContatosMVC.Models;

namespace ContatoMVC.Repository.Interface
{
    public interface IContatoRepository
    {
        Task<ContatoModel> AdicionarAsync(ContatoModel contato);
        Task<List<ContatoModel>> BuscarTodos();
    }
}
