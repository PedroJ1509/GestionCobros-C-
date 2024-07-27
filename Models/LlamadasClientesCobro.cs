using System;
using System.Collections.Generic;

namespace JaMPeApp.Models
{
    public partial class LlamadasClientesCobro
    {
        public int LlamadasClienteId { get; set; }
        public DateTime? LlamadasClienteFecha { get; set; }
        public string? LlamadasClienteComentario { get; set; }
        public int? LlamadasAgendaId { get; set; }
        public int? UsuarioId { get; set; }
    }
}
