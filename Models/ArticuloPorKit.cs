using System;
using System.Collections.Generic;

namespace JaMPeApp.Models
{
    public partial class ArticuloPorKit
    {
        public int ArticuloPorKitId { get; set; }
        public int? ArticuloIdPadre { get; set; }
        public int? ArticuloIdHijo { get; set; }
        public float? ArticuloPorKitCant { get; set; }
        public byte[]? UpsizeTs { get; set; }
        public int? UnidadId { get; set; }

        public virtual Unidad? Unidad { get; set; }
    }
}
