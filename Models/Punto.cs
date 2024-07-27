using System;
using System.Collections.Generic;

namespace JaMPeApp.Models
{
    public partial class Punto
    {
        public int PuntoId { get; set; }
        public DateTime? PuntoFecha { get; set; }
        public int? FacturaId { get; set; }
        public decimal? PuntoMonto { get; set; }
        public int? UsuarioId { get; set; }
        public decimal? PuntoMontoDisponible { get; set; }
    }
}
