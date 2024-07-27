using System;
using System.Collections.Generic;

#nullable disable

namespace JaMPeApp.Models
{
    public partial class HistPaciente
    {
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Sexo { get; set; }
        public string EstadoCibil { get; set; }
        public DateTime? FechaNacimiento { get; set; }
        public string Cedula { get; set; }
        public string TipoDocumento { get; set; }
        public string Edad { get; set; }
        public string TipoEdad { get; set; }
        public bool? EdadIntermedia { get; set; }
        public string Correo { get; set; }
        public string Movil { get; set; }
        public string Telefono2 { get; set; }
        public string Telefono3 { get; set; }
        public string CodigoAlterno { get; set; }
        public string Comentario { get; set; }
        public string Ocupacion { get; set; }
        public string HistoriaClinica { get; set; }
    }
}
