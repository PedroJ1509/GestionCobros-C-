using JaMPeApp.DTOs;
using JaMPeApp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace JaMPeApp.Controllers
{
    [ApiController]
    [Authorize(AuthenticationSchemes = "Cookies")]
    public class DepartamentoController : Controller
    {
        private readonly GestionEmpContext context;

        public DepartamentoController(GestionEmpContext context)
        {
            this.context = context;
        }

        [HttpGet("Departamentos")]
        public async Task<List<departamentoDTO>> Departamentos()
        {
            new List<departamentoDTO>();
            IQueryable<departamentoDTO> query = context.Departamentos.Select((Departamento data) => new departamentoDTO
            {
                DepartamentoId = data.DepartamentoId,
                DepartamentoDesc = (string.IsNullOrEmpty(data.DepartamentoDesc) ? "" : data.DepartamentoDesc.ToUpper())
            });
            return await query.OrderBy((departamentoDTO x) => x.DepartamentoDesc).ToListAsync();
        }
    }
}
