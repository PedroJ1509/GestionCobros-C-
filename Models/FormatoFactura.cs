using System;
using System.Collections.Generic;

namespace JaMPeApp.Models
{
    public partial class FormatoFactura
    {
        public int FormatoFacturaId { get; set; }
        public string? FormatoFacturaDesc { get; set; }
        public string? FormatoFacturaImpresora { get; set; }
        public int? FormatoFacturaNoImpresion { get; set; }
        public string? FormatoFacturaNombreReporte { get; set; }
    }
}
