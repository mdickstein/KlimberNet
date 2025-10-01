/*
 * ====================================================================================
 * REFACTORIZACIÓN: Clean Architecture + SOLID
 * ====================================================================================
 *
 * Se refactorizó el código original aplicando Clean Architecture y principios SOLID
 * para lograr un sistema mantenible, extensible y testeable.
 *
 * ARQUITECTURA EN CAPAS:
 *
 * 1. Domain Layer: Entidades (Cuadrado, Circulo, TrianguloEquilatero, Trapecio),
 *    Interfaces (IFormaGeometrica, ILocalizacionService, IReporteService, IReporteFormatter)
 *    y Models (ReporteResultado). Sin dependencias externas.
 *
 * 2. Application Layer: ReporteService (caso de uso para generar reportes).
 *    Depende solo de Domain.
 *
 * 3. Infrastructure Layer: LocalizacionService (archivos .resx para i18n) y
 *    HtmlReporteFormatter (generación de reportes HTML). Depende de Domain.
 *
 * 4. Presentation Layer: Esta clase actúa como wrapper legacy, Tests y Console.
 *
 * ====================================================================================
 */

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using DevelopmentChallenge.Domain.Entities;
using DevelopmentChallenge.Domain.Interfaces;
using DevelopmentChallenge.Application.Services;
using DevelopmentChallenge.Infrastructure.Localization;
using DevelopmentChallenge.Infrastructure.Formatters;

namespace DevelopmentChallenge.Data.Classes
{
    /// <summary>
    /// Wrapper legacy para mantener compatibilidad con API existente.
    /// Internamente usa la arquitectura limpia con Domain, Application e Infrastructure.
    /// </summary>
    public class FormaGeometrica
    {
        public const int Cuadrado = 1;
        public const int TrianguloEquilatero = 2;
        public const int Circulo = 3;
        public const int Trapecio = 4;

        public const int Castellano = 1;
        public const int Ingles = 2;
        public const int Italiano = 3;

        private readonly IFormaGeometrica _formaInterna;

        public int Tipo { get; set; }

        public FormaGeometrica(int tipo, decimal medida)
        {
            Tipo = tipo;
            _formaInterna = CrearForma(tipo, medida);
        }

        private static IFormaGeometrica CrearForma(int tipo, decimal medida)
        {
            switch (tipo)
            {
                case Cuadrado: return new Cuadrado(medida);
                case Circulo: return new Circulo(medida);
                case TrianguloEquilatero: return new TrianguloEquilatero(medida);
                case Trapecio:
                    return new Trapecio(medida, medida * 0.6m, medida * 0.5m, medida * 0.4m);
                default:
                    throw new ArgumentOutOfRangeException(nameof(tipo), "Forma desconocida");
            }
        }

        public static string Imprimir(List<FormaGeometrica> formas, int idioma)
        {
            var formasDominio = formas.Select(f => f._formaInterna).ToList();
            var culture = ObtenerCultura(idioma);
            var localizacionService = new LocalizacionService(culture);
            var reporteService = new ReporteService();
            var formatter = new HtmlReporteFormatter(localizacionService);
            var resultado = reporteService.GenerarReporte(formasDominio);
            return formatter.Formatear(resultado);
        }

        private static CultureInfo ObtenerCultura(int idioma)
        {
            switch (idioma)
            {
                case Castellano: return new CultureInfo("es");
                case Ingles: return new CultureInfo("en");
                case Italiano: return new CultureInfo("it");
                default: return new CultureInfo("en");
            }
        }

        public decimal CalcularArea()
        {
            return _formaInterna.CalcularArea();
        }

        public decimal CalcularPerimetro()
        {
            return _formaInterna.CalcularPerimetro();
        }
    }
}
