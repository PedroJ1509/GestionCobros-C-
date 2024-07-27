namespace JaMPeApp.DTOs
{
    public class almacenesArticulosDTO
    {
        public int almadenId { get; set; }

        public int articuloId { get; set; }

        public string almadenDesc { get; set; }

        public string? existencia { get; set; }

        public string ubicacion { get; set; }

        public double? cantMaxima { get; set; }

        public double? cantMinima { get; set; }
    }

}
