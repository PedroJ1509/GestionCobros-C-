using System;
using System.Collections.Generic;

namespace JaMPeApp.Models
{
    public partial class Comprobante
    {
        public short ComprobanteTipoId { get; set; }
        public int? ComprobanteInicial { get; set; }
        public int? ComprobanteFinal { get; set; }
        public int? ComprobanteUltimoUsado { get; set; }

        public virtual ComprobanteTipo ComprobanteTipo { get; set; } = null!;
    }
}
