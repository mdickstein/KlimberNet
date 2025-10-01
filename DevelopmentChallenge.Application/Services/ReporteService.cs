using System.Collections.Generic;
using System.Linq;
using DevelopmentChallenge.Domain.Interfaces;
using DevelopmentChallenge.Domain.Models;

namespace DevelopmentChallenge.Application.Services
{
    public class ReporteService : IReporteService
    {
        public ReporteResultado GenerarReporte(List<IFormaGeometrica> formas)
        {
            var resultado = new ReporteResultado();

            if (formas == null || !formas.Any())
            {
                resultado.EsListaVacia = true;
                return resultado;
            }

            resultado.EsListaVacia = false;

            var grupos = formas.GroupBy(f => f.ObtenerTipoForma())
                .Select(g => new GrupoForma
                {
                    TipoForma = g.Key,
                    Cantidad = g.Count(),
                    AreaTotal = g.Sum(f => f.CalcularArea()),
                    PerimetroTotal = g.Sum(f => f.CalcularPerimetro())
                }).ToList();

            resultado.Grupos = grupos;

            resultado.Total = new ResumenTotal
            {
                CantidadTotal = grupos.Sum(g => g.Cantidad),
                AreaTotal = grupos.Sum(g => g.AreaTotal),
                PerimetroTotal = grupos.Sum(g => g.PerimetroTotal)
            };

            return resultado;
        }
    }
}
