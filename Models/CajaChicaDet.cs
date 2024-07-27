using System;
using System.Collections.Generic;

namespace JaMPeApp.Models
{
    public partial class CajaChicaDet
    {
        public int CajaChicaDetId { get; set; }
        public int? CajaChicaId { get; set; }
        public DateTime? CajaChicaDetFecha { get; set; }
        public decimal? CajaChicaDetMonto { get; set; }
        public string? CajaChicaDetComentario { get; set; }
        public bool CajaChicaDetSiBeneficio { get; set; }
        public int? GastoId { get; set; }
        public decimal? CajaChicaDetItbis { get; set; }
        public string? CajaChicaDetNcf { get; set; }

        public virtual CajaChica? CajaChica { get; set; }
        public virtual Gasto? Gasto { get; set; }
    }
}
