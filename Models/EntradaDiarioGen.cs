using System;
using System.Collections.Generic;

namespace JaMPeApp.Models
{
    public partial class EntradaDiarioGen
    {
        public DateTime? Fecha { get; set; }
        public string? Orden { get; set; }
        public string? CuentaNo { get; set; }
        public string? CuentaDesc { get; set; }
        public double? Debito { get; set; }
        public double? Credito { get; set; }
    }
}
