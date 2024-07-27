using System;
using System.Collections.Generic;

namespace JaMPeApp.Models
{
    public partial class ClienteDatosVehiculo
    {
        public int ClienteId { get; set; }
        public string? ClienteDatosVehiculoMarca { get; set; }
        public string? ClienteDatosVehiculoModelo { get; set; }
        public string? ClienteDatosVehiculoAno { get; set; }
        public string? ClienteDatosVehiculoChasis { get; set; }

        public virtual Cliente Cliente { get; set; } = null!;
    }
}
