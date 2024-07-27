using System;
using System.Collections.Generic;

namespace JaMPeApp.Models
{
    public partial class VRepLo2
    {
        public string Tipo { get; set; } = null!;
        public decimal? Monto0Dias { get; set; }
        public decimal? Monto30Dias { get; set; }
        public decimal? Monto60Dias { get; set; }
        public decimal? Monto90Dias { get; set; }
        public decimal? Monto120Dias { get; set; }
        public decimal? Monto120masDias { get; set; }
    }
}
