using System;
using System.Collections.Generic;

#nullable disable

namespace JaMPeApp.Models
{
    public partial class PaisEstado
    {
        public string Iso { get; set; }
        public string Pais { get; set; }
        public string IsoNivel1 { get; set; }
        public string Nivel1 { get; set; }
        public string Nivel2 { get; set; }
        public string Nivel3 { get; set; }
        public string Nivel4 { get; set; }
        public string Longitud { get; set; }
        public string Latitud { get; set; }
    }
}
