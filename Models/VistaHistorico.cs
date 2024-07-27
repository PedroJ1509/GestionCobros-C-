using System;
using System.Collections.Generic;

#nullable disable

namespace JaMPeApp.Models
{
    public partial class VistaHistorico
    {
        public decimal? Id { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedAt { get; set; }
        public int Deleted { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public string Genero { get; set; }
        public string EstadoCivil { get; set; }
        public DateTime? FechaNacimiento { get; set; }
        public string NumIdentificacion { get; set; }
        public string Edad { get; set; }
        public string TipoEdad { get; set; }
        public bool? EdadIntermedia { get; set; }
        public string Email { get; set; }
        public string Movil { get; set; }
        public string Telefono { get; set; }
        public string Telefono2 { get; set; }
        public string CodigoAlterno { get; set; }
        public string Comentarios { get; set; }
        public string Ocupacion { get; set; }
        public int? HistoriSistAnterior { get; set; }
    }
}
