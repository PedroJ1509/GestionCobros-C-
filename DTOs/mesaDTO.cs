using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JaMPeApp.DTOs
{
    public class mesaDTO
    {
        public int MesaId { get; set; }
        public int? MesaNo { get; set; }
        public string MesaDesc { get; set; }
        public bool? MesaEstatus { get; set; }
        public int? SalaId { get; set; }
        public string SalaDesc { get; set; }
    }
}
