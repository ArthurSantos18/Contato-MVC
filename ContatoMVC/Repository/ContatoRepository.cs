using ContatoMVC.Repository.Interface;
using ContatoMVC.Data;
using ContatoMVC.Models;
using Microsoft.EntityFrameworkCore;

namespace ContatoMVC.Repository
{
    public class ContatoRepository : IContatoRepository
    {
        private readonly ContatoContext _context;

        public ContatoRepository(ContatoContext context)
        {
            _context = context;
        }

        public async Task<ContatoModel> AdicionarAsync(ContatoModel contato)
        {
            await _context.Contatos.AddAsync(contato);
            await _context.SaveChangesAsync();

            return contato;
        }

        public async Task<List<ContatoModel>> BuscarTodosAsync(int id)
        {
            return await _context.Contatos.Where(x => x.UsuarioId == id).ToListAsync();
        }

        public async Task<ContatoModel> BuscarPorIdAsync(int id)
        {
            return await _context.Contatos.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<ContatoModel> EditarAsync(ContatoModel contato)
        {
            ContatoModel contatoDatabase = await BuscarPorIdAsync(contato.Id);
            
            if (contatoDatabase == null)
            {
                throw new Exception("Houve um erro na atualização");
            }

            contatoDatabase.Nome = contato.Nome;
            contatoDatabase.Email = contato.Email;
            contatoDatabase.Telefone = contato.Telefone;

            await _context.SaveChangesAsync();

            return contatoDatabase;
        }

        public async Task<bool> DeletarAsync(int id)
        {
            ContatoModel contatoDatabase = await BuscarPorIdAsync(id);

            if (contatoDatabase == null)
            {
                throw new Exception("Houve um erro no momento de deletar");
            }

            _context.Contatos.Remove(contatoDatabase);
            await _context.SaveChangesAsync();

            return true;
        }
    }
}
