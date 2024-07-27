using System;
using System.Collections.Generic;

namespace JaMPeApp.Models
{
    public partial class Producto
    {
        public double? Codigo { get; set; }
        public string? Descripcion { get; set; }
        public double? Precio { get; set; }
        public double? Marcaid { get; set; }
        public double? Inventario { get; set; }
    }
}
