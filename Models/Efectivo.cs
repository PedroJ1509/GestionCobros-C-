using System;
using System.Collections.Generic;

namespace JaMPeApp.Models
{
    public partial class Efectivo
    {
        public Efectivo()
        {
            EfectivoCompras = new HashSet<EfectivoCompra>();
            EfectivoGastos = new HashSet<EfectivoGasto>();
        }

        public int EfectivoId { get; set; }
        public int? EfectivoNo { get; set; }
        public int? CierreCajaId { get; set; }
        public int? SuplidorId { get; set; }
        public DateTime? EfectivoFecha { get; set; }
        public decimal? EfectivoValor { get; set; }
        public bool EfectivoAnulado { get; set; }
        public bool EfectivoPrinted { get; set; }
        public string? EfectivoConcepto { get; set; }
        public int? UsuarioId { get; set; }

        public virtual Suplidor? Suplidor { get; set; }
        public virtual Usuario? Usuario { get; set; }
        public virtual ICollection<EfectivoCompra> EfectivoCompras { get; set; }
        public virtual ICollection<EfectivoGasto> EfectivoGastos { get; set; }
    }
}
