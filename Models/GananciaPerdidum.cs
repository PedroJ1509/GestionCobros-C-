using System;
using System.Collections.Generic;

namespace JaMPeApp.Models
{
    public partial class GananciaPerdidum
    {
        public int GananciaPerdidaId { get; set; }
        public DateTime? GananciaPerdidaFecha { get; set; }
        public decimal? GananciaPerdidaMonto { get; set; }
        public string? GananciaPerdidaDesc { get; set; }
    }
}
