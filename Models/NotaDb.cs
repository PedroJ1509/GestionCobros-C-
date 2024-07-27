using System;
using System.Collections.Generic;

namespace JaMPeApp.Models
{
    public partial class NotaDb
    {
        public NotaDb()
        {
            NotaDbDets = new HashSet<NotaDbDet>();
        }

        public int NotaDbId { get; set; }
        public string? NotaDbNo { get; set; }
        public DateTime? NotaDbFecha { get; set; }
        public int? CompraId { get; set; }
        public decimal? NotaDbMonto { get; set; }
        public decimal? NotaDbDescto { get; set; }
        public decimal? NotaDbItbis { get; set; }
        public string? NotaDbComentario { get; set; }
        public decimal? NotaDbMontoUsado { get; set; }
        public string? NotaDbComprobante { get; set; }

        public virtual Compra? Compra { get; set; }
        public virtual ICollection<NotaDbDet> NotaDbDets { get; set; }
    }
}
