using System;
using System.Collections.Generic;

namespace JaMPeApp.Models
{
    public partial class VRepLo4
    {
        public DateTime? ChequeFecha { get; set; }
        public string Tipo { get; set; } = null!;
        public string? BancoNombre { get; set; }
        public decimal? Monto { get; set; }
    }
}
