using System;
using System.Collections.Generic;

namespace JaMPeApp.Models
{
    public partial class ReservaAnulada
    {
        public int ReservaId { get; set; }
        public string? ReservaNulaComentario { get; set; }
        public int? UsuarioId { get; set; }
        public DateTime? ReservaNulaFecha { get; set; }
    }
}
