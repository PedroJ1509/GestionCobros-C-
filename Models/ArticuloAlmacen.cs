using System;
using System.Collections.Generic;

namespace JaMPeApp.Models
{
    public partial class ArticuloAlmacen
    {
        public int ArticuloId { get; set; }
        public int AlmacenId { get; set; }
        public double? ArticuloAlmacenExistencia { get; set; }
        public double? ArticuloAlmacenCantMaxima { get; set; }
        public double? ArticuloAlmacenCantReOrden { get; set; }
        public string? ArticuloAlmacenUbicacion { get; set; }
    }
}
