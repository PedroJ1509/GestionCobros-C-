using System;
using System.Collections.Generic;

#nullable disable

namespace JaMPeApp.Models
{
    public partial class FacturaNulaComentario
    {
        public int? FacturaId { get; set; }
        public int? UsuarioId { get; set; }
        public DateTime? FacturaNulaFecha { get; set; }
        public string FacturaNulaComentario1 { get; set; }
    }
}
