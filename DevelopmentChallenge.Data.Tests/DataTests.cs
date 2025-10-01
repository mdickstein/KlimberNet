using System;
using System.Collections.Generic;
using DevelopmentChallenge.Data.Classes;
using NUnit.Framework;

namespace DevelopmentChallenge.Data.Tests
{
    [TestFixture]
    public class DataTests
    {
        [TestCase]
        public void TestResumenListaVacia()
        {
            Assert.AreEqual("<h1>Lista vacía de formas!</h1>",
                FormaGeometrica.Imprimir(new List<FormaGeometrica>(), 1));
        }

        [TestCase]
        public void TestResumenListaVaciaFormasEnIngles()
        {
            Assert.AreEqual("<h1>Empty list of shapes!</h1>",
                FormaGeometrica.Imprimir(new List<FormaGeometrica>(), 2));
        }

        [TestCase]
        public void TestResumenListaConUnCuadrado()
        {
            var cuadrados = new List<FormaGeometrica> {new FormaGeometrica(FormaGeometrica.Cuadrado, 5)};

            var resumen = FormaGeometrica.Imprimir(cuadrados, FormaGeometrica.Castellano);

            Assert.AreEqual("<h1>Reporte de Formas</h1>1 Cuadrado | Area 25 | Perimetro 20 <br/>TOTAL:<br/>1 formas Perimetro 20 Area 25", resumen);
        }

        [TestCase]
        public void TestResumenListaConMasCuadrados()
        {
            var cuadrados = new List<FormaGeometrica>
            {
                new FormaGeometrica(FormaGeometrica.Cuadrado, 5),
                new FormaGeometrica(FormaGeometrica.Cuadrado, 1),
                new FormaGeometrica(FormaGeometrica.Cuadrado, 3)
            };

            var resumen = FormaGeometrica.Imprimir(cuadrados, FormaGeometrica.Ingles);

            Assert.AreEqual("<h1>Shapes report</h1>3 Squares | Area 35 | Perimeter 36 <br/>TOTAL:<br/>3 shapes Perimeter 36 Area 35", resumen);
        }

        [TestCase]
        public void TestResumenListaConMasTipos()
        {
            var formas = new List<FormaGeometrica>
            {
                new FormaGeometrica(FormaGeometrica.Cuadrado, 5),
                new FormaGeometrica(FormaGeometrica.Circulo, 3),
                new FormaGeometrica(FormaGeometrica.TrianguloEquilatero, 4),
                new FormaGeometrica(FormaGeometrica.Cuadrado, 2),
                new FormaGeometrica(FormaGeometrica.TrianguloEquilatero, 9),
                new FormaGeometrica(FormaGeometrica.Circulo, 2.75m),
                new FormaGeometrica(FormaGeometrica.TrianguloEquilatero, 4.2m)
            };

            var resumen = FormaGeometrica.Imprimir(formas, FormaGeometrica.Ingles);

            Assert.AreEqual(
                "<h1>Shapes report</h1>2 Squares | Area 29 | Perimeter 28 <br/>2 Circles | Area 13,01 | Perimeter 18,06 <br/>3 Triangles | Area 49,64 | Perimeter 51,6 <br/>TOTAL:<br/>7 shapes Perimeter 97,66 Area 91,65",
                resumen);
        }

        [TestCase]
        public void TestResumenListaConMasTiposEnCastellano()
        {
            var formas = new List<FormaGeometrica>
            {
                new FormaGeometrica(FormaGeometrica.Cuadrado, 5),
                new FormaGeometrica(FormaGeometrica.Circulo, 3),
                new FormaGeometrica(FormaGeometrica.TrianguloEquilatero, 4),
                new FormaGeometrica(FormaGeometrica.Cuadrado, 2),
                new FormaGeometrica(FormaGeometrica.TrianguloEquilatero, 9),
                new FormaGeometrica(FormaGeometrica.Circulo, 2.75m),
                new FormaGeometrica(FormaGeometrica.TrianguloEquilatero, 4.2m)
            };

            var resumen = FormaGeometrica.Imprimir(formas, FormaGeometrica.Castellano);

            Assert.AreEqual(
                "<h1>Reporte de Formas</h1>2 Cuadrados | Area 29 | Perimetro 28 <br/>2 Círculos | Area 13,01 | Perimetro 18,06 <br/>3 Triángulos | Area 49,64 | Perimetro 51,6 <br/>TOTAL:<br/>7 formas Perimetro 97,66 Area 91,65",
                resumen);
        }

