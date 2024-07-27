using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JaMPeApp.DTOs
{
    public class comprasArticuloDTO
    {
        public string? fecha { get; set; }
        public string suplidor { get; set; }
        public string unidad { get; set; }
        public string cantidad { get; set; }
        public string costo { get; set; }
        public string costoItbis { get; set; }
    }
}
