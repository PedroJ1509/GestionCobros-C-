using System;
using System.Collections.Generic;

namespace JaMPeApp.Models
{
    public partial class TipoActivoFijo
    {
        public TipoActivoFijo()
        {
            ActivoFijos = new HashSet<ActivoFijo>();
        }

        public int TipoActivoFijoId { get; set; }
        public string? TipoActivoFijoDesc { get; set; }
        public int? CuentaId { get; set; }
        public int? CuentaIdDepreciacion { get; set; }
        public int? CuentaIdGasto { get; set; }

        public virtual ICollection<ActivoFijo> ActivoFijos { get; set; }
    }
}
