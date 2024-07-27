using System;
using System.Collections.Generic;

namespace JaMPeApp.Models
{
    public partial class VistaEstadoCxC
    {
        public int FacturaId { get; set; }
        public decimal? FacturaNo { get; set; }
        public DateTime? FacturaFecha { get; set; }
        public string? ClienteNombre { get; set; }
        public string? HabitacionDesc { get; set; }
        public string Condicion { get; set; } = null!;
        public string? FacturaComprobante { get; set; }
        public decimal? FacturaDescto { get; set; }
        public decimal? FacturaItbis { get; set; }
        public decimal? FacturaMontoImpuesto { get; set; }
        public decimal? FacturaBalance { get; set; }
        public decimal Pagado { get; set; }
        public decimal? Pendiente { get; set; }
        public string? UsuarioNombre { get; set; }
        public string? Mesero { get; set; }
        public int? ClienteId { get; set; }
        public int? CondPagoId { get; set; }
        public int? VendedorId { get; set; }
        public short? ComprobanteTipoId { get; set; }
        public int? MesaId { get; set; }
    }
}
