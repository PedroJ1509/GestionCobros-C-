using System;
using System.Collections.Generic;

namespace JaMPeApp.Models
{
    public partial class AjustInventario
    {
        public AjustInventario()
        {
            AjustInventarioDets = new HashSet<AjustInventarioDet>();
        }

        public int AjustInventarioId { get; set; }
        public int? AjustInventarioNo { get; set; }
        public DateTime? AjustInventarioFecha { get; set; }
        public decimal? AjustInventarioMontoEntrada { get; set; }
        public decimal? AjustInventarioMontoSalida { get; set; }
        public bool? AjustInventarioEstatus { get; set; }
        public int? AlmacenId { get; set; }
        public DateTime? AjustInventarioFechaCierre { get; set; }
        public int? UsuarioId { get; set; }
        public int? DepartamentoId { get; set; }

        public virtual Almacen? Almacen { get; set; }
        public virtual Usuario? Usuario { get; set; }
        public virtual ICollection<AjustInventarioDet> AjustInventarioDets { get; set; }
    }
}
