using System;
using System.Collections.Generic;

namespace JaMPeApp.Models
{
    public partial class Cuentum
    {
        public Cuentum()
        {
            Bancos = new HashSet<Banco>();
            EntradaDiarioDets = new HashSet<EntradaDiarioDet>();
            Gastos = new HashSet<Gasto>();
            TipoPagos = new HashSet<TipoPago>();
        }

        public int CuentaId { get; set; }
        public string? CuentaNo { get; set; }
        public string? CuentaSufijo { get; set; }
        public int? CuentaIdorigen { get; set; }
        public string? CuentaDesc { get; set; }
        /// <summary>
        /// Si es primaria es que no puede ser borrada, pues es obligatoria para los demas modulos
        /// </summary>
        public bool CuentaSiPrimaria { get; set; }

        public virtual ICollection<Banco> Bancos { get; set; }
        public virtual ICollection<EntradaDiarioDet> EntradaDiarioDets { get; set; }
        public virtual ICollection<Gasto> Gastos { get; set; }
        public virtual ICollection<TipoPago> TipoPagos { get; set; }
    }
}
