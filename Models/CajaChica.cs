using System;
using System.Collections.Generic;

namespace JaMPeApp.Models
{
    public partial class CajaChica
    {
        public CajaChica()
        {
            CajaChicaDets = new HashSet<CajaChicaDet>();
            ChequeCajaChicas = new HashSet<ChequeCajaChica>();
        }

        public int CajaChicaId { get; set; }
        public DateTime? CajaChicaFecha { get; set; }
        public decimal? CajaChicaMonto { get; set; }
        public decimal? CajaChicaBalance { get; set; }
        public bool CajaChicaEstatus { get; set; }

        public virtual ICollection<CajaChicaDet> CajaChicaDets { get; set; }
        public virtual ICollection<ChequeCajaChica> ChequeCajaChicas { get; set; }
    }
}
