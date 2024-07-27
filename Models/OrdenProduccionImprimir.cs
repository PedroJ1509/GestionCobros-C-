using System;
using System.Collections.Generic;

namespace JaMPeApp.Models
{
    public partial class OrdenProduccionImprimir
    {
        public int OrdenProduccionImprimirId { get; set; }
        public string? Computadora { get; set; }
        public int? OrdenProduccionNo { get; set; }
        public string? ArticuloCd { get; set; }
        public string? ArticuloDesc { get; set; }
        public float? OrdenProduccionCantOrdenada { get; set; }
        public float? OrdenProduccionLargo { get; set; }
        public float? OrdenProduccionAncho { get; set; }
        public float? OrdenProduccionFondo { get; set; }
        public string? ArticuloDesc2 { get; set; }
        public double? Cant { get; set; }
        public double? Medida1 { get; set; }
        public double? Medida2 { get; set; }
        public double? Medida3 { get; set; }
        public DateTime? OrdenProduccionFecha { get; set; }
        public string? ClienteCodigo { get; set; }
        public string? ClienteNombre { get; set; }
        public string? MaterialesPorArticuloDesc { get; set; }
        public double? ArticuloCosto { get; set; }
        public int? GeneralFactorPietaje { get; set; }
        public byte[]? UpsizeTs { get; set; }
    }
}
