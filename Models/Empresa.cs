using System;
using System.Collections.Generic;

#nullable disable

namespace JaMPeApp.Models
{
    public partial class Empresa
    {
        public int EmpresaId { get; set; }
        public string EmpresaDesc { get; set; }
        public bool? EmpresaEstatus { get; set; }
    }
}
