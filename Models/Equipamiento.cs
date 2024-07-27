using System;
using System.Collections.Generic;

namespace JaMPeApp.Models
{
    public partial class Equipamiento
    {
        public Equipamiento()
        {
            BienesEquipamientos = new HashSet<BienesEquipamiento>();
        }

        public int EquipamientoId { get; set; }
        public string? EquipamientoDesc { get; set; }
        public bool? EquipamientoEstatus { get; set; }
        public int? SucursalId { get; set; }

        public virtual ICollection<BienesEquipamiento> BienesEquipamientos { get; set; }
    }
}
