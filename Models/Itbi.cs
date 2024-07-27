using System;
using System.Collections.Generic;

namespace JaMPeApp.Models
{
    public partial class Itbi
    {
        public Itbi()
        {
            ChequeItbis = new HashSet<ChequeItbi>();
        }

        public int ItbisId { get; set; }
        public short? ItbisAno { get; set; }
        public short? ItbisMes { get; set; }
        public decimal? ItbisMonto { get; set; }
        /// <summary>
        /// Yes = Sin Cheque, No = Pagado con cheque
        /// </summary>
        public bool ItbisEstatus { get; set; }

        public virtual ICollection<ChequeItbi> ChequeItbis { get; set; }
    }
}
