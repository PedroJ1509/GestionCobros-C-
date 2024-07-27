using System;
using System.Collections.Generic;

namespace JaMPeApp.Models
{
    public partial class FacturaUsuairoPrefactura
    {
        public int? FacturaId { get; set; }
        public int? UsuarioId { get; set; }
        public DateTime? FechaImpPrefactura { get; set; }
    }
}
