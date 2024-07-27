using System;
using System.Collections.Generic;

namespace JaMPeApp.Models
{
    public partial class Conversion
    {
        public Conversion()
        {
            ConversionDetalles = new HashSet<ConversionDetalle>();
        }

        public int ConversionId { get; set; }
        public int? ArticuloId { get; set; }
        public int? ConversionCant { get; set; }
        public int? UsuarioId { get; set; }

        public virtual Usuario? Usuario { get; set; }
        public virtual ICollection<ConversionDetalle> ConversionDetalles { get; set; }
    }
}
