using System;
using System.Collections.Generic;

namespace JaMPeApp.Models
{
    public partial class Carrocerium
    {
        public int CarroceriaId { get; set; }
        public string? CarroceriaDesc { get; set; }
        public bool? CarroceriaEstatus { get; set; }
        public int? SucursalId { get; set; }
    }
}
