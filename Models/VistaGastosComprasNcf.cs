using System;
using System.Collections.Generic;

namespace JaMPeApp.Models
{
    public partial class VistaGastosComprasNcf
    {
        public string? SuplidorCedula { get; set; }
        public string? GastoClasCode { get; set; }
        public string? RecGastoNcf { get; set; }
        public DateTime? RecGastoFecha { get; set; }
        public decimal? RecGastoItbis { get; set; }
        public decimal? Monto { get; set; }
        public decimal? RecGastoItbisretenido { get; set; }
        public DateTime? Fecha { get; set; }
        public string? RecGastoNcfNcnd { get; set; }
        public string TipoPago { get; set; } = null!;
    }
}
