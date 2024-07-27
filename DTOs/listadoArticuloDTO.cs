namespace JaMPeApp.DTOs
{
    public class listadoArticuloDTO
    {
        public int ArticuloID { get; set; }
        public string ArticuloCodigo { get; set; }
        public string ArticuloDescripcion { get; set; }
        public string ArticuloParteNo { get; set; }
        public string ArticuloUdm { get; set; }
        public string ArticuloUbicacion { get; set; }
        public string? ArticuloExistencia { get; set; }
        public string ArticuloCosto { get; set; }
        public string ArticuloPrecios { get; set; }
        public bool ArticuloEstado { get; set; }
    }
}
