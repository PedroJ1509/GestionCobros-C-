using System;
using System.Collections.Generic;

namespace JaMPeApp.Models
{
    public partial class Sala
    {
        public Sala()
        {
            Mesas = new HashSet<Mesa>();
        }

        public int SalaId { get; set; }
        public string? SalaDesc { get; set; }
        public bool? SalaEstatus { get; set; }
        public int? SucursalId { get; set; }

        public virtual ICollection<Mesa> Mesas { get; set; }
    }
}
