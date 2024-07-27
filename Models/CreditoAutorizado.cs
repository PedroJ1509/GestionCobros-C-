using System;
using System.Collections.Generic;

namespace JaMPeApp.Models
{
    public partial class CreditoAutorizado
    {
        public int CreditoAutorizadoId { get; set; }
        public DateTime? CreditoAutorizadoFechaHora { get; set; }
        public int? ClienteId { get; set; }
        public int? CondPagoId { get; set; }
        public int? UsuarioId { get; set; }
        /// <summary>
        /// Yes=Libre para usar, No=Usado en una factura
        /// </summary>
        public bool CreditoAutorizadoEstatus { get; set; }
    }
}
