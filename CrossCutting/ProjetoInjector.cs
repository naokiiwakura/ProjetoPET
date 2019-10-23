using Domain.Interface.Repository;
using Microsoft.Extensions.DependencyInjection;
using Repository;

namespace CrossCutting
{
    public class ProjetoInjector
    {
        public static void RegistrarServicos(IServiceCollection services)
        {
            services.AddScoped<ILojaRepository, LojaRepository>();
            services.AddScoped<IAnuncioRepository, AnuncioRepository>();
            services.AddScoped<IEventoRepository, EventoRepository>();
            services.AddScoped<IContatoRepository, ContatoRepository>();
            services.AddScoped<IUsuarioRepository, UsuarioRepository>();
            services.AddScoped<IPetRepository, PetRepository>();
        }
    }
}