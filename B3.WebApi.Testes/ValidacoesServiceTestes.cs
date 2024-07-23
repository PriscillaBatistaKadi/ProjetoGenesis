using B3.WebApi.Domain.Services;
using B3.WebApi.Domain.Services.Interfaces;
using Moq;

namespace B3.WebApi.Testes
{
    public class ValidacoesServiceTestes
    {

        private readonly Mock<IValidacoes> _mockValidacoes;
        private readonly ValidacoesService _validacoesService;

        public ValidacoesServiceTestes()
        {
            _mockValidacoes = new Mock<IValidacoes>();
            _validacoesService = new ValidacoesService();
        }

        [Theory]
        [InlineData(0, 5, "O Valor inicial deve ser positivo")]
        [InlineData(-100, 5, "O Valor inicial deve ser positivo")]
        [InlineData(100, 0, "A quantidade de meses deve ser maior que 1")]
        [InlineData(200, -10, "A quantidade de meses deve ser maior que 1")]

        public void ArgumentExceptionQuandoValorInicialMenorOuIgualAZero(double valorInicial, int meses, string mensagemEsperada)
        {
            // Arrange
            _mockValidacoes.Setup(v => v.Validar(valorInicial, meses)).Throws(new ArgumentException(mensagemEsperada));

            // Act + Assert
            var ex = Assert.Throws<ArgumentException>(() => _validacoesService.Validar(valorInicial, meses));
            Assert.Equal(mensagemEsperada, ex.Message);
        }

      [Theory]
 [InlineData(100, 2)] // Exemplo de dados válidos
 [InlineData(500, 10)] // Outro exemplo de dados válidos
 public void SemExceptionQuandoValoresValidos(double valorInicial, int meses)
 {
     // Arrange & Act
     try
     {
         _validacoesService.Validar(valorInicial, meses);

         // Assert (se não lançou exceção, o teste passa automaticamente)
     }
     catch (ArgumentException ex)
     {
         // Se lançou ArgumentException inesperado, falha o teste
         Assert.Fail($"Exceção inesperada: {ex.Message}");
     }
     catch (Exception ex)
     {
         Assert.Fail($"Exceção inesperada: {ex.Message}");
     }

   }
}
