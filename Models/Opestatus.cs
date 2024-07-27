using System;
using System.Collections.Generic;

namespace JaMPeApp.Models
{
    public partial class Opestatus
    {
        public int OpestatusId { get; set; }
        public int? OpestatusOrden { get; set; }
        public string? OpestatusDesc { get; set; }
        public int? OpestatusTipo { get; set; }
    }
}
