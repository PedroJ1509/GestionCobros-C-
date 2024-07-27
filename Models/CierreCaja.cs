using System;
using System.Collections.Generic;

namespace JaMPeApp.Models
{
    public partial class CierreCaja
    {
        public CierreCaja()
        {
            Cuota = new HashSet<Cuotum>();
            DepositoCierreCajas = new HashSet<DepositoCierreCaja>();
        }

        public int CierreCajaId { get; set; }
        public DateTime? CierreCajaFechaHora { get; set; }
        public decimal? CierreCajaMonto { get; set; }
        public int? DepositoId { get; set; }
        public int? UsuarioId { get; set; }
        public decimal? CierreCajaMontoNc { get; set; }
        public decimal? CierreCajaMontoUsado { get; set; }
        public decimal? CierreCajaMontoPrePago { get; set; }
        public decimal? CierreCajaMontoPagoEfectivo { get; set; }
        public DateTime? CierreCajaFechaInicio { get; set; }
        public DateTime? CierreCajaFechaFinal { get; set; }
        public bool? CierreCajaCerrada { get; set; }
        public decimal? CierreCajaSaldoInicial { get; set; }
        public decimal? CierreCajaEfectivoSistema { get; set; }
        public decimal? CierreCajaEfectivoCajero { get; set; }
        public int? UsuarioIdCierre { get; set; }
        public int? UsuarioIdReAbre { get; set; }

        public virtual Usuario? Usuario { get; set; }
        public virtual ICollection<Cuotum> Cuota { get; set; }
        public virtual ICollection<DepositoCierreCaja> DepositoCierreCajas { get; set; }
    }
}
