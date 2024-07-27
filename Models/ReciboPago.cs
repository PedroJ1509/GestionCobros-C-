using System;
using System.Collections.Generic;

namespace JaMPeApp.Models
{
    public partial class ReciboPago
    {
        public int ReciboId { get; set; }
        public string? ReciboNo { get; set; }
        public DateTime? ReciboFecha { get; set; }
        public decimal? ReciboMonto { get; set; }
        public string? ReciboComentario { get; set; }
        public int? UsuarioId { get; set; }
        public int? CierreCajaId { get; set; }
        public int? VendedorId { get; set; }
    }
}
