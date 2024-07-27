using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JaMPeApp.DTOs
{
    public class ventasPorArticuloDTO
    {
        public int articuloId { get; set; }
        public string articuloCd { get; set; }
        public string articuloDesc { get; set; }
        public decimal? cantidad { get; set; }
        public decimal porcentaje { get; set; }
    }
}
