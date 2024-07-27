using System;
using System.Collections.Generic;

namespace JaMPeApp.Models
{
    public partial class TipoHospedaje
    {
        public int TipoHospedajeId { get; set; }
        public string? TipoHospedajeDesc { get; set; }
        public int? TipoHospedajeOcupacion { get; set; }
        public bool TipoHospedajeEstatus { get; set; }
    }
}
