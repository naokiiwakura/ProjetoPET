using Domain.Dto;
using Domain.Interface.Application;
using Domain.Interface.Repository;
using Domain.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class RacaService : IRacaService
    {
        private IRacaRepository _racaRepository;

        public RacaService(IRacaRepository racaRepository)
        {
            _racaRepository = racaRepository;
        }

        public async Task Cadastrar(DtoRaca raca)
        {
            await _racaRepository.Add((Raca)raca);
        }

        public Task Editar(Raca raca)
        {
            throw new NotImplementedException();
        }

        public Task Excluir(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Raca>> Listar()
        {
            throw new NotImplementedException();
        }
    }
}
