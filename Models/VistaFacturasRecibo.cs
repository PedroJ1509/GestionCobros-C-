using System;
using System.Collections.Generic;

namespace JaMPeApp.Models
{
    public partial class VistaFacturasRecibo
    {
        public int ReciboId { get; set; }
        public string? NumFacturas { get; set; }
        public string? ComprobantesFacturas { get; set; }
        public int? ClienteId { get; set; }
    }
}
