using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ProjetoPET.Helper;
using ProjetoPET.ViewModel;

namespace ProjetoPET.Controllers
{
    public class ContatoController : Controller
    {
        //private readonly BancoContext _context;
        //private readonly EmailSenderService _emailSender;

        //public ContatoController(EmailSenderService emailSender)
        //{
        //    //_context = context;
        //    _emailSender = emailSender;
        //}

        //public Task<IActionResult> Index()
        //{
        //    return View(await _context.Set<Contato>().ToListAsync());
        //}

        public async Task<string> Enviar(ContatoViewModel contato)
        {
            var conteudo ="<b>Nome:</b>"+ "<p>" + contato.Nome + "</p>" + "<b>Sobrenome:</b>" + "<p>" + contato.Sobrenome + "</p>" + "<b>Email:</b>"  + "<p>" + contato.Email + "</p>" + "<b>Mensagem</b>" + "<p>" +contato.Mensagem+ "</p>";
            var _emailSender = new EmailSenderService();
            await _emailSender.Send("gmaybatsu@Gmail.com", "gmaybatsu@Gmail.com", contato.Assunto, conteudo );
            return "Enviado Com Sucesso";
        }
    }
}