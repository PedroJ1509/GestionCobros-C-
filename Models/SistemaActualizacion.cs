using System;
using System.Collections.Generic;

namespace JaMPeApp.Models
{
    public partial class SistemaActualizacion
    {
        public DateTime? UltimaActualizacionFecha { get; set; }
        public DateTime? UltimaActualizacionFechaScript { get; set; }
        public string? UltimaActualizacionUsuario { get; set; }
        public string? UltimaActualizacionComentario { get; set; }
        public int UltimaActualizacion { get; set; }
    }
}
