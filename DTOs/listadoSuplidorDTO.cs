namespace JaMPeApp.DTOs
{
    public class listadoSuplidorDTO
    {
        public int SuplidorId { get; set; }
        public string? SuplidorCd { get; set; }
        public string? SuplidorNombre { get; set; }
        public string? SuplidorDir1 { get; set; }
        public string? SuplidorDir2 { get; set; }
        public string? SuplidorCedula { get; set; }
        public string? SuplidorTel { get; set; }
        public string? SuplidorFax { get; set; }
        public string? SuplidorEmail { get; set; }
        public string? SuplidorContacto { get; set; }
        public string? SuplidorCel { get; set; }
        public decimal? SuplidorBalance { get; set; }
        public int? CondPagoId { get; set; }
        public bool SuplidorStatus { get; set; }
        public bool SuplidorDgii { get; set; }
    }
}
