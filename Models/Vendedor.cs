using System;
using System.Collections.Generic;

namespace JaMPeApp.Models
{
    public partial class Vendedor
    {
        public Vendedor()
        {
            Clientes = new HashSet<Cliente>();
            Cuota = new HashSet<Cuotum>();
            MarcaVendedors = new HashSet<MarcaVendedor>();
        }

        public int VendedorId { get; set; }
        public string? VendedorNombre { get; set; }
        public bool VendedorEstatus { get; set; }
        public string? VendedorCodigo { get; set; }

        public virtual ICollection<Cliente> Clientes { get; set; }
        public virtual ICollection<Cuotum> Cuota { get; set; }
        public virtual ICollection<MarcaVendedor> MarcaVendedors { get; set; }
    }
}
