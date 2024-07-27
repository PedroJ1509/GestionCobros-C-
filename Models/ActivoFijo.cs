using System;
using System.Collections.Generic;

namespace JaMPeApp.Models
{
    public partial class ActivoFijo
    {
        public int ActivoFijoId { get; set; }
        public int? TipoActivoFijoId { get; set; }
        public string? ActivoFijoDesc { get; set; }
        /// <summary>
        /// Valor del Activo Fijo
        /// </summary>
        public decimal? ActivoFijoValor { get; set; }
        /// <summary>
        /// Fecha de Adquisicion
        /// </summary>
        public DateTime? ActivoFijoFecha { get; set; }
        /// <summary>
        /// % de depreciacion anual
        /// </summary>
        public short? ActivoFijoDepreciacionAnual { get; set; }
        /// <summary>
        /// Monto Depreciado
        /// </summary>
        public decimal? ActivoFijoDepreciacionBalance { get; set; }
        /// <summary>
        /// 1=Activo, 0=Inactivo
        /// </summary>
        public bool ActivoFijoEstatus { get; set; }
        /// <summary>
        /// Yes= tiene cheque No= No TIene Cheque
        /// </summary>
        public bool ActivoFijoSiCheque { get; set; }
        public int? SuplidorId { get; set; }
        public decimal? ActivoFijoItbis { get; set; }
        public decimal? ActivoFijoBalance { get; set; }
        public string? ActivoFijoNcf { get; set; }

        public virtual Suplidor? Suplidor { get; set; }
        public virtual TipoActivoFijo? TipoActivoFijo { get; set; }
    }
}
