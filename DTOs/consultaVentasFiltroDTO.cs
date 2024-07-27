using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JaMPeApp.DTOs
{
    public class consultaVentasFiltroDTO
    {
        public string fechaDesde { get; set; }
        public string fechaHasta { get; set; }
        public string estado { get; set; }
        public string tipoComprobante { get; set; }
        public string clienteId { get; set; }
        public string condicionId { get; set; }
    }
}
