using Domain.Dto;
using Domain.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interface.Application
{
    public interface IRacaService
    {
        Task<List<Raca>> Listar();
        Task Cadastrar(DtoRaca raca);
        Task Excluir(int id);
        Task Editar(Raca raca);
    }
}
