using System;
using System.Collections.Generic;

namespace JaMPeApp.Models
{
    public partial class Cotizacion
    {
        public Cotizacion()
        {
            AnalisisCostos = new HashSet<AnalisisCosto>();
            CotizacionDets = new HashSet<CotizacionDet>();
        }

        public int CotizacionId { get; set; }
        public string? CotizacionNo { get; set; }
        public DateTime? CotizacionFecha { get; set; }
        public int? CondPagoId { get; set; }
        public int? ClienteId { get; set; }
        public int? VendedorId { get; set; }
        public decimal? CotizacionDescto { get; set; }
        public decimal? CotizacionItbis { get; set; }
        public decimal? CotizacionBalance { get; set; }
        public string? CotizacionCliente { get; set; }
        public string? CotizacionDatos { get; set; }
        public int? FacturaId { get; set; }
        public int? OrdenProduccionId { get; set; }
        public int? AlmacenId { get; set; }

        public virtual ICollection<AnalisisCosto> AnalisisCostos { get; set; }
        public virtual ICollection<CotizacionDet> CotizacionDets { get; set; }
    }
}