        #region Tests para nuevo idioma Italiano

        [TestCase]
        public void TestResumenListaVaciaEnItaliano()
        {
            Assert.AreEqual("<h1>Elenco vuoto di forme!</h1>",
                FormaGeometrica.Imprimir(new List<FormaGeometrica>(), FormaGeometrica.Italiano));
        }

        [TestCase]
        public void TestResumenListaConUnCuadradoEnItaliano()
        {
            var cuadrados = new List<FormaGeometrica> { new FormaGeometrica(FormaGeometrica.Cuadrado, 5) };

            var resumen = FormaGeometrica.Imprimir(cuadrados, FormaGeometrica.Italiano);

            Assert.AreEqual("<h1>Rapporto di forme</h1>1 Quadrato | Area 25 | Perimetro 20 <br/>TOTAL:<br/>1 forme Perimetro 20 Area 25", resumen);
        }

        [TestCase]
        public void TestResumenListaConMasTiposEnItaliano()
        {
            var formas = new List<FormaGeometrica>
            {
                new FormaGeometrica(FormaGeometrica.Cuadrado, 5),
                new FormaGeometrica(FormaGeometrica.Circulo, 3),
                new FormaGeometrica(FormaGeometrica.TrianguloEquilatero, 4),
                new FormaGeometrica(FormaGeometrica.Cuadrado, 2),
                new FormaGeometrica(FormaGeometrica.TrianguloEquilatero, 9),
                new FormaGeometrica(FormaGeometrica.Circulo, 2.75m),
                new FormaGeometrica(FormaGeometrica.TrianguloEquilatero, 4.2m)
            };

            var resumen = FormaGeometrica.Imprimir(formas, FormaGeometrica.Italiano);

            Assert.AreEqual(
                "<h1>Rapporto di forme</h1>2 Quadrati | Area 29 | Perimetro 28 <br/>2 Cerchi | Area 13,01 | Perimetro 18,06 <br/>3 Triangoli | Area 49,64 | Perimetro 51,6 <br/>TOTAL:<br/>7 forme Perimetro 97,66 Area 91,65",
                resumen);
        }

        #endregion

        #region Tests para nueva forma Trapecio

        [TestCase]
        public void TestResumenListaConUnTrapecioEnCastellano()
        {
            var trapecios = new List<FormaGeometrica> { new FormaGeometrica(FormaGeometrica.Trapecio, 10) };

            var resumen = FormaGeometrica.Imprimir(trapecios, FormaGeometrica.Castellano);

            Assert.AreEqual("<h1>Reporte de Formas</h1>1 Trapecio | Area 40 | Perimetro 24 <br/>TOTAL:<br/>1 formas Perimetro 24 Area 40", resumen);
        }

        [TestCase]
        public void TestResumenListaConVariosTrapecios()
        {
            var trapecios = new List<FormaGeometrica>
            {
                new FormaGeometrica(FormaGeometrica.Trapecio, 10),
                new FormaGeometrica(FormaGeometrica.Trapecio, 8)
            };

            var resumen = FormaGeometrica.Imprimir(trapecios, FormaGeometrica.Ingles);

            // Trapecio 1: Area=40, Perimetro=24
            // Trapecio 2: Area=25.6, Perimetro=19.2
            Assert.AreEqual("<h1>Shapes report</h1>2 Trapezoids | Area 65,6 | Perimeter 43,2 <br/>TOTAL:<br/>2 shapes Perimeter 43,2 Area 65,6", resumen);
        }

        #endregion

        #region Tests para validar cálculos geométricos

