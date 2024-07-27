using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JaMPeApp.DTOs
{
    public class usuarioDTO
    {
        public int UsuarioId { get; set; }
        public string UsuarioDescId { get; set; }
        public string UsuarioPass { get; set; }
        public short? AutoridadId { get; set; }
        public string UsuarioNombre { get; set; }
        public bool UsuarioSiCajero { get; set; }
        public int? AlmacenId { get; set; }
        public bool UsuarioSiReAbrirCompra { get; set; }
        public bool UsuarioSiAnularFactura { get; set; }
        public bool UsuarioSiReAbrirFactura { get; set; }
        public bool UsuarioSiModCredCliente { get; set; }
        public bool UsuarioSiPreFactura { get; set; }
        public bool UsuarioSiFacCliSob { get; set; }
        public bool UsuarioSiFacFacVen { get; set; }
        public bool? UsuarioSiImpuesto { get; set; }
        public bool? UsuarioSiBorrarFactura { get; set; }
        public int? UsuarioNoCopiaFac { get; set; }
        public bool? Activo { get; set; }
    }
}
