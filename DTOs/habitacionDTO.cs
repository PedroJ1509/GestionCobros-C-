using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JaMPeApp.DTOs
{
    public class habitacionDTO
    {
        public int HabitacionId { get; set; }
        public string HabitacionDesc { get; set; }
        public int? PlantaId { get; set; }
        public string PlantaDesc { get; set; }
        public int? TipoHabitacionId { get; set; }
        public string TipoHabitacionDesc { get; set; }
        public short? HabitacionEstado { get; set; }
        public bool HabitacionEstatus { get; set; }
    }
}
