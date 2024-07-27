using System;
using System.Collections.Generic;

namespace JaMPeApp.Models
{
    public partial class Prestamo
    {
        public Prestamo()
        {
            ChequePrestamos = new HashSet<ChequePrestamo>();
            CuotaDets = new HashSet<CuotaDet>();
        }

        public int PrestamoId { get; set; }
        public int? ClienteId { get; set; }
        public DateTime? PrestamoFecha { get; set; }
        /// <summary>
        /// 1=Amortizado, 2=No Amortizado, 3=Lineal Mensual
        /// </summary>
        public short? PrestamoTipo { get; set; }
        public decimal? PrestamoMonto { get; set; }
        public float? PrestamoTasaAnual { get; set; }
        public int? PrestamoDuracion { get; set; }
        /// <summary>
        /// 1=Diario, 2=Semanal, 3=Bisemanal, 4=Quincenal, 5=Mensual
        /// </summary>
        public short? PrestamoTipoPeriodo { get; set; }
        public decimal? PrestamoMontoCuota { get; set; }
        public decimal? PrestamoBalance { get; set; }
        public decimal? PrestamoInteresesPendientes { get; set; }
        public decimal? PrestamoCapitalPendiente { get; set; }
        public DateTime? PrestamoFechaUltimoPago { get; set; }
        public bool PrestamoSiPagado { get; set; }
        public bool PrestamoEstatus { get; set; }
        public byte[]? UpsizeTs { get; set; }

        public virtual ICollection<ChequePrestamo> ChequePrestamos { get; set; }
        public virtual ICollection<CuotaDet> CuotaDets { get; set; }
    }
}
