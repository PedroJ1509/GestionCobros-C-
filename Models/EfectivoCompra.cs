using System;
using System.Collections.Generic;

namespace JaMPeApp.Models
{
    public partial class EfectivoCompra
    {
        public int EfectivoId { get; set; }
        public int EfectivoLinCi { get; set; }
        public int? CompraId { get; set; }
        public decimal? EfectivoMontoCi { get; set; }
        public decimal? EfectivoDesctoCi { get; set; }

        public virtual Compra? Compra { get; set; }
        public virtual Efectivo Efectivo { get; set; } = null!;
    }
}
