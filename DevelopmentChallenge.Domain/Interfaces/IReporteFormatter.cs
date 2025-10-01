using DevelopmentChallenge.Domain.Models;

namespace DevelopmentChallenge.Domain.Interfaces
{
    public interface IReporteFormatter
    {
        string Formatear(ReporteResultado resultado);
    }
}
