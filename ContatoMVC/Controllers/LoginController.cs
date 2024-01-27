using ContatoMVC.Models;
using ContatoMVC.Repository.Interface;
using ContatoMVC.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ContatoMVC.Controllers
{
    public class LoginController : Controller
    {
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly ISessaoService _sessaoService;
        private readonly IEmailService _emailService;

        public LoginController(IUsuarioRepository usuarioRepository, ISessaoService sessaoService, IEmailService emailService)
        {
            _usuarioRepository = usuarioRepository;
            _sessaoService = sessaoService;
            _emailService = emailService;
        }

        public IActionResult Index()
        {
            if (_sessaoService.BuscarSessao() != null)
            {
                return RedirectToAction("Index", "Home");
            }

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Entrar(LoginModel loginModel)
        {
            try
            {
                UsuarioModel usuario = await _usuarioRepository.BuscarAsync(loginModel.Login);

                if (usuario != null)
                {
                    if (usuario.ValidacaoSenha(loginModel.Senha))
                    {
                        _sessaoService.CriarSessao(usuario);

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

        public IActionResult Sair()
        {
            _sessaoService.RemoverSessao();

            return RedirectToAction("Index", "Login");
        }

        public IActionResult RedefinirSenha()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> LinkRedefinirSenhaAsync(RedefinirSenhaModel redefinirSenhaModel)
        {
            try
            {
                UsuarioModel usuario = await _usuarioRepository.BuscarAsync(redefinirSenhaModel.Login, redefinirSenhaModel.Email);

                if (usuario != null)
                {
                    string novaSenha = usuario.GerarSenhaAleatoria();
                    string assunto = "Contato MVC - Nova Senha";
                    string mensagem = $"Sua nova senha é: {novaSenha}";
                    bool mail = await _emailService.EnviarAsync(usuario.Email, assunto, mensagem);
                    
                    if (mail)
                    {
                        await _usuarioRepository.EditarAsync(usuario);
                        TempData["MensagemSucesso"] = $"Enviamos para o seu e-mail cadastrado.";
                    }
                    else
                    {
                        TempData["MensagemErro"] = $"Não conseguimos enviar para o seu e-mail cadastrado.";
                    }
                    
                    return RedirectToAction("Index");
                }

                TempData["MensagemErro"] = $"Não conseguimos redefinir sua senha. Verifique os dados informados.";
                return RedirectToAction("RedefinirSenha");
            }
            catch (Exception e)
            {
                TempData["MensagemErro"] = $"Não conseguimos redefinir sua senha: \n{e.Message}";
                return RedirectToAction("RedefinirSenha");
            }
        }
    }
}
