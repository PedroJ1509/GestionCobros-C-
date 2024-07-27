using System;
using System.Collections.Generic;

namespace JaMPeApp.Models
{
    public partial class Mesa
    {
        public Mesa()
        {
            Facturas = new HashSet<Factura>();
            FacturasNavigation = new HashSet<Factura>();
        }

        public int MesaId { get; set; }
        public int? MesaNo { get; set; }
        public string? MesaDesc { get; set; }
        public bool? MesaEstatus { get; set; }
        public int? SalaId { get; set; }

        public virtual Sala? Sala { get; set; }
        public virtual ICollection<Factura> Facturas { get; set; }

        public virtual ICollection<Factura> FacturasNavigation { get; set; }
    }
}
