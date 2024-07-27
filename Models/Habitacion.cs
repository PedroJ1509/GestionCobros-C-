using System;
using System.Collections.Generic;

namespace JaMPeApp.Models
{
    public partial class Habitacion
    {
        public int HabitacionId { get; set; }
        public string? HabitacionDesc { get; set; }
        public int? PlantaId { get; set; }
        public int? TipoHabitacionId { get; set; }
        /// <summary>
        /// 0=Limpia, 1=Sucia
        /// </summary>
        public short? HabitacionEstado { get; set; }
        public bool HabitacionEstatus { get; set; }
    }
}
