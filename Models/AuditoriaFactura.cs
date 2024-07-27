using System;
using System.Collections.Generic;

namespace JaMPeApp.Models
{
    public partial class AuditoriaFactura
    {
        public int Secuencia { get; set; }
        public DateTime? FechaCambio { get; set; }
        public int? UsuarioCambio { get; set; }
        public string? PcCambio { get; set; }
        public string? ProgramaCambio { get; set; }
        public int? FacturaId { get; set; }
        public string? FacturaNo { get; set; }
        public DateTime? FacturaFecha { get; set; }
        public int? CondPagoId { get; set; }
        public int? ClienteId { get; set; }
        public int? VendedorId { get; set; }
        public decimal? FacturaDescto { get; set; }
        public decimal? FacturaItbis { get; set; }
        public decimal? FacturaBalance { get; set; }
        public bool? FacturaEstatus { get; set; }
        public int? CreditoAutorizadoId { get; set; }
        public string? FacturaCliente { get; set; }
        public string? FacturaDatos { get; set; }
        public bool? FacturaSiBeneficio { get; set; }
        public int? FacturaNoImpreso { get; set; }
        public string? FacturaComentario { get; set; }
        public string? FacturaComprobante { get; set; }
        public short? ComprobanteTipoId { get; set; }
        public decimal? FacturaMontoImpuesto { get; set; }
        public int? UsuarioIdAnulador { get; set; }
        public decimal? FacturaMontoRetIsr { get; set; }
        public int? AlmacenId { get; set; }
        public bool? FacturaSiCobrable { get; set; }
        public int? HabitacionId { get; set; }
        public int? ReservaId { get; set; }
        public string? FacturaNif { get; set; }
        public DateTime? FacturaFechaEntrega { get; set; }
        public int? FacturaNoImpresoPreFac { get; set; }
        public decimal? FacturaMontoPagado { get; set; }
        public decimal? FacturaMontoCambio { get; set; }
        public DateTime? FacturaComprobanteFechaVen { get; set; }
        public DateTime? FacturaFechaCierre { get; set; }
        public int? FacturaUsuarioReAbre { get; set; }
        public int? FacturaUsuarioCierra { get; set; }
        public DateTime? FacturaFechaReAbre { get; set; }
        public int? UsuarioId { get; set; }
        public int? MesaId { get; set; }
    }
}
