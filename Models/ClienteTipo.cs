using System;
using System.Collections.Generic;

namespace JaMPeApp.Models
{
    public partial class ClienteTipo
    {
        public ClienteTipo()
        {
            Clientes = new HashSet<Cliente>();
        }

        public int ClienteTipoId { get; set; }
        public string? ClienteTipoDesc { get; set; }

        public virtual ICollection<Cliente> Clientes { get; set; }
    }
}
