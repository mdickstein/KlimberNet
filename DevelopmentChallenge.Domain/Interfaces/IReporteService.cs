using System.Collections.Generic;
using DevelopmentChallenge.Domain.Models;

namespace DevelopmentChallenge.Domain.Interfaces
{
    public interface IReporteService
    {
        ReporteResultado GenerarReporte(List<IFormaGeometrica> formas);
    }
}
