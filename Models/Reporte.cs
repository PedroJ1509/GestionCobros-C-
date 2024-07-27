using System;
using System.Collections.Generic;

namespace JaMPeApp.Models
{
    public partial class Reporte
    {
        public string ReporteNombre { get; set; } = null!;
        public string? ReporteDesc { get; set; }
        public int? GrupoReporteId { get; set; }
        public string? ReporteModulo { get; set; }
    }
}
