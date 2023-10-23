using ContatoMVC.Models;
using ContatoMVC.Services.Interfaces;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace ContatoMVC.Services
{
    public class SessaoService : ISessaoService
    {
        private readonly IHttpContextAccessor _contextAccessor;

        public SessaoService(IHttpContextAccessor contextAccessor)
        {
            _contextAccessor = contextAccessor;
        }

        public UsuarioModel BuscarSessao()
        {
            string sessao = _contextAccessor.HttpContext.Session.GetString("sessaoUsuario");

            if (string.IsNullOrEmpty(sessao))
            {
                return null;
            }

            return JsonSerializer.Deserialize<UsuarioModel>(sessao);

        }

        public void CriarSessao(UsuarioModel usuario)
        {
            string sessao = JsonSerializer.Serialize(usuario);
            _contextAccessor.HttpContext.Session.SetString("sessaoUsuario", sessao);
        }

        public void RemoverSessao()
        {
            _contextAccessor.HttpContext.Session.Remove("sessaoUsuario");
        }
    }
}
