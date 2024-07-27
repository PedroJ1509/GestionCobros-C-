using System;
using System.Collections.Generic;

#nullable disable

namespace JaMPeApp.Models
{
    public partial class ReservaMigration
    {
        public int ReservaId { get; set; }
        public int ReservaNo { get; set; }
        public DateTime? ReservaFechaEntrada { get; set; }
        public DateTime? ReservaFechaSalida { get; set; }
        public int ClienteId { get; set; }
        public int PlanId { get; set; }
        public int UsuarioId { get; set; }
        public int ReservaTipo { get; set; }
    }
}
