using System;
using System.Collections.Generic;

namespace JaMPeApp.Models
{
    public partial class TipoHabitacion
    {
        public int TipoHabitacionId { get; set; }
        public string? TipoHabitacionDesc { get; set; }
        public bool TipoHabitacionEstatus { get; set; }
    }
}
