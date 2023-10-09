using ContatoMVC.Repository.Interface;
using ContatosMVC.Data;
using ContatosMVC.Models;
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
            await _context.AddAsync(contato);
            await _context.SaveChangesAsync();

            return contato;
        }

        public async Task<List<ContatoModel>> BuscarTodos()
        {
            return await _context.Contato.ToListAsync();
        }
    }
}
