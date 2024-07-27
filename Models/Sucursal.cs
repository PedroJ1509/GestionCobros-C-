using System;
using System.Collections.Generic;

#nullable disable

namespace JaMPeApp.Models
{
    public partial class Sucursal
    {
        public int SucursalId { get; set; }
        public string SucursalDesc { get; set; }
        public bool? SucursalEstatus { get; set; }
        public int? EmpresaId { get; set; }
    }
}
