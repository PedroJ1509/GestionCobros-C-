using System;
using System.Collections.Generic;

namespace JaMPeApp.Models
{
    public partial class VArticulo1
    {
        public int ArticuloId { get; set; }
        public string? ArticuloCd { get; set; }
        public string? ArticuloPartNo { get; set; }
        public string? ArticuloDesc { get; set; }
        public int? MarcaId { get; set; }
        public int? ModeloId { get; set; }
        public string? ArticuloUbicacion { get; set; }
        public double? ArticuloCantMaxima { get; set; }
        public double? ArticuloCantReOrden { get; set; }
        public double? ArticuloExistencia { get; set; }
        public double? ArticuloCosto { get; set; }
        public double? ArticuloCostoProm { get; set; }
        public bool ArticuloStatus { get; set; }
        public int? UnidadId { get; set; }
        public bool ArticuloConvertible { get; set; }
        public bool ArticuloSiItbis { get; set; }
        public int? DepartamentoId { get; set; }
        public bool ArticuloInventario { get; set; }
        public bool ArticuloSiItbisincluido { get; set; }
        public bool ArticuloFabricado { get; set; }
        public string? ArticuloCostoCodigo { get; set; }
        public bool ArticuloSiKit { get; set; }
        public short? ArticuloGananciaMinima { get; set; }
        public short? ArticuloGanancia2 { get; set; }
        public bool ArticuloSiVencimiento { get; set; }
        public string? AlmacenDesc { get; set; }
        public int AlmacenId { get; set; }
    }
}
