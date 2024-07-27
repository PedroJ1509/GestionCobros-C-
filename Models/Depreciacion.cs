using System;
using System.Collections.Generic;

namespace JaMPeApp.Models
{
    public partial class Depreciacion
    {
        public int DepreciacionId { get; set; }
        public int? TipoActivoFijoId { get; set; }
        public short? DepreciacionAno { get; set; }
        public short? DepreciacionMes { get; set; }
        public decimal? DepreciacionMonto { get; set; }
        public bool DepreciacionSiBeneficio { get; set; }
    }
}
