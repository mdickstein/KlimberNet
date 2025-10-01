using DevelopmentChallenge.Domain.Interfaces;

namespace DevelopmentChallenge.Domain.Entities
{
    public class Trapecio : IFormaGeometrica
    {
        private readonly decimal _baseMayor;
        private readonly decimal _baseMenor;
        private readonly decimal _altura;
        private readonly decimal _ladoOblicuo;

        public Trapecio(decimal baseMayor, decimal baseMenor, decimal altura, decimal ladoOblicuo)
        {
            _baseMayor = baseMayor;
            _baseMenor = baseMenor;
            _altura = altura;
            _ladoOblicuo = ladoOblicuo;
        }

        public decimal CalcularArea()
        {
            return ((_baseMayor + _baseMenor) * _altura) / 2;
        }

        public decimal CalcularPerimetro()
        {
            return _baseMayor + _baseMenor + (2 * _ladoOblicuo);
        }

        public string ObtenerTipoForma()
        {
            return "Trapecio";
        }
    }
}
