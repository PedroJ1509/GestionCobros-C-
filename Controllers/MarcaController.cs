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
    public class MarcaController : Controller
    {
        private readonly GestionEmpContext context;
        public MarcaController(GestionEmpContext context)
        {
            this.context = context;
        }
        [HttpGet("Marcas")]
        public async Task<List<marcaDTO>> Marcas()
        {
            var result = new List<marcaDTO>();

            var query = (
                from data in context.Marcas
                select new marcaDTO
                {
                    marcaId = data.MarcaId,
                    marcaDesc = String.IsNullOrEmpty(data.MarcaDesc) ? "" : data.MarcaDesc.ToUpper(),
                }
            );
            result = await query.OrderBy(x => x.marcaDesc).ToListAsync();

            return result;
        }
    }
}
