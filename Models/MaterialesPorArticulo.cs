using System;
using System.Collections.Generic;

namespace JaMPeApp.Models
{
    public partial class MaterialesPorArticulo
    {
        public int MaterialesPorArticuloId { get; set; }
        public int? ArticuloIdPadre { get; set; }
        public int? ArticuloIdHijo { get; set; }
        public string? MaterialesPorArticuloDesc { get; set; }
        public string? MaterialesPorArticuloFormulaCant { get; set; }
        public string? MaterialesPorArticuloFormulaMedida1 { get; set; }
        public string? MaterialesPorArticuloFormulaMedida2 { get; set; }
        public string? MaterialesPorArticuloFormulaMedida3 { get; set; }
        public int? UnidadId { get; set; }
        public int? OpestatusId { get; set; }
    }
}
