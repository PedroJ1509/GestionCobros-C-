using System;
using System.Collections.Generic;

namespace JaMPeApp.Models
{
    public partial class UsuarioComputadora
    {
        public string ComputadoraId { get; set; } = null!;
        public int? UsuarioId { get; set; }

        public virtual Usuario? Usuario { get; set; }
    }
}
