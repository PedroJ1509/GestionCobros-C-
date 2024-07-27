using System;
using System.Collections.Generic;

#nullable disable

namespace JaMPeApp.Models
{
    public partial class FacturaMesa
    {
        public int FacturaId { get; set; }
        public int MesaId { get; set; }

        public virtual Factura Factura { get; set; }
        public virtual Mesa Mesa { get; set; }
    }
}
