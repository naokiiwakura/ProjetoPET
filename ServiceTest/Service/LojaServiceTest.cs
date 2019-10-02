
using Domain.Interface.Application;
using Domain.Interface.Repository;
using Domain.Model;
using Moq;
using Service;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace ServiceTest
{
    public class LojaServiceTest
    {
        private ILojaService _service;
        private Mock<ILojaRepository> _lojaRepositorioMock = new Mock<ILojaRepository>();

        public LojaServiceTest()
        {
            _service = new LojaService(_lojaRepositorioMock.Object);
        }

        #region Mock
        public List<Loja> RetornaLojas()
        {
            var lista = new List<Loja>();

            lista.Add(new Loja
            {
                Bairro = "São José",
                CEP = 795632621,
                CidadeId = 1,
                CNPj = 888888888888,
                Complemento = "Cidade Linda",
                Email = "SaoJose@gmail.com",
                Id = 1,
                Telefone = 9454654,
                NomeLoja = "SãoJosePet",
                Endereco = "Rua Aba,205",
                Numero = 250,
                RazaoSocial = "Cuidado"
            });
            lista.Add(new Loja
            {
                Bairro = "São Almeida",
                CEP = 795645621,
                CidadeId = 10,
                CNPj = 2222222222222222,
                Complemento = "Cidade Linda",
                Email = "kaka@gmail.com",
                Id = 2,
                Telefone = 94546545,
                NomeLoja = "SãoJosePet",
                Endereco = "Rua Aba,205",
                Numero = 250,
                RazaoSocial = "Guerra"

            });
            lista.Add(new Loja
            {
                Bairro = "Amelio",
                CEP = 4564321,
                CidadeId = 3,
                CNPj = 11111111111111,
                Complemento = "Azul",
                Email = "AdaPet@gmail.com",
                Id = 3,
                Telefone = 94546545,
                NomeLoja = "AdaPet",
                Endereco = "Rua Ada,177",
                Numero = 250,
                RazaoSocial = "Pas"

            });

            return lista;
        }
        #endregion
        [Theory]
        [InlineData(3,11111111111111,true)]
        [InlineData(2, 22222222222222, true)]
        [InlineData(1,888888888888, false)]
        public async Task CNPJValido(int id,long cnpj,bool valido)
        {
            var _loja = RetornaLojas().FirstOrDefault(a => a.Id==id);
            var _cnpj = await _service.CNPJValido(_loja);
            Assert.Equal(valido, _cnpj);
        }
    }
}
