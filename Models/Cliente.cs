using System;
using System.Collections.Generic;

namespace JaMPeApp.Models
{
    public partial class Cliente
    {
        public Cliente()
        {
            Prepagos = new HashSet<Prepago>();
        }

        public int ClienteId { get; set; }
        public string? ClienteCodigo { get; set; }
        public string? ClienteNombre { get; set; }
        public string? ClienteDir1 { get; set; }
        public string? ClienteDir2 { get; set; }
        public string? ClienteCedula { get; set; }
        public string? ClienteTel { get; set; }
        public string? ClienteFax { get; set; }
        public string? ClienteEmail { get; set; }
        public int? ClienteDescto { get; set; }
        public decimal? ClienteBalance { get; set; }
        public int? CondPagoId { get; set; }
        public bool ClienteStatus { get; set; }
        public string? ClienteContacto { get; set; }
        public bool ClienteAutCredito { get; set; }
        public decimal? ClienteLimiteCredito { get; set; }
        public int? ClienteTipoId { get; set; }
        public int? VendedorId { get; set; }
        public int? ComprobanteTipoId { get; set; }
        public bool ClienteSiRetieneIsr { get; set; }
        public short? ClientePrecioNo { get; set; }
        public int? ClienteTotalPuntos { get; set; }
        public string? ClienteComentario { get; set; }
        public int? PlanId { get; set; }

        public virtual ClienteTipo? ClienteTipo { get; set; }
        public virtual CondPago? CondPago { get; set; }
        public virtual Vendedor? Vendedor { get; set; }
        public virtual ClienteDatosVehiculo? ClienteDatosVehiculo { get; set; }
        public virtual ICollection<Prepago> Prepagos { get; set; }
    }
}
