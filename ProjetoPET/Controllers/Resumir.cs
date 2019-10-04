namespace ProjetoPET.Controllers
{
    public class ResumirMensagem
    {
        public string Resumir(string Nome, string Sobrenome, string Mensagem, string Email) =>
        "<b>Nome:</b>" + "<p>" + Nome  + "</p>" + "<b>Sobrenome:</b>" + "<p>" + Sobrenome + "</p>" + "<b>Email:</b>"  + "<p>" + Email + "</p>" + "<b>Mensagem</b>" + "<p>" +Mensagem+ "</p>";
          
    }
}
