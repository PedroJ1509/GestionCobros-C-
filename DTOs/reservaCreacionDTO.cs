using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JaMPeApp.DTOs
{
    public class reservaCreacionDTO
    {
        public int ReservaId { get; set; }
        public string ReservaFechaEntrada { get; set; }
        public string ReservaFechaSalida { get; set; }
        public int? ClienteId { get; set; }
        public int? PlanId { get; set; }
        public int? HabitacionId { get; set; }
        public int? TipoHospedajeId { get; set; }
        public decimal? ReservaDetPrecio { get; set; }
        public string ReservaTipo { get; set; }
        public string ReservaDetId { get; set; }
    }
}
