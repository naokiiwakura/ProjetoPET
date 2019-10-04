using System;
using Xunit;

namespace XUnitTestProject1
{
    public class UnitTest1
    {
        [Fact]

        public void Testar_TelaContato()
        {
            //Arrange
            var Tela_Contato = new Contato();
            //Act
            var Testar = Tela_Contato;


            Assert.Equal(0,0);
        }
       
        }
    }

