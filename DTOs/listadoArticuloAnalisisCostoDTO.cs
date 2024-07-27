namespace JaMPeApp.DTOs
{
    public class listadoArticuloAnalisisCostoDTO
    {
        public int ArticuloAnalisisCostoId { get; set; }
        public string Fecha { get; set; }
        public int? ArticuloId { get; set; }
        public string CodigoDesc { get; set; }
        public string TotalCosto { get; set; }
        public string CostoUnidad { get; set; }
        public string Ganancia { get; set; }
        public string Precio { get; set; }
        public bool? EstadoCerrada { get; set; }
        public string CantidadTotal { get; set; }
    }
}
