using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JaMPeApp.DTOs
{
    public class reservaHospedajeDTO
    {
        public int ReservaDetId { get; set; }
        public int ReservaHospedajeSec { get; set; }
        public string ReservaHospedajeNombre { get; set; }
        public string ReservaHospedajeIdentificacion { get; set; }
        public string ReservaHospedajeDireccion { get; set; }
        public string ReservaHospedajeTelefonos { get; set; }
        public string ReservaHospedajeEmail { get; set; }
        public string ReservaHospedajeFechaEntrada { get; set; }
        public string ReservaHospedajeFechaSalida { get; set; }
        public string ReservaHospedajeComentario { get; set; }
        public int? NacionalidadId { get; set; }
        public string NacionalidadDesc { get; set; }
        public string ReservaHospedajeSexo { get; set; }
        public string ReservaHospedajeEdad { get; set; }
    }
}
