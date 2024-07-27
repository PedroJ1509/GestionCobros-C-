using System;
using System.Collections.Generic;

namespace JaMPeApp.Models
{
    public partial class TipoPago
    {
        public TipoPago()
        {
            CuotaTipoPagos = new HashSet<CuotaTipoPago>();
            PrepagoDets = new HashSet<PrepagoDet>();
        }

        public int TipoPagoId { get; set; }
        public string? TipoPagoDesc { get; set; }
        public bool TipoPagoEstatus { get; set; }
        public bool TipoPagoSiNotaCredito { get; set; }
        public bool TipoPagoSiEfectivo { get; set; }
        public int? CuentaId { get; set; }
        public int? TipoPagoIfnoPago { get; set; }
        public bool? TipoPagoSiRnc { get; set; }
        public bool? TipoPagoSiNotaCr { get; set; }
        public bool? TipoPagoSiPrepago { get; set; }
        public bool? TipoPagoSiPuntos { get; set; }

        public virtual Cuentum? Cuenta { get; set; }
        public virtual ICollection<CuotaTipoPago> CuotaTipoPagos { get; set; }
        public virtual ICollection<PrepagoDet> PrepagoDets { get; set; }
    }
}
