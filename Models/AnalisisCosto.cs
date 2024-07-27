using System;
using System.Collections.Generic;

namespace JaMPeApp.Models
{
    public partial class AnalisisCosto
    {
        public int AnalisisCostoId { get; set; }
        public int? CotizacionId { get; set; }
        public int? MateriaPrimaCant { get; set; }
        public decimal? MateriaPrimaCosto { get; set; }
        public int? LlenadaCant { get; set; }
        public decimal? LlenadaCosto { get; set; }
        public int? SubidaCant { get; set; }
        public decimal? SubidaCosto { get; set; }
        public int? TranCampoCant { get; set; }
        public decimal? TranCampoCosto { get; set; }
        public int? CocidaCant { get; set; }
        public decimal? CocidaCosto { get; set; }
        public int? SacosCant { get; set; }
        public decimal? SacosCosto { get; set; }
        public int? DescMolinoCant { get; set; }
        public decimal? DescMolinoCosto { get; set; }
        public int? MoliendaCant { get; set; }
        public decimal? MoliendaCosto { get; set; }
        public int? TranDestinoCant { get; set; }
        public decimal? TranDestinoCosto { get; set; }
        public int? DescDestinoCant { get; set; }
        public decimal? DescDestinoCosto { get; set; }
        public decimal? ImpuestoCosto { get; set; }
        public decimal? DietaCosto { get; set; }
        public int? ComisionesCosto { get; set; }
        public int? CantArtiVenta { get; set; }
        public decimal? TotalCosto { get; set; }
        public decimal? CostoUnitario { get; set; }

        public virtual Cotizacion? Cotizacion { get; set; }
    }
}
