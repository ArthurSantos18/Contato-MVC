using ContatoMVC.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Text.Json;

namespace ContatoMVC.Filters
{
    public class PaginaUsuarioAdm : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            string sessao = context.HttpContext.Session.GetString("sessaoUsuario");

            if (string.IsNullOrEmpty(sessao))
            {
                context.Result = new RedirectToRouteResult(
                    new RouteValueDictionary {
                        {"controller", "Login" },
                        {"action", "Index" }
                    });
            }
            else
            {
                UsuarioModel usuario = JsonSerializer.Deserialize<UsuarioModel>(sessao);

                if (usuario == null)
                {
                    context.Result = new RedirectToRouteResult(
                        new RouteValueDictionary {
                            {"controller", "Login" },
                            {"action", "Index" }
                        });
                }

                if (usuario.Perfil != Models.Enums.PerfilEnum.Admin)
                {

                    context.Result = new RedirectToRouteResult(
                        new RouteValueDictionary {
                            {"controller", "Restrito" },
                            {"action", "Index" }
                        });

                }

            }

            base.OnActionExecuting(context);
        }
    }
}
