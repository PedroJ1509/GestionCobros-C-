using System;
using System.Collections.Generic;

namespace JaMPeApp.Models
{
    public partial class LogErrore
    {
        public int LogId { get; set; }
        public DateTime? LogFecha { get; set; }
        public string? LogPantalla { get; set; }
        public string? LogFuncion { get; set; }
        public string? LogMensaje { get; set; }
        public int? UsuarioId { get; set; }
    }
}
