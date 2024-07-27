using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JaMPeApp.DTOs
{
    public class facturaDetConsultaDTO
    {
        public int facturaId { get; set; }
        public int facturaDetNo { get; set; }
        public string codigo { get; set; }
        public string descripcion { get; set; }
        public string cantidad { get; set; }
        public string unidad { get; set; }
        public string precio { get; set; }
        public string itbis { get; set; }
        public string Importe { get; set; }
    }
}
