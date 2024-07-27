using System;
using System.Collections.Generic;

namespace JaMPeApp.Models
{
    public partial class CuotaDet
    {
        public int CuotaId { get; set; }
        public int PrestamoId { get; set; }
        public int CuotaDetSec { get; set; }
        public decimal? CuotaDetMontoCapital { get; set; }
        public decimal? CuotaDetMontoInteres { get; set; }

        public virtual Cuotum Cuota { get; set; } = null!;
        public virtual Prestamo Prestamo { get; set; } = null!;
    }
}
