using System;
using System.Collections.Generic;

namespace JaMPeApp.Models
{
    public partial class ArticuloUnidadesDTO
    {
        public int unidadId { get; set; }
        public int articuloId { get; set; }
        public string unidadDesc { get; set; }
        public string cantidad { get; set; }
        public string ratio { get; set; }
    }
}
