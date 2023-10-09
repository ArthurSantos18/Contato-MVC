using ContatoMVC.Repository.Interface;
using ContatosMVC.Models;
using Microsoft.AspNetCore.Mvc;

namespace ContatoMVC.Controllers
{
    public class ContatoController : Controller
    {
        private readonly IContatoRepository _contatoRepository;

        public ContatoController(IContatoRepository contatoRepository)
        {
            _contatoRepository = contatoRepository;
        }

        public async Task<IActionResult> Index()
        {
            List<ContatoModel> contatos = await _contatoRepository.BuscarTodos();
            return View(contatos);
        }

        public IActionResult Criar()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Criar(ContatoModel contato)
        {
            await _contatoRepository.AdicionarAsync(contato);
            return RedirectToAction("Index");
        }

        public IActionResult Editar()
        {
            return View();
        }

        public IActionResult DeletarTela()
        {
            return View();
        }

        public IActionResult Deletar()
        {
            return View();
        }


    }
}
