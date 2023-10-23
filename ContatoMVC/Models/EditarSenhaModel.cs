using System.ComponentModel.DataAnnotations;

namespace ContatoMVC.Models
{
    public class EditarSenhaModel
    {
        public int Id { get; set; }
        public string SenhaAtual { get; set; }
        public string NovaSenha { get; set; }
        public string ConfirmarNovaSenha { get; set; }
    }
}
