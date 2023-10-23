using ContatoMVC.Models;
using ContatoMVC.Repository.Interface;
using ContatoMVC.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ContatoMVC.Controllers
{
    public class EditarSenhaController : Controller
    {
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly ISessaoService _sessaoService;

        public EditarSenhaController(IUsuarioRepository usuarioRepository, ISessaoService sessaoService)
        {
            _usuarioRepository = usuarioRepository;
            _sessaoService = sessaoService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Editar(EditarSenhaModel editarSenha)
        {
            try
            {
                UsuarioModel usuario = _sessaoService.BuscarSessao();
                editarSenha.Id = usuario.Id;

                if (editarSenha.NovaSenha == editarSenha.ConfirmarNovaSenha)
                {
                    await _usuarioRepository.EditarAsync(editarSenha);
                    TempData["MensagemSucesso"] = "Senha alterada com sucesso";
                    return View("Index", editarSenha);
                }
                else
                {
                    TempData["MensagemErro"] = "Confirme a nova senha corretamente";
                    return View("Index", editarSenha);
                }
            }

            catch (Exception e)
            {
                TempData["MensagemErro"] = $"Não foi possível alterar a senha {e.Message}";
                return View("Index", editarSenha);
            }
        }
    }
}
