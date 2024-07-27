using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JaMPeApp.DTOs
{
    public class listadoUsuarioDTO
    {
        public int UsuarioId { get; set; }
        public string UsuarioDescId { get; set; }
        public int AutoridadId { get; set; }
        public string AutoridadDesc { get; set; }
        public string UsuarioNombre { get; set; }
        public bool? Activo { get; set; }
    }
}
