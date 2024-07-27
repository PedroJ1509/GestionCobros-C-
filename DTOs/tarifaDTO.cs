using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JaMPeApp.DTOs
{
    public class tarifaDTO
    {
        public int TipoHabitacionId { get; set; }
        public string TipoHabitacionDesc { get; set; }
        public int TipoHospedajeId { get; set; }
        public string TipoHospedajeDesc { get; set; }
        public int PlanId { get; set; }
        public string PlanDesc { get; set; }
        public decimal? TarifaPrecio { get; set; }
    }
}
