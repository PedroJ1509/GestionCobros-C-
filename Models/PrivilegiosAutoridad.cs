using System;
using System.Collections.Generic;

#nullable disable

namespace JaMPeApp.Models
{
    public partial class PrivilegiosAutoridad
    {
        public short AutoridadId { get; set; }
        public short PrivilegiosId { get; set; }

        public virtual Autoridad Autoridad { get; set; }
        public virtual Privilegio Privilegios { get; set; }
    }
}
