using System;
using System.Collections.Generic;

namespace JaMPeApp.Models
{
    public partial class Combustible
    {
        public int CombustibleId { get; set; }
        public string? CombustibleDesc { get; set; }
        public bool? CombustibleEstatus { get; set; }
        public int? SucursalId { get; set; }
    }
}
