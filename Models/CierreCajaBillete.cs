using System;
using System.Collections.Generic;

namespace JaMPeApp.Models
{
    public partial class CierreCajaBillete
    {
        public string? BilleteId { get; set; }
        public int? Cantidad { get; set; }
        public int? CierreCajaId { get; set; }

        public virtual Billete? Billete { get; set; }
        public virtual CierreCaja? CierreCaja { get; set; }
    }
}
