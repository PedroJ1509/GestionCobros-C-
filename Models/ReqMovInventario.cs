using System;
using System.Collections.Generic;

namespace JaMPeApp.Models
{
    public partial class ReqMovInventario
    {
        public int MovId { get; set; }
        public DateTime? MovFecha { get; set; }
        public int? ArticuloId { get; set; }
        /// <summary>
        /// 1 =Ent,   2=Sal,   3=Ajuste Positivo,  4=Ajuste Negativo
        /// </summary>
        public short? MovTipo { get; set; }
        public float? MovCantidad { get; set; }
        public decimal? MovPrecio { get; set; }
        public string? MovComentario { get; set; }
        public decimal? MovMontoGp { get; set; }
        public int? AlmacenId { get; set; }
        public int? CuentaId { get; set; }
        public bool MovSiUtilizada { get; set; }
        public byte[]? UpsizeTs { get; set; }
    }
}
