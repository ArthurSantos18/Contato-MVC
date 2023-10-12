using ContatoMVC.Models;
using ContatoMVC.Repository.Interface;
using Microsoft.AspNetCore.Mvc;

namespace ContatoMVC.Controllers
{
    public class LoginController : Controller
    {
        private readonly IUsuarioRepository _usuarioRepository;

        public LoginController(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Entrar(LoginModel loginModel)
        {
            try
            {
                UsuarioModel usuario = await _usuarioRepository.BuscarPorLogin(loginModel.Login);

                if (usuario != null)
                {
                    if (usuario.ValidacaoSenha(loginModel.Senha))
                    {
                        return RedirectToAction("Index", "Home");
                    }
                    TempData["MensagemErro"] = $"Senha inválida";
                }

                TempData["MensagemErro"] = $"Usuário inválido";
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                TempData["MensagemErro"] = $"Não conseguimos realizar o login: \n{e.Message}";
                return RedirectToAction("Index");
            }
        }
    }
}
