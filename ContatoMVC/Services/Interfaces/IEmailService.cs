namespace ContatoMVC.Services.Interfaces
{
    public interface IEmailService
    {
        Task<bool> EnviarAsync(string email, string assunto, string mensagem);
    }
}
