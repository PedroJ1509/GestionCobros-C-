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
    public class CondPagoController : ControllerBase
    {
        private readonly GestionEmpContext context;

        public CondPagoController(GestionEmpContext context)
        {
            this.context = context;
        }

        [HttpGet("CondicionesPago")]
        public async Task<List<condPagoDTO>> CondicionesPago()
        {
            var result = new List<condPagoDTO>();

            var query = (
                from data in context.CondPagos
                select new condPagoDTO
                {
                    CondPagoId = data.CondPagoId,
                    CondPagoDesc = String.IsNullOrEmpty(data.CondPagoDesc) ? "" : data.CondPagoDesc,
                    CondPagoDias = data.CondPagoDias
                }
            );
            result = await query.OrderBy(x => x.CondPagoDias).ToListAsync();

            return result;
        }
        [HttpGet("CondicionFactura/{condPagoId}")]
        public async Task<List<condPagoDTO>> CondicionFactura(int condPagoId)
        {
            var condicion = await context.CondPagos.FirstOrDefaultAsync(x => x.CondPagoId == condPagoId);
            var result = new List<condPagoDTO>();

            var query = (
                from data in context.CondPagos.Where(x => x.CondPagoDias <= condicion.CondPagoDias)
                select new condPagoDTO
                {
                    CondPagoId = data.CondPagoId,
                    CondPagoDesc = String.IsNullOrEmpty(data.CondPagoDesc) ? "" : data.CondPagoDesc,
                    CondPagoDias = data.CondPagoDias
                }
            );
            result = await query.OrderBy(x => x.CondPagoDias).ToListAsync();

            return result;
        }
    }
}
