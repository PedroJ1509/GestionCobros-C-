using System;
using System.Collections.Generic;

namespace JaMPeApp.Models
{
    public partial class Mesero
    {
        public int MeseroId { get; set; }
        public string? MeseroNombre { get; set; }
        public bool? MeseroEstatus { get; set; }
        public string? MeseroCodigo { get; set; }
    }
}
