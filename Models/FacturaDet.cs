using System;
using System.Collections.Generic;

namespace JaMPeApp.Models
{
    public partial class FacturaDet
    {
        public FacturaDet()
        {
            DespachoFacturas = new HashSet<DespachoFactura>();
        }

        public int? FacturaId { get; set; }
        public int FacturaDetId { get; set; }
        public int? ArticuloId { get; set; }
        public float? FacturaQty { get; set; }
        public decimal? FacturaCosto { get; set; }
        public decimal? FacturaPrecioAnt { get; set; }
        public decimal? FacturaPrecio { get; set; }
        public int? UsuarioId { get; set; }
        public decimal? FacturaItbis { get; set; }
        public string? FacturaComentario { get; set; }
        public float? FacturaQtyDev { get; set; }
        public string? FacturaComentarioMemo { get; set; }
        public int? OrdenProduccionId { get; set; }
        public float? OrdenProduccionQty { get; set; }
        public bool FacturaDetSiComanda { get; set; }
        public int? FacturaDetNo { get; set; }
        public float? FacturaDetCantDesp { get; set; }
        public int? VendedorId { get; set; }
        public float? FacturaDetComision { get; set; }
        public decimal? FacturaDetDescto { get; set; }
        public int? UnidadId { get; set; }
        public int? MeseroId { get; set; }
        public bool? FacturaDetComandaImpresa { get; set; }
        public DateTime? FacturaDetFecha { get; set; }
        public Factura Factura { get; set; }

        public virtual ICollection<DespachoFactura> DespachoFacturas { get; set; }
    }
}
