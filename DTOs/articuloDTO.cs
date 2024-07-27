namespace JaMPeApp.DTOs
{
    public class articuloDTO
    {
        public int ArticuloId { get; set; }

        public string ArticuloCd { get; set; }

        public string ArticuloPartNo { get; set; }

        public string ArticuloDesc { get; set; }

        public int? MarcaId { get; set; }

        public int? ModeloId { get; set; }

        public double? ArticuloCosto { get; set; }

        public string? ArticuloCostoProm { get; set; }

        public bool ArticuloStatus { get; set; }

        public int? UnidadId { get; set; }

        public string UnidadIdAnt { get; set; }

        public bool ArticuloConvertible { get; set; }

        public bool ArticuloSiItbis { get; set; }

        public int? DepartamentoId { get; set; }

        public bool ArticuloInventario { get; set; }

        public bool ArticuloSiItbisincluido { get; set; }

        public bool ArticuloFabricado { get; set; }

        public string ArticuloCostoCodigo { get; set; }

        public bool ArticuloSiKit { get; set; }

        public short? ArticuloGanancia2 { get; set; }

        public short? ArticuloGananciaMinima { get; set; }

        public bool ArticuloSiVencimiento { get; set; }

        public bool ArticuloSiComanda { get; set; }

        public string ArticuloIdArt { get; set; }

        public string ArticuloImgRuta { get; set; }

        public bool? ArticuloSiFactNegativo { get; set; }

        public bool? ArticuloSiGuarnicion { get; set; }

        public bool? ArticuloSiPeso { get; set; }

        public double? ArticuloExistencia { get; set; }
    }
}
