using System;
using System.Collections.Generic;

namespace JaMPeApp.Models
{
    public partial class Modelo
    {
        public Modelo()
        {
            MarcaModArts = new HashSet<MarcaModArt>();
        }

        public int ModeloId { get; set; }
        public string? ModeloDesc { get; set; }
        public int? MarcaId { get; set; }

        public virtual ICollection<MarcaModArt> MarcaModArts { get; set; }
    }
}
