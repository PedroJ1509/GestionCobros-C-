using System;
using System.Collections.Generic;

namespace JaMPeApp.Models
{
    public partial class PrepagoDet
    {
        public int PrepagoDetId { get; set; }
        public int? PrepagoId { get; set; }
        public DateTime? PrepagoDetFecha { get; set; }
        public decimal? PrepagoDetMonto { get; set; }
        public decimal? PrepagoDetMontoConsumido { get; set; }
        public int? CierreCajaId { get; set; }
        public int? UsuarioId { get; set; }
        public int? TipoPagoId { get; set; }

        public virtual Prepago? Prepago { get; set; }
        public virtual TipoPago? TipoPago { get; set; }
        public virtual Usuario? Usuario { get; set; }
    }
}
