using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JaMPeApp.DTOs
{
    public class facturaConsultaDTO
    {
        public int facturaId { get; set; }
        public string facturaNo { get; set; }
        public string fecha { get; set; }
        public string hora { get; set; }
        public string cliente { get; set; }
        public string clienteCedula { get; set; }
        public string clienteTelefono { get; set; }
        public string condicionDesc { get; set; }
        public string vendedor { get; set; }
        public string comprobante { get; set; }
        public string comprobanteTipo { get; set; }
        public string comprobanteTipoId { get; set; }
        public bool? comprobanteSiFechaVen { get; set; }
        public string comprobanteFechaValida { get; set; }
        public string subTotal { get; set; }
        public string descuento { get; set; }
        public string itbis { get; set; }
        public string ley { get; set; }
        public string total { get; set; }
        public List<facturaDetConsultaDTO> facturaDet { get; set; }
    }
}
