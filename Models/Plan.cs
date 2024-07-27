using System;
using System.Collections.Generic;

namespace JaMPeApp.Models
{
    public partial class Plan
    {
        public int PlanId { get; set; }
        public string? PlanDesc { get; set; }
        public bool PlanEstatus { get; set; }
    }
}
