using System;
using System.Collections.Generic;

namespace JaMPeApp.Models
{
    public partial class DepositoCierreCaja
    {
        public int DepositoId { get; set; }
        public int CierreCajaId { get; set; }
        public decimal? DepositoCierreCajaMonto { get; set; }

        public virtual CierreCaja CierreCaja { get; set; } = null!;
        public virtual Deposito Deposito { get; set; } = null!;
    }
}
