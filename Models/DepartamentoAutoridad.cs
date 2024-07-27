using System;
using System.Collections.Generic;

namespace JaMPeApp.Models
{
    public partial class DepartamentoAutoridad
    {
        public int DepartamentoId { get; set; }
        public short AutoridadId { get; set; }

        public virtual Autoridad Autoridad { get; set; } = null!;
    }
}
