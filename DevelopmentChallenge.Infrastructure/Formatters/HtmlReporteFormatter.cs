using System.Text;
using DevelopmentChallenge.Domain.Interfaces;
using DevelopmentChallenge.Domain.Models;

namespace DevelopmentChallenge.Infrastructure.Formatters
{
    public class HtmlReporteFormatter : IReporteFormatter
    {
        private readonly ILocalizacionService _localizacion;

        public HtmlReporteFormatter(ILocalizacionService localizacion)
        {
            _localizacion = localizacion;
        }

        public string Formatear(ReporteResultado resultado)
        {
            var sb = new StringBuilder();

            if (resultado.EsListaVacia)
            {
                sb.Append(_localizacion.ObtenerTexto("ListaVacia"));
                return sb.ToString();
            }

            sb.Append(_localizacion.ObtenerTexto("ReporteHeader"));

            foreach (var grupo in resultado.Grupos)
            {
                var nombreForma = _localizacion.ObtenerNombreForma(grupo.TipoForma, grupo.Cantidad);
                var labelArea = _localizacion.ObtenerTexto("Area");
                var labelPerimetro = _localizacion.ObtenerTexto("Perimetro");

                sb.Append($"{grupo.Cantidad} {nombreForma} | {labelArea} {grupo.AreaTotal:#.##} | {labelPerimetro} {grupo.PerimetroTotal:#.##} <br/>");
            }

            sb.Append("TOTAL:<br/>");
            sb.Append($"{resultado.Total.CantidadTotal} {_localizacion.ObtenerTexto("Formas")} ");
            sb.Append($"{_localizacion.ObtenerTexto("Perimetro")} {resultado.Total.PerimetroTotal:#.##} ");
            sb.Append($"{_localizacion.ObtenerTexto("Area")} {resultado.Total.AreaTotal:#.##}");

            return sb.ToString();
        }
    }
}
