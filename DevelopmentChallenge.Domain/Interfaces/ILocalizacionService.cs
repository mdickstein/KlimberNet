namespace DevelopmentChallenge.Domain.Interfaces
{
    public interface ILocalizacionService
    {
        string ObtenerTexto(string clave);
        string ObtenerNombreForma(string tipoForma, int cantidad);
    }
}
