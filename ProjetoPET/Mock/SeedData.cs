using Data;
using Domain.Model;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoPET.Mock
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            var context = serviceProvider.GetRequiredService<BancoContext>();
            context.Database.EnsureCreated();


            //Realiza a carga de cidades e estados
            if (!context.Estado.Any())
            {
                // deserialize JSON directly from a file
                //using (StreamReader file = File.OpenText(@"Mock\Jsons\cidadeEstado.json"))
                using (StreamReader file = new StreamReader(@"Mock\Jsons\cidadeEstado.json", Encoding.GetEncoding("iso-8859-1")))
                {
                    JsonSerializer serializer = new JsonSerializer();
                    CargaCidadeEstado ListaDeEstados = (CargaCidadeEstado)serializer.Deserialize(file, typeof(CargaCidadeEstado));

                    foreach (var estado in ListaDeEstados.Estados)
                    {
                        var estadoInsert = new Estado
                        {
                            Nome = estado.Nome,
                            Sigla = estado.Sigla,
                            Cidades = new List<Cidade>(),
                            CreatedDate = DateTime.Now
                        };

                        foreach (var nomeCidade in estado.Cidades)
                        {
                            var cidadeInsert = new Cidade
                            {
                                Nome = nomeCidade,
                                CreatedDate = DateTime.Now
                            };

                            estadoInsert.Cidades.Add(cidadeInsert);
                        }

                        context.Estado.Add(estadoInsert);
                    }
                }                
            }

            //Realiza a carga de tipos de anúncio
            if(!context.TipoAnuncio.Any())
            {
                context.TipoAnuncio.Add(new TipoAnuncio { Descricao = "Adoção", CreatedDate = DateTime.Now});
                context.TipoAnuncio.Add(new TipoAnuncio { Descricao = "Venda", CreatedDate = DateTime.Now });
            }

            context.SaveChanges();
        }
    }

    public class EstadoCarga
    {
        public string Sigla { get; set; }
        public string Nome { get; set; }
        public List<string> Cidades { get; set; }
    }

    public class CargaCidadeEstado
    {
        public List<EstadoCarga> Estados { get; set; }
    }
}
