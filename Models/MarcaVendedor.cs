using System;
using System.Collections.Generic;

namespace JaMPeApp.Models
{
    public partial class MarcaVendedor
    {
        public int MarcaId { get; set; }
        public int VendedorId { get; set; }

        public virtual Vendedor Vendedor { get; set; } = null!;
    }
}
