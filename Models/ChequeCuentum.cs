using System;
using System.Collections.Generic;

namespace JaMPeApp.Models
{
    public partial class ChequeCuentum
    {
        public int ChequeId { get; set; }
        public int ChequeLinCta { get; set; }
        public int? CuentaId { get; set; }
        public decimal? ChequeMontoCta { get; set; }
    }
}
