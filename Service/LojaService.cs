using Domain.DTO;
using Domain.Interface.Application;
using Domain.Interface.Repository;
using Domain.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class LojaService : ILojaService
    {
        private readonly ILojaRepository _lojaRepository;
        public LojaService(ILojaRepository repository)
        {
            _lojaRepository = repository;
        }


        public Task<bool> CadastrarLoja(DTOLoja loja)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> CNPJValido(Loja loja)
        {
            return loja.CNPj.ToString().Length == 14;
        }
    }
}
