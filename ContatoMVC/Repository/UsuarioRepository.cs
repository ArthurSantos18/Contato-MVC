using ContatoMVC.Data;
using ContatoMVC.Models;
using ContatoMVC.Repository.Interface;
using Microsoft.EntityFrameworkCore;

namespace ContatoMVC.Repository
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly ContatoContext _context;

        public UsuarioRepository(ContatoContext context)
        {
            _context = context;
        }

        public async Task<UsuarioModel> AdicionarAsync(UsuarioModel usuario)
        {
            usuario.DataCadastro = DateTime.Now;
            await _context.Usuarios.AddAsync(usuario);
            await _context.SaveChangesAsync();

            return usuario;
        }

        public async Task<UsuarioModel> EditarAsync(UsuarioModel usuario)
        {
            UsuarioModel usuarioDatabase = await BuscarPorIdAsync(usuario.Id);
            
            if (usuarioDatabase == null)
            {
                throw new Exception("Houve um erro na atualização");
            }

            usuarioDatabase.Nome = usuario.Nome;
            usuarioDatabase.Email = usuario.Email;
            usuarioDatabase.Login = usuario.Login;
            usuarioDatabase.Perfil = usuario.Perfil;
            usuarioDatabase.DataAtualizacao = DateTime.Now;

            await _context.SaveChangesAsync();

            return usuarioDatabase;         
        }

        public async Task<UsuarioModel> BuscarPorIdAsync(int id)
        {
            return await _context.Usuarios.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<UsuarioModel>> BuscarTodosAsync()
        {
            return await _context.Usuarios.ToListAsync();
        }

        public async Task<bool> DeletarAsync(int id)
        {
            UsuarioModel usuarioDatabase = await BuscarPorIdAsync(id);

            if (usuarioDatabase == null)
            {
                throw new Exception("Houve um erro no momento de deletar");
            }

            _context.Usuarios.Remove(usuarioDatabase);
            await _context.SaveChangesAsync();

            return true;
        }

        public Task<UsuarioModel> BuscarPorLogin(string login)
        {
            return _context.Usuarios.FirstOrDefaultAsync(x => x.Login == login);
        }
    }
}
