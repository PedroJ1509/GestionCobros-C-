using System;
using System.Collections.Generic;

namespace JaMPeApp.Models
{
    public partial class Reserva
    {
        public int ReservaId { get; set; }
        public int? ReservaNo { get; set; }
        public DateTime? ReservaFechaEntrada { get; set; }
        public DateTime? ReservaFechaSalida { get; set; }
        public int? ClienteId { get; set; }
        public int? PlanId { get; set; }
        public int? UsuarioId { get; set; }
        /// <summary>
        /// 0=Sin Usar, 1=En Uso, 2=Usada
        /// </summary>
        public short? ReservaTipo { get; set; }
        public string? ReservaObservaciones { get; set; }
        public int? FacturaId { get; set; }
        public string? ReservaTarjCred { get; set; }
        public string? ReservaFechaExp { get; set; }
    }
}
