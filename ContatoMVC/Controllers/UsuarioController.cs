using ContatoMVC.Filters;
using ContatoMVC.Models;
using ContatoMVC.Repository;
using ContatoMVC.Repository.Interface;
using Microsoft.AspNetCore.Mvc;

namespace ContatoMVC.Controllers
{
    [PaginaUsuarioAdm]
    public class UsuarioController : Controller
    {
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly IContatoRepository _contatoRepository;
        public UsuarioController(IUsuarioRepository usuarioRepository, IContatoRepository contatoRepository)
        {
            _usuarioRepository = usuarioRepository;
            _contatoRepository = contatoRepository;
        }

        public async Task<IActionResult> Index()
        {
            List<UsuarioModel> usuarios = await _usuarioRepository.BuscarTodosAsync();

            return View(usuarios);
        }

        public IActionResult Criar()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Criar(UsuarioModel usuario)
        {
            try
            {
                await _usuarioRepository.AdicionarAsync(usuario);

                TempData["MensagemSucesso"] = "Usuario cadastrado com sucesso";
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                TempData["MensagemErro"] = $"Erro ao cadastrar:\n{e.Message}";
                return RedirectToAction("Index");
            }
        }

        public async Task<IActionResult> Editar(int id)
        {
            UsuarioModel usuario = await _usuarioRepository.BuscarAsync(id);

            return View(usuario);
        }

        [HttpPost]
        public async Task<IActionResult> Editar(UsuarioModel usuario)
        {
            try
            {
                await _usuarioRepository.EditarAsync(usuario);

                TempData["MensagemSucesso"] = "Usuário alterado com sucesso";
                return RedirectToAction("Index");

            }
            catch (Exception e)
            {
                TempData["MensagemErro"] = $"Erro ao alterar:\n{e.Message}";
                return RedirectToAction("Index");
            }
        }

        public async Task<IActionResult> DeletarTela(int id)
        {
            UsuarioModel usuario = await _usuarioRepository.BuscarAsync(id);
            return View(usuario);
        }

        public async Task<IActionResult> Deletar(int id)
        {
            try
            {
                await _usuarioRepository.DeletarAsync(id);
                TempData["MensagemSucesso"] = "Usuário deletado com sucesso";
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                TempData["MensagemErro"] = $"Erro ao deletar:\n{e.Message}";
                return RedirectToAction("Index");
            }
        }
        public async Task<IActionResult> ListarContatos(int id)
        {
            List<ContatoModel> contatos = await _contatoRepository.BuscarTodosAsync(id);

            return PartialView("_ContatosUsuario", contatos);
        }
    }
}
