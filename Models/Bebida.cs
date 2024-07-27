using System;
using System.Collections.Generic;

#nullable disable

namespace JaMPeApp.Models
{
    public partial class Bebida
    {
        public string Descripcion { get; set; }
        public double? Precio { get; set; }
        public string Depart { get; set; }
        public int? Coddepart { get; set; }
        public string Codart { get; set; }
    }
}
