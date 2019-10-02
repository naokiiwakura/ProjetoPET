using Domain.Interface.Application;
using Domain.Interface.Infra.Respository;
using Xunit;
using Moq;

namespace ServiceTest
{
    public class LojaServiceTest
    {

        private ILojaService _service;
        private Mock<LojaRepository> _lojaRepositorio = new Mock<LojaRepository>();


        public LojaServiceTest()
        {
            _service = new LojaService();
        }

        #region Mock

        #endregion
        [Fact]
        public void Test1()
        {

        }
    }
}
