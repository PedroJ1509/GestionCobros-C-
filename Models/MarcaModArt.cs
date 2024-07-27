using System;
using System.Collections.Generic;

namespace JaMPeApp.Models
{
    public partial class MarcaModArt
    {
        public int ArticuloId { get; set; }
        public int MarcaId { get; set; }
        public int ModeloId { get; set; }

        public virtual Modelo Modelo { get; set; } = null!;
    }
}
