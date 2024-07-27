using System;
using System.Collections.Generic;

namespace JaMPeApp.Models
{
    public partial class EntradaDiarioDet
    {
        public int EntradaDiarioDetId { get; set; }
        public int? EntradaDiarioId { get; set; }
        public int? CuentaId { get; set; }
        public decimal? EntradaDiarioDebito { get; set; }
        public decimal? EntradaDiarioCredito { get; set; }

        public virtual Cuentum? Cuenta { get; set; }
        public virtual EntradaDiario? EntradaDiario { get; set; }
    }
}
