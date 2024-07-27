using System;
using System.Collections.Generic;

namespace JaMPeApp.Models
{
    public partial class AjustInventarioDet
    {
        public int AjustInventarioDetId { get; set; }
        public int? AjustInventarioId { get; set; }
        public int? ArticuloId { get; set; }
        public int? AjustInventarioDetCantidad { get; set; }
        public decimal? AjustInventarioDetCosto { get; set; }
        public int? UsuarioId { get; set; }
        public DateTime? AjustInventarioDetFecha { get; set; }

        public virtual AjustInventario? AjustInventario { get; set; }
    }
}
