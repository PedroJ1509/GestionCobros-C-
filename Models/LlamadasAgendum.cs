using System;
using System.Collections.Generic;

namespace JaMPeApp.Models
{
    public partial class LlamadasAgendum
    {
        public int LlamadasAgendaId { get; set; }
        public DateTime? LlamadasAgendaFecha { get; set; }
        public int? LlamadasAgendaEstatus { get; set; }
        public int? LlamadasMotivosId { get; set; }
        public int? ClienteId { get; set; }
        public string? LlamadasAgendaComentario { get; set; }
        public int? UsuarioId { get; set; }
    }
}
