using System;
using System.Collections.Generic;

namespace JaMPeApp.Models
{
    public partial class ArticuloSugerido
    {
        public int ArticuloSugeridoId { get; set; }
        public int? ArticuloIdPadre { get; set; }
        public int? ArticuloIdHijo { get; set; }
        public float? ArticuloSugeridoCant { get; set; }
    }
}
