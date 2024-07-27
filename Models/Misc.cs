using System;
using System.Collections.Generic;

namespace JaMPeApp.Models
{
    public partial class Misc
    {
        public int MiscId { get; set; }
        public DateTime? MiscFecha { get; set; }
        public int? BancoId { get; set; }
        public decimal? MiscMontoDebito { get; set; }
        public decimal? MiscMontoCredito { get; set; }
        public string? MiscComentario { get; set; }
        public string? MiscConciliacion { get; set; }
        public int? CuentaId { get; set; }
        public string? MiscNcf { get; set; }
        public string? MiscRnc { get; set; }
        public string? MiscClasCode { get; set; }
    }
}
