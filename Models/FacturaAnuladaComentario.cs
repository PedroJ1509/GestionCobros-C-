using System;
using System.Collections.Generic;

namespace JaMPeApp.Models
{
    public partial class FacturaAnuladaComentario
    {
        public int? FacturaId { get; set; }
        public int? UsuarioId { get; set; }
        public string? FacturaComentarioNula { get; set; }
        public DateTime? FacturaFechaNula { get; set; }
    }
}
