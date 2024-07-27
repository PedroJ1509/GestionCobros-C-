using System;
using System.Collections.Generic;

namespace JaMPeApp.Models
{
    public partial class Articulo
    {
        public Articulo()
        {
            ArticuloAnalisisCostoDets = new HashSet<ArticuloAnalisisCostoDet>();
            ArticuloAnalisisCostos = new HashSet<ArticuloAnalisisCosto>();
            CompraDets = new HashSet<CompraDet>();
        }

        public int ArticuloId { get; set; }
        public string? ArticuloCd { get; set; }
        public string? ArticuloPartNo { get; set; }
        public string? ArticuloDesc { get; set; }
        public int? MarcaId { get; set; }
        public int? ModeloId { get; set; }
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
        public short? ArticuloGanancia2 { get; set; }
        public short? ArticuloGananciaMinima { get; set; }
        public bool ArticuloSiVencimiento { get; set; }
        public bool ArticuloSiComanda { get; set; }
        public byte[]? UpsizeTs { get; set; }
        public string? ArticuloIdArt { get; set; }
        public string? ArticuloImgRuta { get; set; }
        public bool? ArticuloSiFactNegativo { get; set; }
        public bool? ArticuloSiGuarnicion { get; set; }
        public bool? ArticuloSiPeso { get; set; }

        public virtual ICollection<ArticuloAnalisisCostoDet> ArticuloAnalisisCostoDets { get; set; }
        public virtual ICollection<ArticuloAnalisisCosto> ArticuloAnalisisCostos { get; set; }
        public virtual ICollection<CompraDet> CompraDets { get; set; }
    }
}
