using System;
using System.Collections.Generic;

namespace JaMPeApp.Models
{
    public partial class ArticuloUnidad
    {
        public int ArticuloId { get; set; }
        public int UnidadId { get; set; }
        public float? ArticuloUnidadRatio { get; set; }
    }
}
