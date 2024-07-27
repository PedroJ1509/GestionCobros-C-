using System;
using System.Collections.Generic;

namespace JaMPeApp.Models
{
    public partial class Suplidor
    {
        public Suplidor()
        {
            ActivoFijos = new HashSet<ActivoFijo>();
            Cheques = new HashSet<Cheque>();
            Efectivos = new HashSet<Efectivo>();
            OrdenCompras = new HashSet<OrdenCompra>();
            SuplidorArticulos = new HashSet<SuplidorArticulo>();
        }

        public int SuplidorId { get; set; }
        public string? SuplidorCd { get; set; }
        public string? SuplidorNombre { get; set; }
        public string? SuplidorDir1 { get; set; }
        public string? SuplidorDir2 { get; set; }
        public string? SuplidorCedula { get; set; }
        public string? SuplidorTel { get; set; }
        public string? SuplidorFax { get; set; }
        public string? SuplidorEmail { get; set; }
        public string? SuplidorContacto { get; set; }
        public string? SuplidorCel { get; set; }
        public decimal? SuplidorBalance { get; set; }
        public int? CondPagoId { get; set; }
        public bool SuplidorStatus { get; set; }
        public bool SuplidorDgii { get; set; }

        public virtual ICollection<ActivoFijo> ActivoFijos { get; set; }
        public virtual ICollection<Cheque> Cheques { get; set; }
        public virtual ICollection<Efectivo> Efectivos { get; set; }
        public virtual ICollection<OrdenCompra> OrdenCompras { get; set; }
        public virtual ICollection<SuplidorArticulo> SuplidorArticulos { get; set; }
    }
}
