using System;
using System.Collections.Generic;

namespace JaMPeApp.Models
{
    public partial class OrdenProduccionTempImprimir
    {
        public int OrdenProduccionTempImprimirId { get; set; }
        public string? Computadora { get; set; }
        public int? OrdenProduccionTempNo { get; set; }
        public string? ArticuloCd { get; set; }
        public string? ArticuloDesc { get; set; }
        public float? OrdenProduccionTempCantOrdenada { get; set; }
        public float? OrdenProduccionTempLargo { get; set; }
        public float? OrdenProduccionTempAncho { get; set; }
        public float? OrdenProduccionTempFondo { get; set; }
        public string? ArticuloDesc2 { get; set; }
        public double? Cant { get; set; }
        public double? Medida1 { get; set; }
        public double? Medida2 { get; set; }
        public double? Medida3 { get; set; }
        public DateTime? OrdenProduccionTempFecha { get; set; }
        public string? ClienteCodigo { get; set; }
        public string? ClienteNombre { get; set; }
        public string? MaterialesPorArticuloDesc { get; set; }
        public double? ArticuloCosto { get; set; }
        public int? GeneralFactorPietaje { get; set; }
        public byte[]? UpsizeTs { get; set; }
    }
}
