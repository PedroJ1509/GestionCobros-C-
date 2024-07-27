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
    public class PantallaController : Controller
    {
        private readonly GestionEmpContext context;
        public PantallaController(GestionEmpContext context)
        {
            this.context = context;
        }
        [HttpGet("Pantallas")]
        public async Task<List<pantallaDTO>> Salas()
        {
            var result = new List<pantallaDTO>();

            var query = (
                from data in context.Pantallas
                select new pantallaDTO
                {
                    PantallaId = data.PantallaId,
                    PantallaDesc = String.IsNullOrEmpty(data.PantallaDesc) ? "" : data.PantallaDesc,
                }
            );
            result = await query.OrderBy(x => x.PantallaDesc).ToListAsync();

            return result;
        }
    }
}
