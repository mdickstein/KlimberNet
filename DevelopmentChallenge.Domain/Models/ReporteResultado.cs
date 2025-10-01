using System.Collections.Generic;

namespace DevelopmentChallenge.Domain.Models
{
    public class ReporteResultado
    {
        public bool EsListaVacia { get; set; }
        public List<GrupoForma> Grupos { get; set; }
        public ResumenTotal Total { get; set; }

        public ReporteResultado()
        {
            Grupos = new List<GrupoForma>();
            Total = new ResumenTotal();
        }
    }

    public class GrupoForma
    {
        public string TipoForma { get; set; }
        public int Cantidad { get; set; }
        public decimal AreaTotal { get; set; }
        public decimal PerimetroTotal { get; set; }
    }

    public class ResumenTotal
    {
        public int CantidadTotal { get; set; }
        public decimal AreaTotal { get; set; }
        public decimal PerimetroTotal { get; set; }
    }
}