        [TestCase]
        public void TestCalculoAreaCuadrado()
        {
            var cuadrado = new FormaGeometrica(FormaGeometrica.Cuadrado, 5);
            Assert.AreEqual(25, cuadrado.CalcularArea());
        }

        [TestCase]
        public void TestCalculoPerimetroCuadrado()
        {
            var cuadrado = new FormaGeometrica(FormaGeometrica.Cuadrado, 5);
            Assert.AreEqual(20, cuadrado.CalcularPerimetro());
        }

        [TestCase]
        public void TestCalculoAreaCirculo()
        {
            var circulo = new FormaGeometrica(FormaGeometrica.Circulo, 4);
            var areaEsperada = (decimal)Math.PI * 4;
            Assert.AreEqual((double)areaEsperada, (double)circulo.CalcularArea(), 0.01);
        }

        [TestCase]
        public void TestCalculoPerimetroCirculo()
        {
            var circulo = new FormaGeometrica(FormaGeometrica.Circulo, 4);
            var perimetroEsperado = (decimal)Math.PI * 4;
            Assert.AreEqual((double)perimetroEsperado, (double)circulo.CalcularPerimetro(), 0.01);
        }

        [TestCase]
        public void TestCalculoAreaTrianguloEquilatero()
        {
            var triangulo = new FormaGeometrica(FormaGeometrica.TrianguloEquilatero, 4);
            var areaEsperada = ((decimal)Math.Sqrt(3) / 4) * 16;
            Assert.AreEqual((double)areaEsperada, (double)triangulo.CalcularArea(), 0.01);
        }

        [TestCase]
        public void TestCalculoPerimetroTrianguloEquilatero()
        {
            var triangulo = new FormaGeometrica(FormaGeometrica.TrianguloEquilatero, 4);
            Assert.AreEqual(12, triangulo.CalcularPerimetro());
        }

        #endregion

        #region Tests para validar pluralización

        [TestCase]
        public void TestPluralCuadradosEnCastellano()
        {
            var cuadrados = new List<FormaGeometrica>
            {
                new FormaGeometrica(FormaGeometrica.Cuadrado, 2),
                new FormaGeometrica(FormaGeometrica.Cuadrado, 3)
            };

            var resumen = FormaGeometrica.Imprimir(cuadrados, FormaGeometrica.Castellano);

            Assert.IsTrue(resumen.Contains("2 Cuadrados"));
        }

        [TestCase]
        public void TestSingularCuadradoEnIngles()
        {
            var cuadrados = new List<FormaGeometrica>
            {
                new FormaGeometrica(FormaGeometrica.Cuadrado, 5)
            };

            var resumen = FormaGeometrica.Imprimir(cuadrados, FormaGeometrica.Ingles);

            Assert.IsTrue(resumen.Contains("1 Square"));
        }

        #endregion

        #region Tests para validar formato de salida HTML

        [TestCase]
        public void TestFormatoHTMLContieneHeader()
        {
            var formas = new List<FormaGeometrica> { new FormaGeometrica(FormaGeometrica.Cuadrado, 5) };

            var resumen = FormaGeometrica.Imprimir(formas, FormaGeometrica.Castellano);

            Assert.IsTrue(resumen.StartsWith("<h1>"));
        }

        [TestCase]
        public void TestFormatoHTMLContieneBreakLines()
        {
            var formas = new List<FormaGeometrica> { new FormaGeometrica(FormaGeometrica.Cuadrado, 5) };

            var resumen = FormaGeometrica.Imprimir(formas, FormaGeometrica.Castellano);

            Assert.IsTrue(resumen.Contains("<br/>"));
        }

        [TestCase]
        public void TestFormatoHTMLContieneSeccionTotal()
        {
            var formas = new List<FormaGeometrica> { new FormaGeometrica(FormaGeometrica.Cuadrado, 5) };

            var resumen = FormaGeometrica.Imprimir(formas, FormaGeometrica.Castellano);

            Assert.IsTrue(resumen.Contains("TOTAL:"));
        }

        #endregion
    }
}
