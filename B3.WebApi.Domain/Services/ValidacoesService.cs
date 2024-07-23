using B3.WebApi.Domain.Services.Interfaces;

namespace B3.WebApi.Domain.Services
{
    public class ValidacoesService: IValidacoes
    {
        public void Validar(double valorInicial, int meses)
        {
            if (valorInicial <= 0)
            {
                throw new ArgumentException("O Valor inicial deve ser positivo");
            }

            if (meses <= 1)
            {
                throw new ArgumentException("A quantidade de meses deve ser maior que 1");

            }
        }
    }
}
