using ContatoMVC.Repository.Interface;
using ContatoMVC.Models;
using Microsoft.AspNetCore.Mvc;
using ContatoMVC.Filters;
using ContatoMVC.Services.Interfaces;

namespace ContatoMVC.Controllers
{
    [PaginaUsuarioLogado]
    public class ContatoController : Controller
    {
        private readonly IContatoRepository _contatoRepository;
        private readonly ISessaoService _sessaoService;
        public ContatoController(IContatoRepository contatoRepository, ISessaoService sessaoService)
        {
            _contatoRepository = contatoRepository;
            _sessaoService = sessaoService;
        }

        public async Task<IActionResult> Index()
        {
            UsuarioModel usuario = _sessaoService.BuscarSessao();
            List<ContatoModel> contatos = await _contatoRepository.BuscarTodosAsync(usuario.Id);

            return View(contatos);
        }

        public IActionResult Criar()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Criar(ContatoModel contato)
        {
            try
            {
                UsuarioModel usuario = _sessaoService.BuscarSessao();
                contato.UsuarioId = usuario.Id;

                await _contatoRepository.AdicionarAsync(contato);

                TempData["MensagemSucesso"] = "Contato cadastrado com sucesso";
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
            ContatoModel contato = await _contatoRepository.BuscarPorIdAsync(id);
            return View(contato);
        }

        [HttpPost]
        public async Task<IActionResult> Editar(ContatoModel contato)
        {
            try
            {
                UsuarioModel usuario = _sessaoService.BuscarSessao();
                contato.UsuarioId = usuario.Id;

                await _contatoRepository.EditarAsync(contato);

                TempData["MensagemSucesso"] = "Contato alterado com sucesso";
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
            ContatoModel contato = await _contatoRepository.BuscarPorIdAsync(id);
            return View(contato);
        }

        public async Task<IActionResult> Deletar(int id)
        {
            try
            {
                await _contatoRepository.DeletarAsync(id);
                TempData["MensagemSucesso"] = "Contato deletado com sucesso";
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                TempData["MensagemErro"] = $"Erro ao deletar:\n{e.Message}";
                return RedirectToAction("Index");
            }
        }
    }
}
