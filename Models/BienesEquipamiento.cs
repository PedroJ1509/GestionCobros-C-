using System;
using System.Collections.Generic;

namespace JaMPeApp.Models
{
    public partial class BienesEquipamiento
    {
        public int EquipamientoId { get; set; }
        public int BienesId { get; set; }
        public int? EquipamentoCantidad { get; set; }

        public virtual Biene Bienes { get; set; } = null!;
        public virtual Equipamiento Equipamiento { get; set; } = null!;
    }
}
