using System;
using System.Collections.Generic;

namespace JaMPeApp.Models
{
    public partial class Unidad
    {
        public Unidad()
        {
            ArticuloAnalisisCostoDets = new HashSet<ArticuloAnalisisCostoDet>();
            ArticuloPorKits = new HashSet<ArticuloPorKit>();
        }

        public int UnidadId { get; set; }
        public string? UnidadDesc { get; set; }

        public virtual ICollection<ArticuloAnalisisCostoDet> ArticuloAnalisisCostoDets { get; set; }
        public virtual ICollection<ArticuloPorKit> ArticuloPorKits { get; set; }
    }
}
