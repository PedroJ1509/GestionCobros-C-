using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JaMPeApp.DTOs
{
    public class listadoClienteDTO
    {
        public int ClienteID { get; set; }
        public string ClienteCodigo { get; set; }
        public string ClienteNombre { get; set; }
        public string ClienteCedula { get; set; }
        public string ClienteTelefono { get; set; }
        public string ClienteEmail { get; set; }
    }
}
