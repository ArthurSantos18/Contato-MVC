using ContatoMVC.Models;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace ContatoMVC.ViewComponents
{
    public class Menu : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            string sessao = HttpContext.Session.GetString("sessaoUsuario");

            if (string.IsNullOrEmpty(sessao))
            {
                return null;
            }

            UsuarioModel usuario = JsonSerializer.Deserialize<UsuarioModel>(sessao);

            return View(usuario);
        }
    }
}
