using System;
using System.Collections.Generic;

namespace JaMPeApp.Models
{
    public partial class ChequePrestamo
    {
        public int ChequeId { get; set; }
        public int ChequeLinPr { get; set; }
        public int? PrestamoId { get; set; }
        public decimal? ChequeMontoPr { get; set; }

        public virtual Cheque Cheque { get; set; } = null!;
        public virtual Prestamo? Prestamo { get; set; }
    }
}
