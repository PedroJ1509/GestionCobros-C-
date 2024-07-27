using System;
using System.Collections.Generic;

namespace JaMPeApp.Models
{
    public partial class TipoBiene
    {
        public int TipoBienesId { get; set; }
        public string? TipoBienesDesc { get; set; }
        public bool? TipoBienesEstatus { get; set; }
        public int? SucursalId { get; set; }
    }
}
