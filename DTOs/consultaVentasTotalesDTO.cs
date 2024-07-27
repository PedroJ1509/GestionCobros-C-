using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JaMPeApp.DTOs
{
    public class consultaVentasTotalesDTO
    {
        public decimal totalDescuento { get; set; }
        public decimal totalItbis { get; set; }
        public decimal totalLey { get; set; }
        public decimal totalGeneral { get; set; }
    }
}
