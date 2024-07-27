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
    public class ComprobanteTipoController : ControllerBase
    {
        private readonly GestionEmpContext context;

        public ComprobanteTipoController(GestionEmpContext context)
        {
            this.context = context;
        }

        [HttpGet("ComprobanteTipo")]
        public async Task<List<comprobanteTipoDTO>> TipoClientes()
        {
            var result = new List<comprobanteTipoDTO>();

            var query = (
                from data in context.ComprobanteTipos.Where(x => x.ComprobanteDondeUsar == "F")
                select new comprobanteTipoDTO
                {
                    ComprobanteTipoId = data.ComprobanteTipoId,
                    ComprobanteDesc = String.IsNullOrEmpty(data.ComprobanteDesc) ? "" : data.ComprobanteDesc,
                    ComprobanteDondeUsar = data.ComprobanteDondeUsar,
                    ComprobanteTextoInicial = data.ComprobanteTextoInicial,
                    ComprobanteNoitbis = data.ComprobanteNoitbis,
                    ComprobanteSiFechaVen = data.ComprobanteSiFechaVen,
                    ComprobanteFechaVen = data.ComprobanteFechaVen
                }
            );
            result = await query.OrderBy(x => x.ComprobanteTipoId).ToListAsync();

            return result;
        }
        [HttpGet("ComprobanteFactura")]
        public async Task<List<comprobanteTipoDTO>> ComprobanteFactura()
        {
            var result = new List<comprobanteTipoDTO>();

            var query = (
                from data in context.ComprobanteTipos.Where(x => x.ComprobanteDondeUsar == "F")
                select new comprobanteTipoDTO
                {
                    ComprobanteTipoId = data.ComprobanteTipoId,
                    ComprobanteDesc = String.IsNullOrEmpty(data.ComprobanteDesc) ? "" : data.ComprobanteDesc,
                    ComprobanteDondeUsar = data.ComprobanteDondeUsar,
                    ComprobanteTextoInicial = data.ComprobanteTextoInicial,
                    ComprobanteNoitbis = data.ComprobanteNoitbis,
                    ComprobanteSiFechaVen = data.ComprobanteSiFechaVen,
                    ComprobanteFechaVen = data.ComprobanteFechaVen
                }
            );
            result = await query.OrderBy(x => x.ComprobanteTipoId).ToListAsync();

            return result;
        }
    }
}
