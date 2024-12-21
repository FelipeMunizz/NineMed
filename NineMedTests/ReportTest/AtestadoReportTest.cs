using Domain.InterfacesServices.IAtendimentoService;
using Domain.Servicos;
using Moq;
using WebApi.Controllers;

namespace NineMedTests.ReportTest
{
    public class AtestadoReportTest
    {
        private readonly Mock<InterfaceAtendimentoService> _mockService;
        private readonly AtendimentoController _controller;

        public AtestadoReportTest(Mock<InterfaceAtendimentoService> mockService, AtendimentoService atendimentoService)
        {
            _mockService = mockService;
            _controller = atendimentoService;
        }

        [Fact]
        public async Task Atestado_ShouldReturnCorrectResult()
        {
            // Arrange
            int idAtendimento = 1;
            string expectedReport = "AtestadoReportContent";

            // Act
            var result = await _controller.Atestado(idAtendimento) as OkObjectResult;

            // Assert
            Assert.NotNull(result);
            Assert.Equal(200, result.StatusCode);
            Assert.Equal(expectedReport, result.Value);

            _mockService.Verify(service => service.GetAtestadoReport(idAtendimento), Times.Once);
        }

        [Fact]
        public async Task Atestado_ShouldReturnNotFound_ForInvalidId()
        {
            // Arrange
            int invalidId = 999;
            _mockService
                .Setup(service => service.GetAtestadoReport(It.IsAny<int>()))
                .ReturnsAsync((string)null);

            // Act
            var result = await _controller.Atestado(invalidId);

            // Assert
            Assert.IsType<NotFoundResult>(result);
            _mockService.Verify(service => service.GetAtestadoReport(invalidId), Times.Once);
        }
    }
}
