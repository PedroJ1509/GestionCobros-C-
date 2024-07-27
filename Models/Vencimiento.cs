using System;
using System.Collections.Generic;

namespace JaMPeApp.Models
{
    public partial class Vencimiento
    {
        public int VencimientoId { get; set; }
        public int? ArticuloId { get; set; }
        public DateTime? VencimientoFecha { get; set; }
        public int? VencimientoCantEntrada { get; set; }
        public int? VencimientoCantSalida { get; set; }
        public int? AlmacenId { get; set; }
    }
}
