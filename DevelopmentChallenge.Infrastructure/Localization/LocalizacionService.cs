using System.Globalization;
using DevelopmentChallenge.Domain.Interfaces;
using DevelopmentChallenge.Infrastructure.Resources;

namespace DevelopmentChallenge.Infrastructure.Localization
{
    public class LocalizacionService : ILocalizacionService
    {
        private readonly CultureInfo _culture;

        public LocalizacionService(CultureInfo culture)
        {
            _culture = culture;
        }

        public string ObtenerTexto(string clave)
        {
            return Textos.ResourceManager.GetString(clave, _culture);
        }

        public string ObtenerNombreForma(string tipoForma, int cantidad)
        {
            var claveSingular = tipoForma + "Singular";
            var clavePlural = tipoForma + "Plural";

            return cantidad == 1
                ? ObtenerTexto(claveSingular)
                : ObtenerTexto(clavePlural);
        }
    }
}
