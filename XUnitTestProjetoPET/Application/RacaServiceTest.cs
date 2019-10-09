using Domain.Dto;
using Domain.Interface.Application;
using Domain.Interface.Repository;
using Domain.Model;
using Moq;
using Service;
using System;
using System.Threading.Tasks;
using Xunit;

namespace XUnitTestProjetoPET
{
    public class RacaServiceTest
    {
        private IRacaService _service;
        private Mock<IRacaRepository> _mockRepository = new Mock<IRacaRepository>();


        public RacaServiceTest()
        {
            _service = new RacaService(_mockRepository.Object);
        }

        [Fact]
        public async void TestarCadastroDeRaca()
        {
            //Arranjo
            var racaDto = new DtoRaca { Id=0, Descricao = "raça legal"};

            //Ação
            await _service.Cadastrar(racaDto);

            //Confirmação
            _mockRepository.Verify(r => r.Add(It.IsAny<Raca>()), Times.Once);
        }

      
       
    }
}
