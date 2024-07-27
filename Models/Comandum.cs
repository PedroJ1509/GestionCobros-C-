using System;
using System.Collections.Generic;

namespace JaMPeApp.Models
{
    public partial class Comandum
    {
        public int ComandaId { get; set; }
        public int? FacturaDetId { get; set; }
        public int? ArticuloId { get; set; }
        public int? UsuarioEnviaId { get; set; }
        public DateTime? ComandaFechaEnvio { get; set; }
        public DateTime? ComandaFechaRecive { get; set; }
        public DateTime? ComandaFechaDespacha { get; set; }
        public DateTime? ComandaFechaEntrega { get; set; }
        public int? UsuarioRecibeId { get; set; }
        public int? UsuarioDespachaId { get; set; }
        public int? UsuarioEntregaId { get; set; }
        public int? ComandaEstatus { get; set; }
        public int? UsuarioAnulaId { get; set; }
        public DateTime? ComandaFechaAnulada { get; set; }
        public int? ImpresionComandaId { get; set; }
        public int? ComandaCantidad { get; set; }
    }
}
