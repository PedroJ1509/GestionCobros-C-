using System;
using System.Collections.Generic;

namespace JaMPeApp.Models
{
    public partial class QEntradasDeDiarioC
    {
        public DateTime? Fechas { get; set; }
        public string Orden { get; set; } = null!;
        public string? CuentaNo { get; set; }
        public string? CuentaDesc { get; set; }
        public double? Debitos { get; set; }
        public double? Creditos { get; set; }
    }
}
