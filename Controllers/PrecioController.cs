using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using JaMPeApp.DTOs;
using JaMPeApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JaMPeApp.Controllers
{
    [ApiController]
    [Authorize(AuthenticationSchemes = CookieAuthenticationDefaults.AuthenticationScheme)]
    public class PrecioController : ControllerBase
    {
        private readonly GestionEmpContext context;

        public PrecioController(GestionEmpContext context)
        {
            this.context = context;
        }

        [HttpGet("Precios")]
        public async Task<List<precioCantidadDTO>> Precios()
        {
            var CantPrecio = await context.Generals.Select(x => x.GeneralCantPrecios).FirstOrDefaultAsync();

            var result = new List<precioCantidadDTO>();

            for (int i = 1; i <= CantPrecio; i++)
            {
                precioCantidadDTO precio = new precioCantidadDTO();
                precio.PrecioId = i;
                precio.PrecioDesc = "Precio" + i.ToString();
                result.Add(precio);
            }

            return result;
        }
    }
}
