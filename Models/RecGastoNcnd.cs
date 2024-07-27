using System;
using System.Collections.Generic;

namespace JaMPeApp.Models
{
    public partial class RecGastoNcnd
    {
        public int RecGastoNcndId { get; set; }
        public int? RecGastoId { get; set; }
        public string? RecGastoNcndNcf { get; set; }
        public decimal? RecGastoNcndItbis { get; set; }
        public decimal? RecGastoNcndMonto { get; set; }
    }
}
