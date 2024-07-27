using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JaMPeApp.DTOs
{
    public class ListaVentasFacturasDTO
    {
        public int facturaId { get; set; }
        public string facturaNo { get; set; }
        public string fecha { get; set; }
        public string cliente { get; set; }
        public string condicionDesc { get; set; }
        public string comprobante { get; set; }
        public string condicionId { get; set; }
        public string descuento { get; set; }
        public string itbis { get; set; }
        public string ley { get; set; }
        public string total { get; set; }
        public bool estado { get; set; }
    }
}
