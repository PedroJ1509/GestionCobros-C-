using System;
using System.Collections.Generic;

namespace JaMPeApp.Models
{
    public partial class ClientePlantilla
    {
        public int? CondPagoId { get; set; }
        public int? ClienteTipoId { get; set; }
        public int? ClientePrecioNo { get; set; }
        public int? PlanId { get; set; }
        public int? ComprobanteTipoId { get; set; }
    }
}
