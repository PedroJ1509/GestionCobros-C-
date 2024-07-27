using System;
using System.Collections.Generic;

namespace JaMPeApp.Models
{
    public partial class RecGastoRecurrente
    {
        public int RecGastoRecurrenteId { get; set; }
        public string? RecGastoRecurrenteNo { get; set; }
        public DateTime? RecGastoRecurrenteFecha { get; set; }
        public int? SuplidorId { get; set; }
        public int? GastoId { get; set; }
        public decimal? RecGastoRecurrenteMonto { get; set; }
        public decimal? RecGastoRecurrenteItbis { get; set; }
        public string? RecGastoRecurrenteComentario { get; set; }
    }
}
