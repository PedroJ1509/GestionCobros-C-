using System;
using System.Collections.Generic;

namespace JaMPeApp.Models
{
    public partial class EfectivoGasto
    {
        public int EfectivoId { get; set; }
        public int EfectivoLinGa { get; set; }
        public int? RecGastoId { get; set; }
        public decimal? EfectivoMontoGa { get; set; }

        public virtual Efectivo Efectivo { get; set; } = null!;
        public virtual RecGasto? RecGasto { get; set; }
    }
}
