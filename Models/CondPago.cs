using System;
using System.Collections.Generic;

namespace JaMPeApp.Models
{
    public partial class CondPago
    {
        public CondPago()
        {
            Clientes = new HashSet<Cliente>();
            OrdenCompras = new HashSet<OrdenCompra>();
        }

        public int CondPagoId { get; set; }
        public string? CondPagoDesc { get; set; }
        public short? CondPagoDias { get; set; }

        public virtual ICollection<Cliente> Clientes { get; set; }
        public virtual ICollection<OrdenCompra> OrdenCompras { get; set; }
    }
}
