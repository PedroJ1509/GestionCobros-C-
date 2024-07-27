using System;
using System.Collections.Generic;

namespace JaMPeApp.Models
{
    public partial class Cuotum
    {
        public Cuotum()
        {
            CuotaDets = new HashSet<CuotaDet>();
            CuotaTipoPagos = new HashSet<CuotaTipoPago>();
        }

        public int CuotaId { get; set; }
        public string? CuotaNo { get; set; }
        public DateTime? CuotaFecha { get; set; }
        public decimal? CuotaMonto { get; set; }
        public string? CuotaComentario { get; set; }
        public int? UsuarioId { get; set; }
        public int? CierreCajaId { get; set; }
        public int? VendedorId { get; set; }

        public virtual CierreCaja? CierreCaja { get; set; }
        public virtual Usuario? Usuario { get; set; }
        public virtual Vendedor? Vendedor { get; set; }
        public virtual ICollection<CuotaDet> CuotaDets { get; set; }
        public virtual ICollection<CuotaTipoPago> CuotaTipoPagos { get; set; }
    }
}
