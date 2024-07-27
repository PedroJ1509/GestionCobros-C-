using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JaMPeApp.DTOs
{
    public class comprobanteTipoDTO
    {
        public short ComprobanteTipoId { get; set; }
        public string ComprobanteDesc { get; set; }
        public string ComprobanteDondeUsar { get; set; }
        public string ComprobanteTextoInicial { get; set; }
        public bool ComprobanteNoitbis { get; set; }
        public bool? ComprobanteSiFechaVen { get; set; }
        public DateTime? ComprobanteFechaVen { get; set; }
    }
}
