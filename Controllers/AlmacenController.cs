using JaMPeApp.DTOs;
using JaMPeApp.Models;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace JaMPeApp.Controllers
{
    [ApiController]
    [Authorize(AuthenticationSchemes = CookieAuthenticationDefaults.AuthenticationScheme)]
    public class AlmacenController : Controller
    {
        private readonly GestionEmpContext context;
        public AlmacenController(GestionEmpContext context)
        {
            this.context = context;
        }
        [HttpGet("Almacen")]
        public async Task<List<almacenDTO>> Salas()
        {
            var result = new List<almacenDTO>();

            var query = (
                from data in context.Almacens
                select new almacenDTO
                {
                    almacenId = data.AlmacenId,
                    almacenDesc = String.IsNullOrEmpty(data.AlmacenDesc) ? "" : data.AlmacenDesc,
                }
            );
            result = await query.OrderBy(x => x.almacenDesc).ToListAsync();

            return result;
        }
    }
}
