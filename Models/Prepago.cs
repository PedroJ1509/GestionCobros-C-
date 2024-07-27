using System;
using System.Collections.Generic;

namespace JaMPeApp.Models
{
    public partial class Prepago
    {
        public Prepago()
        {
            PrepagoDets = new HashSet<PrepagoDet>();
        }

        public int PrepagoId { get; set; }
        public int? PrepagoNo { get; set; }
        public DateTime? PrepagoFecha { get; set; }
        public int? ClienteId { get; set; }
        public decimal? PrepagoValorTotal { get; set; }
        public string? PrepagoComprobante { get; set; }
        public short? ComprobanteTipoId { get; set; }
        public string? PrepagoNota { get; set; }

        public virtual Cliente? Cliente { get; set; }
        public virtual ComprobanteTipo? ComprobanteTipo { get; set; }
        public virtual ICollection<PrepagoDet> PrepagoDets { get; set; }
    }
}
