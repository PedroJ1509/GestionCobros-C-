using System;
using System.Collections.Generic;

namespace JaMPeApp.Models
{
    public partial class GrupoReportesAutoridad
    {
        public int? GrupoReporteId { get; set; }
        public short? AutoridadId { get; set; }

        public virtual Autoridad? Autoridad { get; set; }
        public virtual GrupoReporte? GrupoReporte { get; set; }
    }
}
