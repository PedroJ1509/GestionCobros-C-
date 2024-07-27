using System;
using System.Collections.Generic;

namespace JaMPeApp.Models
{
    public partial class ChequeActivo
    {
        public int ChequeId { get; set; }
        public int ChequeLinAf { get; set; }
        public int? ActivoFijoId { get; set; }
        public decimal? ChequeMontoAf { get; set; }
    }
}
