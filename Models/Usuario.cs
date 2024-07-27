using System;
using System.Collections.Generic;

namespace JaMPeApp.Models
{
    public partial class Usuario
    {
        public Usuario()
        {
            AjustInventarios = new HashSet<AjustInventario>();
            CierreCajas = new HashSet<CierreCaja>();
            Conversions = new HashSet<Conversion>();
            Cuota = new HashSet<Cuotum>();
            Efectivos = new HashSet<Efectivo>();
            Facturas = new HashSet<Factura>();
            PrepagoDets = new HashSet<PrepagoDet>();
            UsuarioComputadoras = new HashSet<UsuarioComputadora>();
        }

        public int UsuarioId { get; set; }
        public string? UsuarioDescId { get; set; }
        public string? UsuarioPass { get; set; }
        public short? AutoridadId { get; set; }
        public string? UsuarioNombre { get; set; }
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

        public virtual Autoridad? Autoridad { get; set; }
        public virtual ICollection<AjustInventario> AjustInventarios { get; set; }
        public virtual ICollection<CierreCaja> CierreCajas { get; set; }
        public virtual ICollection<Conversion> Conversions { get; set; }
        public virtual ICollection<Cuotum> Cuota { get; set; }
        public virtual ICollection<Efectivo> Efectivos { get; set; }
        public virtual ICollection<Factura> Facturas { get; set; }
        public virtual ICollection<PrepagoDet> PrepagoDets { get; set; }
        public virtual ICollection<UsuarioComputadora> UsuarioComputadoras { get; set; }
    }
}
