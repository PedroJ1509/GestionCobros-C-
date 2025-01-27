using System;
using System.Collections.Generic;

namespace JaMPeApp.Models
{
    public partial class Compra
    {
        public Compra()
        {
            ChequeCompras = new HashSet<ChequeCompra>();
            CompraDets = new HashSet<CompraDet>();
            EfectivoCompras = new HashSet<EfectivoCompra>();
            NotaDbs = new HashSet<NotaDb>();
        }

        public int CompraId { get; set; }
        public string? CompraNo { get; set; }
        public DateTime? CompraFecha { get; set; }
        public int? SuplidorId { get; set; }
        public decimal? CompraItbis { get; set; }
        public decimal? CompraDescto { get; set; }
        public int? CondPagoId { get; set; }
        public decimal? CompraBalance { get; set; }
        /// <summary>
        /// Yes = Abierta, No = Cerrada
        /// </summary>
        public bool CompraEstatus { get; set; }
        public float? CompraTasa { get; set; }
        public string? CompraNcf { get; set; }
        public DateTime? CompraFechaRegistrada { get; set; }
        public int? OrdenCompraId { get; set; }
        public int? AlmacenId { get; set; }
        public string? CompraComentario { get; set; }
        public bool? ProveedorInformar { get; set; }

        public virtual ICollection<ChequeCompra> ChequeCompras { get; set; }
        public virtual ICollection<CompraDet> CompraDets { get; set; }
        public virtual ICollection<EfectivoCompra> EfectivoCompras { get; set; }
        public virtual ICollection<NotaDb> NotaDbs { get; set; }
    }
}
