using System;
using System.Collections.Generic;

namespace JaMPeApp.Models
{
    public partial class Departamento
    {
        public Departamento()
        {
            ImpresionComanda = new HashSet<ImpresionComanda>();
        }

        public int DepartamentoId { get; set; }
        public string? DepartamentoDesc { get; set; }
        public bool DepartamentoEstatus { get; set; }
        public bool DepartamentoDefecto { get; set; }
        public int? CuentaId { get; set; }
        public int? CuentaIdventa { get; set; }
        public int? CuentaIdcosto { get; set; }
        public string? DepartamentoUbicacion { get; set; }

        public virtual ICollection<ImpresionComanda> ImpresionComanda { get; set; }
    }
}
