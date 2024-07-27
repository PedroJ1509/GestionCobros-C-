using System;
using System.Collections.Generic;

namespace JaMPeApp.Models
{
    public partial class FacturaDatosVehiculo
    {
        public int FacturaId { get; set; }
        public string? FacturaDatosVehiculoMarca { get; set; }
        public string? FacturaDatosVehiculoModelo { get; set; }
        public string? FacturaDatosVehiculoAno { get; set; }
        public string? FacturaDatosVehiculoChasis { get; set; }
        public int? FacturaDatosVehiculoKilometraje { get; set; }

        public virtual Factura Factura { get; set; } = null!;
    }
}
