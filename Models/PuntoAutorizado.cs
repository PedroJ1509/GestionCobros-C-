using System;
using System.Collections.Generic;

namespace JaMPeApp.Models
{
    public partial class PuntoAutorizado
    {
        public int PuntoAutorizadoId { get; set; }
        public DateTime? PuntoAutorizadoFecha { get; set; }
        public int? ClienteId { get; set; }
        public decimal? PuntoAutorizadoMonto { get; set; }
        public int? UsuarioId { get; set; }
        public decimal? PuntoAutorizadoMontoConsumido { get; set; }
    }
}
