using System;
using System.Collections.Generic;

namespace JaMPeApp.Models
{
    public partial class NotaDbCompra
    {
        public int NotaDbCompraId { get; set; }
        public int? NotaDbId { get; set; }
        public int? CompraId { get; set; }
        public decimal? NotaDbCompraMonto { get; set; }
        public DateTime? NotaDbCompraFecha { get; set; }
    }
}
