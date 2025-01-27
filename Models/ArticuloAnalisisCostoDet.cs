using System;
using System.Collections.Generic;

namespace JaMPeApp.Models
{
    public partial class ArticuloAnalisisCostoDet
    {
        public int ArticuloAnalisisCostoDetId { get; set; }
        public int? ArticuloAnalisisCostoId { get; set; }
        public int? ArticuloId { get; set; }
        public int? UnidadId { get; set; }
        public double? CantXservicio { get; set; }
        public double? CostoXservicio { get; set; }
        public double? CantSolic { get; set; }
        public double? CostoSolic { get; set; }
        public double? Existencia { get; set; }
        //public double? CostoExistecia { get; set; }
        public double? Faltante { get; set; }
        public double? CostoFalt { get; set; }
        public bool? SiPedido { get; set; }

        public virtual Articulo? Articulo { get; set; }
        public virtual ArticuloAnalisisCosto? ArticuloAnalisisCosto { get; set; }
        public virtual Unidad? Unidad { get; set; }
    }
}
