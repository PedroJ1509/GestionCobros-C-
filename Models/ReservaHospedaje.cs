using System;
using System.Collections.Generic;

namespace JaMPeApp.Models
{
    public partial class ReservaHospedaje
    {
        public int ReservaDetId { get; set; }
        public int ReservaHospedajeSec { get; set; }
        public string? ReservaHospedajeNombre { get; set; }
        public string? ReservaHospedajeIdentificacion { get; set; }
        public string? ReservaHospedajeDireccion { get; set; }
        public string? ReservaHospedajeTelefonos { get; set; }
        public string? ReservaHospedajeEmail { get; set; }
        public DateTime? ReservaHospedajeFechaEntrada { get; set; }
        public DateTime? ReservaHospedajeFechaSalida { get; set; }
        public string? ReservaHospedajeComentario { get; set; }
        public int? NacionalidadId { get; set; }
        public string? ReservaHospedajeSexo { get; set; }
        public int? ReservaHospedajeEdad { get; set; }
    }
}
