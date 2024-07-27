using System;
using System.Collections.Generic;

namespace JaMPeApp.Models
{
    public partial class Deposito
    {
        public Deposito()
        {
            DepositoCierreCajas = new HashSet<DepositoCierreCaja>();
        }

        public int DepositoId { get; set; }
        public int? DepositoNo { get; set; }
        public int? BancoId { get; set; }
        public DateTime? DepositoFecha { get; set; }
        public decimal? DepositoMonto { get; set; }
        public string? DepositoComentario { get; set; }
        public string? DepositoConciliacion { get; set; }

        public virtual Banco? Banco { get; set; }
        public virtual ICollection<DepositoCierreCaja> DepositoCierreCajas { get; set; }
    }
}
