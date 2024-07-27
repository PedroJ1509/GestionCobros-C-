using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace JaMPeApp.DTOs
{
    public class clienteDTO
    {
        [Required]
        public int ClienteId { get; set; }
        public string ClienteCodigo { get; set; }
        [Required]
        public string ClienteNombre { get; set; }
        public string ClienteDir1 { get; set; }
        public string ClienteDir2 { get; set; }
        [Required]
        public string ClienteCedula { get; set; }
        public string ClienteTel { get; set; }
        public string ClienteFax { get; set; }
        public string ClienteEmail { get; set; }
        public int? ClienteDescto { get; set; }
        public decimal? ClienteBalance { get; set; }
        [Required]
        public int? CondPagoId { get; set; }
        public bool ClienteStatus { get; set; }
        public string ClienteContacto { get; set; }
        public bool ClienteAutCredito { get; set; }
        public decimal? ClienteLimiteCredito { get; set; }
        [Required]
        public int? ClienteTipoId { get; set; }
        [Required]
        public int? VendedorId { get; set; }
        public int? ComprobanteTipoId { get; set; }
        public bool ClienteSiRetieneIsr { get; set; }
        public short? ClientePrecioNo { get; set; }
        public int? ClienteTotalPuntos { get; set; }
        public string ClienteComentario { get; set; }
        public int? PlanId { get; set; }
    }
}
