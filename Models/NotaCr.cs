using System;
using System.Collections.Generic;

namespace JaMPeApp.Models
{
    public partial class NotaCr
    {
        public NotaCr()
        {
            CuotaTipoPagos = new HashSet<CuotaTipoPago>();
            NotaCrDets = new HashSet<NotaCrDet>();
        }

        public int NotaCrId { get; set; }
        public string? NotaCrNo { get; set; }
        public DateTime? NotaCrFecha { get; set; }
        public int? FacturaId { get; set; }
        public decimal? NotaCrMonto { get; set; }
        public decimal? NotaCrDescto { get; set; }
        public decimal? NotaCrItbis { get; set; }
        public string? NotaCrComentario { get; set; }
        public float? NotaCrMontoUsado { get; set; }
        public decimal? NotaCrCosto { get; set; }
        public string? NotaCrComprobante { get; set; }
        public byte[]? UpsizeTs { get; set; }

        public virtual Factura? Factura { get; set; }
        public virtual ICollection<CuotaTipoPago> CuotaTipoPagos { get; set; }
        public virtual ICollection<NotaCrDet> NotaCrDets { get; set; }
    }
}
