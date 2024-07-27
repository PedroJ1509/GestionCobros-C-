using System;
using System.Collections.Generic;

namespace JaMPeApp.Models
{
    public partial class VRepLo1
    {
        public DateTime? FacturaFecha { get; set; }
        public string Tipo { get; set; } = null!;
        public string? SubTipo { get; set; }
        public float? Monto { get; set; }
    }
}
