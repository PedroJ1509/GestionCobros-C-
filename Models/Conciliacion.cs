using System;
using System.Collections.Generic;

namespace JaMPeApp.Models
{
    public partial class Conciliacion
    {
        public string ConciliacionNo { get; set; } = null!;
        public int BancoId { get; set; }
        public decimal? ConciliacionMontoFinal { get; set; }

        public virtual Banco Banco { get; set; } = null!;
    }
}
