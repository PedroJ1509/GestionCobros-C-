using System;
using System.Collections.Generic;

namespace JaMPeApp.Models
{
    public partial class ChequeItbi
    {
        public int ChequeId { get; set; }
        public int ChequeLinIt { get; set; }
        public int? ItbisId { get; set; }
        public decimal? ChequeMontoIt { get; set; }

        public virtual Cheque Cheque { get; set; } = null!;
        public virtual Itbi? Itbis { get; set; }
    }
}
