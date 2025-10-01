using System;
using DevelopmentChallenge.Domain.Interfaces;

namespace DevelopmentChallenge.Domain.Entities
{
    public class TrianguloEquilatero : IFormaGeometrica
    {
        private readonly decimal _lado;

        public TrianguloEquilatero(decimal lado)
        {
            _lado = lado;
        }

        public decimal CalcularArea()
        {
            return ((decimal)Math.Sqrt(3) / 4) * _lado * _lado;
        }

        public decimal CalcularPerimetro()
        {
            return _lado * 3;
        }

        public string ObtenerTipoForma()
        {
            return "Triangulo";
        }
    }
}
