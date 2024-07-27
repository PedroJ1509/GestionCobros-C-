using System;
using System.Collections.Generic;

namespace JaMPeApp.Models
{
    public partial class ImpresionComanda
    {
        public int? FacturaId { get; set; }
        public DateTime? FechaComanda { get; set; }
        public int? DepartamentoId { get; set; }
        public bool? Procesada { get; set; }
        public bool? Impresa { get; set; }
        public DateTime? FechaImpresa { get; set; }
        public int? FacturaDetId { get; set; }
        public int ImpresionComandaId { get; set; }

        public virtual Departamento? Departamento { get; set; }
        public virtual Factura? Factura { get; set; }
    }
}
