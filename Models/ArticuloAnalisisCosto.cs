using System;
using System.Collections.Generic;

namespace JaMPeApp.Models
{
    public partial class ArticuloAnalisisCosto
    {
        public ArticuloAnalisisCosto()
        {
            ArticuloAnalisisCostoDets = new HashSet<ArticuloAnalisisCostoDet>();
        }

        public int ArticuloAnalisisCostoId { get; set; }
        public DateTime? Fecha { get; set; }
        public int? ArticuloId { get; set; }
        public double? TotalCosto { get; set; }
        public double? CostoUnd { get; set; }
        public double? Ganancia { get; set; }
        public bool? Estado { get; set; }
        public int? Cantidad { get; set; }
        public double? TotalCostoExist { get; set; }
        public double? TotalCostoFalt { get; set; }
        public string? LabelInfo1 { get; set; }
        public string? LabelInfo2 { get; set; }

        public virtual Articulo? Articulo { get; set; }
        public virtual ICollection<ArticuloAnalisisCostoDet> ArticuloAnalisisCostoDets { get; set; }
    }
}
