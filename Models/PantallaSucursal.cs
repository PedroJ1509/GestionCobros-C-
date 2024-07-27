using System;
using System.Collections.Generic;

#nullable disable

namespace JaMPeApp.Models
{
    public partial class PantallaSucursal
    {
        public short PantallaId { get; set; }
        public int SucursalId { get; set; }

        public virtual Pantalla Pantalla { get; set; }
        public virtual Sucursal Sucursal { get; set; }
    }
}
