using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JaMPeApp.DTOs
{
    public class ventasPorMesDTO
    {
        public int ano { get; set; }
        public int mes { get; set; }
        public string anoMes { get; set; }
        public decimal? ventasContado { get; set; }
        public decimal? ventasCredito { get; set; }
    }
}
