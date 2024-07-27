using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JaMPeApp.DTOs
{
    public class reservaDTO
    {
        public int ReservaId { get; set; }
        public int? ReservaNo { get; set; }
        public DateTime? ReservaFechaEntrada { get; set; }
        public DateTime? ReservaFechaSalida { get; set; }
        public int? ClienteId { get; set; }
        public string ClienteNombre { get; set; }
        public int? PlanId { get; set; }
        public string PlanDesc { get; set; }
        public int? UsuarioId { get; set; }
        public short? ReservaTipo { get; set; }
    }
}
