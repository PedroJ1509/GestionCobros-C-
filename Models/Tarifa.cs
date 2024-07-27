using System;
using System.Collections.Generic;

namespace JaMPeApp.Models
{
    public partial class Tarifa
    {
        public int TipoHabitacionId { get; set; }
        public int TipoHospedajeId { get; set; }
        public int PlanId { get; set; }
        public decimal? TarifaPrecio { get; set; }
    }
}
