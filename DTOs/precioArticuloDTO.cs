using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JaMPeApp.DTOs
{
    public class precioArticuloDTO
    {
        public int precioId { get; set; }
        public string precioMonto { get; set; }
        public float? precioGanancia { get; set; }
        public float? precioComision { get; set; }
        public string precioCodigo { get; set; }
    }
}
