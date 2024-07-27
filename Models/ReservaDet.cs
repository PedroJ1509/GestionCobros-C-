using System;
using System.Collections.Generic;

namespace JaMPeApp.Models
{
    public partial class ReservaDet
    {
        public int ReservaDetId { get; set; }
        public int? ReservaId { get; set; }
        public int? HabitacionId { get; set; }
        public int? TipoHospedajeId { get; set; }
        public decimal? ReservaDetPrecio { get; set; }
        public int? ReservaDetStatus { get; set; }
        public bool? ReservaDetSiCortesia { get; set; }
        public int? UsuarioIdCortesia { get; set; }
    }
}
