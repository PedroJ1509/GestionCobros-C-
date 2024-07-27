using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JaMPeApp.DTOs
{
    public class condPagoDTO
    {
        public int CondPagoId { get; set; }
        public string CondPagoDesc { get; set; }
        public short? CondPagoDias { get; set; }
    }
}
