using ContatoMVC.Filters;
using Microsoft.AspNetCore.Mvc;

namespace ContatoMVC.Controllers
{
    [PaginaUsuarioLogado]
    public class RestritoController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
