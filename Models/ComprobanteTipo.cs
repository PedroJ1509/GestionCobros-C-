using System;
using System.Collections.Generic;

namespace JaMPeApp.Models
{
    public partial class ComprobanteTipo
    {
        public ComprobanteTipo()
        {
            ComprobanteDisps = new HashSet<ComprobanteDisp>();
            Prepagos = new HashSet<Prepago>();
        }

        public short ComprobanteTipoId { get; set; }
        public string? ComprobanteDesc { get; set; }
        public string? ComprobanteDondeUsar { get; set; }
        public string? ComprobanteTextoInicial { get; set; }
        public bool ComprobanteNoitbis { get; set; }
        public bool? ComprobanteSiFechaVen { get; set; }
        public DateTime? ComprobanteFechaVen { get; set; }

        public virtual Comprobante? Comprobante { get; set; }
        public virtual ICollection<ComprobanteDisp> ComprobanteDisps { get; set; }
        public virtual ICollection<Prepago> Prepagos { get; set; }
    }
}
