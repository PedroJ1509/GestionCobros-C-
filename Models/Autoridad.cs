using System;
using System.Collections.Generic;

namespace JaMPeApp.Models
{
    public partial class Autoridad
    {
        public Autoridad()
        {
            DepartamentoAutoridads = new HashSet<DepartamentoAutoridad>();
            Usuarios = new HashSet<Usuario>();
            Privilegios = new HashSet<Privilegio>();
        }

        public short AutoridadId { get; set; }
        public string? AutoridadDesc { get; set; }
        public short PantallaId { get; set; }

        public virtual Pantalla Pantalla { get; set; } = null!;
        public virtual ICollection<DepartamentoAutoridad> DepartamentoAutoridads { get; set; }
        public virtual ICollection<Usuario> Usuarios { get; set; }

        public virtual ICollection<Privilegio> Privilegios { get; set; }
    }
}
