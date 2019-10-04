using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ProjetoPET.Models;
using ProjetoPET.ViewModel;

namespace ProjetoPET.Controllers
{
    public class ContatoController : Controller
    {
        private readonly IEmailSender _emailSender;

        public ContatoController(IEmailSender emailSender) =>
            _emailSender = emailSender;

        public async Task<string> Enviar(ContatoViewModel contato)
        {
            var help = new ResumirMensagem();
            var conteudo = help.Resumir(contato.Nome, contato.Sobrenome, contato.Mensagem, contato.Email);
            await _emailSender.EnviarEmail("anapaulaa.apds9292@gmail.com", "anapaulaa.apds9292@gmail.com", contato.Assunto, conteudo);
            return "Enviado Com Sucesso";
        }
    }
}