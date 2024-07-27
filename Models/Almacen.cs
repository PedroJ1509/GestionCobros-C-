using System;
using System.Collections.Generic;

namespace JaMPeApp.Models
{
    public partial class Almacen
    {
        public Almacen()
        {
            AjustInventarios = new HashSet<AjustInventario>();
            OrdenCompras = new HashSet<OrdenCompra>();
            OrdenProduccionArtUsados = new HashSet<OrdenProduccionArtUsado>();
        }

        public int AlmacenId { get; set; }
        public string? AlmacenDesc { get; set; }
        public short? AlmacenPrecioNo { get; set; }

        public virtual ICollection<AjustInventario> AjustInventarios { get; set; }
        public virtual ICollection<OrdenCompra> OrdenCompras { get; set; }
        public virtual ICollection<OrdenProduccionArtUsado> OrdenProduccionArtUsados { get; set; }
    }
}
