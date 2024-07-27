using System;
using System.Collections.Generic;

namespace JaMPeApp.Models
{
    public partial class EntradaDiario
    {
        public EntradaDiario()
        {
            EntradaDiarioDets = new HashSet<EntradaDiarioDet>();
        }

        public int EntradaDiarioId { get; set; }
        public int? EntradaDiarioNo { get; set; }
        public DateTime? EntradaDiarioFecha { get; set; }
        public string? EntradaDiarioComentario { get; set; }
        public bool EntradaDiarioSiPosteada { get; set; }
        public bool EntradaDiarioSiAuto { get; set; }

        public virtual ICollection<EntradaDiarioDet> EntradaDiarioDets { get; set; }
    }
}
