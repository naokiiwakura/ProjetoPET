using Domain.Interface.Application;
using Domain.Interface.Repository;
using Moq;
using Service;
using System;
using Xunit;

namespace ServiceTest
{
    public class UnitTest1
    {
        private readonly ILojaService _lojaService;
        private readonly Mock<ILojaRepository> _lojaRepositoryMock = new Mock<ILojaRepository>();
        #region Mock
        public UnitTest1() {

            _lojaService = new LojaService(_lojaRepositoryMock.Object);
        }
        #endregion
        [Fact]
        public void Test1()
        {

        }
    }
}
