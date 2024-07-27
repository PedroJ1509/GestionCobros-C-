using System;
using System.Collections.Generic;

namespace JaMPeApp.Models
{
    public partial class ChequeGasto
    {
        public int ChequeId { get; set; }
        public int ChequeLinGa { get; set; }
        public int? RecGastoId { get; set; }
        public decimal? ChequeMontoGa { get; set; }

        public virtual Cheque Cheque { get; set; } = null!;
        public virtual RecGasto? RecGasto { get; set; }
    }
}
