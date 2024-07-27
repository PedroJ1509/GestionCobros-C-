using System;
using System.Collections.Generic;

namespace JaMPeApp.Models
{
    public partial class Gasto
    {
        public Gasto()
        {
            CajaChicaDets = new HashSet<CajaChicaDet>();
        }

        public int GastoId { get; set; }
        public string? GastoDesc { get; set; }
        public bool GastoEstatus { get; set; }
        public string? GastoClasCode { get; set; }
        public int? CuentaId { get; set; }

        public virtual Cuentum? Cuenta { get; set; }
        public virtual ICollection<CajaChicaDet> CajaChicaDets { get; set; }
    }
}
