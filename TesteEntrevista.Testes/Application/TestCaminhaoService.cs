using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Moq;
using TesteEntrevista.Application.Services;
using TesteEntrevista.Domain.Interfaces.Repositories;
using Xunit;

namespace TesteEntrevista.Testes.Application
{
    public class TestCaminhaoService
    {
        private readonly Mock<ICaminhaoRepository> _caminhaoRepository;
        
        public TestCaminhaoService()
        {
            _caminhaoRepository = new Mock<ICaminhaoRepository>();
        }

        [Fact]
        public async Task TestApagarCaminhaoAsync()
        {
            //Arrange
            _caminhaoRepository.Setup(x => x.ApagarCaminhaoAsync(It.IsAny<int>()));

            var caminhaoRepository = new CaminhaoService(_caminhaoRepository.Object);

            //Act
            
            var exception = await Record.ExceptionAsync(() => caminhaoRepository.ApagarCaminhaoAsync(1));
            
            //Assert
            Assert.Null(exception);
        }       
    }
}