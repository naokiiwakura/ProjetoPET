using Domain.Dto;
using Domain.Interface.Application.Bussiness;
using Domain.Interface.Repository;
using Domain.Model;
using Repository;

namespace Service.Bussines
{
    public class LojaService : ILojaService
    {
        private readonly ILojaRepository _lojaRepository;
        public LojaService(ILojaRepository lojaRepository)
        {
            _lojaRepository = lojaRepository;
        }

        public void Cadastrar(LojaDto lojaDto)
        {
            var loja = new Loja {
                NomeLoja = lojaDto.NomeLoja,
                RazaoSocial = lojaDto.RazaoSocial,
            };

            if(!string.IsNullOrEmpty(lojaDto.NomeLoja))
                _lojaRepository.Add(loja);
        }
    }
}