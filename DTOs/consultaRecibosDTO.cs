using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JaMPeApp.DTOs
{
    public class consultaRecibosDTO
    {
        public int reciboId { get; set; }
        public string fecha { get; set; }
        public string totalEfectivo { get; set; }
        public string totalTarjeta { get; set; }
        public string total { get; set; }
    }
}
