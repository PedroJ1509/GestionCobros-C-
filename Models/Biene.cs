using System;
using System.Collections.Generic;

namespace JaMPeApp.Models
{
    public partial class Biene
    {
        public Biene()
        {
            BienesEquipamientos = new HashSet<BienesEquipamiento>();
        }

        public int BienesId { get; set; }
        public string? BienesDesc { get; set; }
        public int? TipoBienesId { get; set; }
        public int? MarcaId { get; set; }
        public int? ModeloId { get; set; }
        public int? ColorId { get; set; }
        public int? CarroceriaId { get; set; }
        public string? Kilometraje { get; set; }
        public int? Ano { get; set; }
        public double? Avaluo { get; set; }
        public string? Cilindrada { get; set; }
        public string? Version { get; set; }
        public int? CombustibleId { get; set; }
        public int? TraccionId { get; set; }
        public bool? BienesEstatus { get; set; }
        public string? NumChasi { get; set; }
        public string? NumMotor { get; set; }
        public string? PolizaSeguro { get; set; }
        public string? BienesImgRuta { get; set; }

        public virtual ICollection<BienesEquipamiento> BienesEquipamientos { get; set; }
    }
}
