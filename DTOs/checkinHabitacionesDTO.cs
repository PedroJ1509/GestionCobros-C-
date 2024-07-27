using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JaMPeApp.DTOs
{
    public class checkinHabitacionesDTO
    {

        public int HabitacionId { get; set; }
        public string HabitacionDesc { get; set; }
        public string TipoHabitacionId { get; set; }
        public string TipoHabitacionDesc { get; set; }
        public string HabitacionEstado { get; set; }
        public string ReservaId { get; set; }
        public string ReservaNo { get; set; }
        public string ReservaTipo { get; set; }
        public string checkout { get; set; }
    }
}
