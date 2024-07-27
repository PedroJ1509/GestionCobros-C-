using System;
using System.Collections.Generic;

namespace JaMPeApp.Models
{
    public partial class Oplog
    {
        public int OrdenProduccionId { get; set; }
        public int OpestatusOrden { get; set; }
        public DateTime? OplogFechaHora { get; set; }
    }
}
