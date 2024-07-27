using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JaMPeApp.DTOs
{
    public class tipoHospedajeDTO
    {
        public int TipoHospedajeId { get; set; }
        public string TipoHospedajeDesc { get; set; }
        public int? TipoHospedajeOcupacion { get; set; }
        public bool TipoHospedajeEstatus { get; set; }
    }
}
