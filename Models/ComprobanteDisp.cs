using System;
using System.Collections.Generic;

namespace JaMPeApp.Models
{
    public partial class ComprobanteDisp
    {
        public short ComprobanteTipoId { get; set; }
        public string Ncf { get; set; } = null!;

        public virtual ComprobanteTipo ComprobanteTipo { get; set; } = null!;
    }
}
