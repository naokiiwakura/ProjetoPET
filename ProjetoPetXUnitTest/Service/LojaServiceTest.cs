using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using Moq;
using Domain.Interface.Repository;
using Domain.Interface.Application.Bussiness;
using Service.Bussines;
using Domain.Dto;
using Domain.Model;

namespace ProjetoPetXUnitTest.Service
{
    public class LojaServiceTest
    {

        private readonly Mock<ILojaRepository> _repository = new Mock<ILojaRepository>();
        private ILojaService _service;

        public LojaServiceTest()
        {
            _service = new LojaService(_repository.Object);
        }

        [Fact]
        public void CadastroDeLojaNoFluxoFeliz()
        {
            var loja = new LojaDto();

            _service.Cadastrar(loja);

            _repository.Verify(p => p.Add(It.IsAny<Loja>()), Times.Once);
        }




        [Fact]
        public void CadastroDeLojaComNomeInvalido()
        {
            //arranjo
            var lojaDto = new LojaDto
            {
                NomeLoja = ""
            };

            _service.Cadastrar(lojaDto);            

            _repository.Verify(p => p.Add(It.IsAny<Loja>()), Times.Never);
        }

    }
}
