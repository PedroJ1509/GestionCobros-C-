using System;
using System.Collections.Generic;

namespace JaMPeApp.Models
{
    public partial class OrdenCompra
    {
        public OrdenCompra()
        {
            OrdenCompraDets = new HashSet<OrdenCompraDet>();
        }

        public int OrdenCompraId { get; set; }
        public string? OrdenCompraNo { get; set; }
        public DateTime? OrdenCompraFecha { get; set; }
        public int? SuplidorId { get; set; }
        public int? CondPagoId { get; set; }
        public decimal? OrdenCompraItbis { get; set; }
        public decimal? OrdenCompraDescto { get; set; }
        public decimal? OrdenCompraMonto { get; set; }
        /// <summary>
        /// Yes = Abierta, No = Cerrada
        /// </summary>
        public bool OrdenCompraEstatus { get; set; }
        public bool OrdenCompraSiCompra { get; set; }
        public string? OrdenCompraComentario { get; set; }
        public int? AlmacenId { get; set; }

        public virtual Almacen? Almacen { get; set; }
        public virtual CondPago? CondPago { get; set; }
        public virtual Suplidor? Suplidor { get; set; }
        public virtual ICollection<OrdenCompraDet> OrdenCompraDets { get; set; }
    }
}
