using System;
using System.Collections.Generic;

namespace JaMPeApp.Models
{
    public partial class Cheque
    {
        public Cheque()
        {
            ChequeCajaChicas = new HashSet<ChequeCajaChica>();
            ChequeCompras = new HashSet<ChequeCompra>();
            ChequeGastos = new HashSet<ChequeGasto>();
            ChequeItbis = new HashSet<ChequeItbi>();
            ChequePrestamos = new HashSet<ChequePrestamo>();
        }

        public int ChequeId { get; set; }
        public int? ChequeNo { get; set; }
        public int? BancoId { get; set; }
        public int? SuplidorId { get; set; }
        public DateTime? ChequeFecha { get; set; }
        public decimal? ChequeValor { get; set; }
        public bool ChequeAnulado { get; set; }
        public bool ChequePrinted { get; set; }
        public string? ChequeConciliacion { get; set; }
        public string? ChequeConcepto { get; set; }
        public string? ChequeBeneficiario { get; set; }

        public virtual Banco? Banco { get; set; }
        public virtual Suplidor? Suplidor { get; set; }
        public virtual ICollection<ChequeCajaChica> ChequeCajaChicas { get; set; }
        public virtual ICollection<ChequeCompra> ChequeCompras { get; set; }
        public virtual ICollection<ChequeGasto> ChequeGastos { get; set; }
        public virtual ICollection<ChequeItbi> ChequeItbis { get; set; }
        public virtual ICollection<ChequePrestamo> ChequePrestamos { get; set; }
    }
}
