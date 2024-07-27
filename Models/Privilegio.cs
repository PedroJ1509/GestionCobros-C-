using System;
using System.Collections.Generic;

namespace JaMPeApp.Models
{
    public partial class Privilegio
    {
        public Privilegio()
        {
            Autoridads = new HashSet<Autoridad>();
        }

        public short PrivilegiosId { get; set; }
        public string? PrivilegiosDesc { get; set; }
        public bool? PrivilegiosEstatus { get; set; }

        public virtual ICollection<Autoridad> Autoridads { get; set; }
    }
}
