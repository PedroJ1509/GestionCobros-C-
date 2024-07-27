using System;
using System.Collections.Generic;

namespace JaMPeApp.Models
{
    public partial class ChequeCajaChica
    {
        public int ChequeId { get; set; }
        public int ChequeLinCc { get; set; }
        public int? CajaChicaId { get; set; }
        public decimal? ChequeMontoCc { get; set; }

        public virtual CajaChica? CajaChica { get; set; }
        public virtual Cheque Cheque { get; set; } = null!;
    }
}
