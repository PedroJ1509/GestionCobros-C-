using System;
using System.Collections.Generic;

namespace JaMPeApp.Models
{
    public partial class ReciboCompra
    {
        public int? ReciboNo { get; set; }
        public DateTime? ReciboFecha { get; set; }
        public DateTime? FacturaFecha { get; set; }
        public int FacturaId { get; set; }
        public string? FacturaNo { get; set; }
        public decimal? FacturaBalance { get; set; }
        public decimal? Pendiente { get; set; }
        public decimal? ReciboFactPagoMonto { get; set; }
        public int SuplidorId { get; set; }
        public string? ClienteCodigo { get; set; }
        public string? ClienteNombre { get; set; }
        public string? ClienteDir1 { get; set; }
        public string? ClienteTel { get; set; }
        public string? ChequeConcepto { get; set; }
        public decimal? CompraDescto { get; set; }
        public string? SuplidorCedula { get; set; }
        public string? CompraNcf { get; set; }
    }
}
