using System;
using System.Collections.Generic;

namespace JaMPeApp.Models
{
    public partial class FacturaCombinacione
    {
        public int? FacturaIdBase { get; set; }
        public int? FacturaIdCombinada { get; set; }
        public decimal? FacturaMonto { get; set; }
        public DateTime? FechaFactura { get; set; }
        public DateTime? FechaCombinacion { get; set; }
        public int? UsuarioId { get; set; }
        public string? FacturaNoCombinada { get; set; }
        public int? ClienteId { get; set; }
    }
}
