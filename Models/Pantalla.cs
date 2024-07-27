using System;
using System.Collections.Generic;

namespace JaMPeApp.Models
{
    public partial class Pantalla
    {
        public Pantalla()
        {
            Autoridads = new HashSet<Autoridad>();
        }

        public short PantallaId { get; set; }
        public string? PantallaDesc { get; set; }
        public string? PantallaNombre { get; set; }
        public string? PantallaTipo { get; set; }
        public string? PantallaLinkWeb { get; set; }
        public bool? PantallaSoloEscritorio { get; set; }
        public string? PantallaGrupo { get; set; }

        public virtual ICollection<Autoridad> Autoridads { get; set; }
    }
}
