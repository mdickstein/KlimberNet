using DevelopmentChallenge.Domain.Interfaces;

namespace DevelopmentChallenge.Domain.Entities
{
    public class Cuadrado : IFormaGeometrica
    {
        private readonly decimal _lado;

        public Cuadrado(decimal lado)
        {
            _lado = lado;
        }

        public decimal CalcularArea()
        {
            return _lado * _lado;
        }

        public decimal CalcularPerimetro()
        {
            return _lado * 4;
        }

        public string ObtenerTipoForma()
        {
            return "Cuadrado";
        }
    }
}
