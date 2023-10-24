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
            usuario.SenhaHash();
            await _context.Usuarios.AddAsync(usuario);
            await _context.SaveChangesAsync();

            return usuario;
        }

        public async Task<UsuarioModel> EditarAsync(UsuarioModel usuario)
        {
            UsuarioModel usuarioDatabase = await BuscarAsync(usuario.Id);
            
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

        public async Task<UsuarioModel> EditarAsync(EditarSenhaModel editarSenha)
        {
            UsuarioModel usuario = await BuscarAsync(editarSenha.Id);

            if (usuario == null)
            {
                throw new Exception("Houve um erro na atualização da senha, usuário não encontrado");
            }

            if (!usuario.ValidacaoSenha(editarSenha.SenhaAtual))
            {
                throw new Exception("Senha atual não confere");
            }

            if (usuario.ValidacaoSenha(editarSenha.NovaSenha))
            {
                throw new Exception("A nova senha é igual a senha atual");
            }

            usuario.NovaSenha(editarSenha.NovaSenha);
            usuario.DataAtualizacao = DateTime.Now;

            _context.Usuarios.Update(usuario);
            await _context.SaveChangesAsync();
            
            return usuario;
        }

        public async Task<bool> DeletarAsync(int id)
        {
            UsuarioModel usuarioDatabase = await BuscarAsync(id);

            if (usuarioDatabase == null)
            {
                throw new Exception("Houve um erro no momento de deletar");
            }

            _context.Usuarios.Remove(usuarioDatabase);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<UsuarioModel> BuscarAsync(int id)
        {
            return await _context.Usuarios.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<UsuarioModel> BuscarAsync(string login)
        {
            return await _context.Usuarios.FirstOrDefaultAsync(x => x.Login == login);
        }

        public async Task<UsuarioModel> BuscarAsync(string login, string email)
        {
            return await _context.Usuarios.FirstOrDefaultAsync(x => x.Login == login && x.Email == email);
        }

        public async Task<List<UsuarioModel>> BuscarTodosAsync()
        {
            return await _context.Usuarios.Include(x => x.Contatos).ToListAsync();
        }
    }
}
