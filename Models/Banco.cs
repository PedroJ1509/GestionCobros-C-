using System;
using System.Collections.Generic;

namespace JaMPeApp.Models
{
    public partial class Banco
    {
        public Banco()
        {
            Cheques = new HashSet<Cheque>();
            Conciliacions = new HashSet<Conciliacion>();
            Depositos = new HashSet<Deposito>();
        }

        public int BancoId { get; set; }
        public string? BancoCta { get; set; }
        public string? BancoNombre { get; set; }
        public int? BancoNoCheque { get; set; }
        public decimal? BancoBalance { get; set; }
        public bool BancoEstatus { get; set; }
        public int? CuentaId { get; set; }
        public int? BancoNoTrans { get; set; }

        public virtual Cuentum? Cuenta { get; set; }
        public virtual ICollection<Cheque> Cheques { get; set; }
        public virtual ICollection<Conciliacion> Conciliacions { get; set; }
        public virtual ICollection<Deposito> Depositos { get; set; }
    }
}
