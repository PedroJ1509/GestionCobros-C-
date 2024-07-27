using System;
using System.Collections.Generic;

namespace JaMPeApp.Models
{
    public partial class ChequeCompra
    {
        public int ChequeId { get; set; }
        public int ChequeLinCi { get; set; }
        public int? CompraId { get; set; }
        public decimal? ChequeMontoCi { get; set; }
        public decimal? ChequeDesctoCi { get; set; }

        public virtual Cheque Cheque { get; set; } = null!;
        public virtual Compra? Compra { get; set; }
    }
}
