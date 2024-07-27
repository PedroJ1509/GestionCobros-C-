using JaMPeApp.DTOs;
using JaMPeApp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace JaMPeApp.Controllers
{
    [ApiController]
    [Authorize(AuthenticationSchemes = "Cookies")]
    public class ModeloController : Controller
    {
        private readonly GestionEmpContext context;

        public ModeloController(GestionEmpContext context)
        {
            this.context = context;
        }

        [HttpGet("Modelos")]
        public async Task<List<modeloDTO>> Modelos()
        {
            new List<modeloDTO>();
            IQueryable<modeloDTO> query = context.Modelos.Select((Modelo data) => new modeloDTO
            {
                modeloId = data.ModeloId,
                modeloDesc = (string.IsNullOrEmpty(data.ModeloDesc) ? "" : data.ModeloDesc.ToUpper())
            });
            return await query.OrderBy((modeloDTO x) => x.modeloDesc).ToListAsync();
        }
    }
}
