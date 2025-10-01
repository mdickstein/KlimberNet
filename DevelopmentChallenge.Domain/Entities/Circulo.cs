using System;
using DevelopmentChallenge.Domain.Interfaces;

namespace DevelopmentChallenge.Domain.Entities
{
    public class Circulo : IFormaGeometrica
    {
        private readonly decimal _diametro;

        public Circulo(decimal diametro)
        {
            _diametro = diametro;
        }

        public decimal CalcularArea()
        {
            return (decimal)Math.PI * (_diametro / 2) * (_diametro / 2);
        }

        public decimal CalcularPerimetro()
        {
            return (decimal)Math.PI * _diametro;
        }

        public string ObtenerTipoForma()
        {
            return "Circulo";
        }
    }
}
