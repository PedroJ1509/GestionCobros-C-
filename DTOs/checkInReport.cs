using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JaMPeApp.DTOs
{
    public class checkInReport
    {
        public string tituloNombreEmpresa { get; set; }
        public int? reservaNo { get; set; }
        public int reservaId { get; set; }
        public int reservaDetId { get; set; }
        public string clienteNombre { get; set; }
        public string HuespedNombre { get; set; }
        public string HuespedDireccion { get; set; }
        public string HuespedTelefono { get; set; }
        public string HuespedEmail { get; set; }
        public string HuespedIdentificacion { get; set; }
        public string HuespedNacionalidad { get; set; }
        public string HuespedFechaEntrada { get; set; }
        public string HuespedFechaSalida { get; set; }
        public string HuespedHabitacion { get; set; }
        public string HuespedTipoHabitacion { get; set; }
        public string HuespedTipoHospedaje { get; set; }
        public string HuespedTarifa { get; set; }
        public List<ListadoHuesped> listadoHuespedes { get; set; }
    }
}
