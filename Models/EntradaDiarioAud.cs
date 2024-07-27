using System;
using System.Collections.Generic;

namespace JaMPeApp.Models
{
    public partial class EntradaDiarioAud
    {
        public string? Tipo { get; set; }
        public DateTime? Fecha { get; set; }
        public string? Codigo { get; set; }
        public string? NoDoc { get; set; }
        public string? CuentaNo { get; set; }
        public string? CuentaDesc { get; set; }
        public double? Debitos { get; set; }
        public double? Creditos { get; set; }
        public string? Desc2 { get; set; }
    }
}
