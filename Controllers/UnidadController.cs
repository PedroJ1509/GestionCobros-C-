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
    public class UnidadController : Controller
    {
        private readonly GestionEmpContext context;
        public UnidadController(GestionEmpContext context)
        {
            this.context = context;
        }
        [HttpGet("listadoUnidad")]
        public async Task<List<unidadDTO>> Clientes()
        {
            var result = new List<unidadDTO>();

            var query = (
                from data in context.Unidads
                select new unidadDTO
                {
                    unidadId = data.UnidadId,
                    unidadDesc = data.UnidadDesc
                }
            );
            result = await query.OrderBy(x => x.unidadDesc).ToListAsync();

            return result;
        }
        [HttpGet("Unidades")]
        public async Task<List<unidadDTO>> Unidades()
        {
            var result = new List<unidadDTO>();

            var query = (
                from data in context.Unidads
                select new unidadDTO
                {
                    unidadId = data.UnidadId,
                    unidadDesc = String.IsNullOrEmpty(data.UnidadDesc) ? "" : data.UnidadDesc.ToUpper(),
                }
            );
            result = await query.OrderBy(x => x.unidadDesc).ToListAsync();

            return result;
        }
        [HttpGet("UnidadesMedidas/{articuloId}")]
        public async Task<List<unidadDTO>> UnidadesMedidas(int articuloId)
        {
            var articulo = await context.Articulos.Where(x => x.ArticuloId == articuloId).FirstAsync();

            var result = new List<unidadDTO>();

            var query = (
                from data in context.Unidads.Where(x => x.UnidadId != articulo.UnidadId)
                select new unidadDTO
                {
                    unidadId = data.UnidadId,
                    unidadDesc = String.IsNullOrEmpty(data.UnidadDesc) ? "" : data.UnidadDesc.ToUpper(),
                }
            );
            result = await query.OrderBy(x => x.unidadDesc).ToListAsync();

            return result;
        }
        [HttpGet("UnidadesIngrediente/{articuloId}")]
        public async Task<List<unidadDTO>> UnidadesIngrediente(int articuloId)
        {
            var articulo = await context.Articulos.Where(x => x.ArticuloId == articuloId).FirstAsync();

            var result = new List<unidadDTO>();

            var query = (
                from data in context.ArticuloUnidads.Where(x => x.ArticuloId == articuloId)
                from unidad in context.Unidads.Where(u => u.UnidadId == data.UnidadId)
                select new unidadDTO
                {
                    unidadId = data.UnidadId,
                    unidadDesc = String.IsNullOrEmpty(unidad.UnidadDesc) ? "" : unidad.UnidadDesc.ToUpper(),
                }
            );
            result = await query.OrderBy(x => x.unidadDesc).ToListAsync();

            return result;
        }
        [HttpGet("Unidad/{unidadId}")]
        public async Task<unidadDTO> GetUnidad(int unidadId)
        {
            unidadDTO unidad = new unidadDTO();

            try
            {
                var result = await context.Unidads.Where(x => x.UnidadId == unidadId).FirstOrDefaultAsync();

                if (result != null)
                {
                    unidad.unidadId = result.UnidadId;
                    unidad.unidadDesc = result.UnidadDesc;
                }
            }
            catch (Exception)
            {

            }
            return unidad;
        }
        [HttpPost("Unidad")]
        public async Task<ActionResult> PostUnidad(unidadDTO model)
        {
            try
            {
                var Existe = await context.Unidads.Where(x => x.UnidadDesc == model.unidadDesc).FirstOrDefaultAsync();

                if (Existe != null)
                {
                    return NotFound("Ya existe una Unidad creada con esta descripción.");
                }
                Unidad unidad = new Unidad();
                unidad.UnidadDesc = model.unidadDesc.ToUpper();
                context.Add(unidad);
                await context.SaveChangesAsync();

                return NoContent();
            }
            catch (Exception)
            {
                return NotFound();
            }
        }
        [HttpPut("Unidad")]
        public async Task<ActionResult> UpdateUnidad(unidadDTO model)
        {
            try
            {
                var Existe = await context.Unidads.Where(x => x.UnidadDesc == model.unidadDesc && x.UnidadId != model.unidadId).FirstOrDefaultAsync();

                if (Existe != null)
                {
                    return NotFound("Ya existe una Unidad creada con esta descripción.");
                }

                Unidad unidad = await context.Unidads.Where(x => x.UnidadId == model.unidadId).FirstOrDefaultAsync();

                unidad.UnidadDesc = model.unidadDesc.ToUpper();
                context.Update(unidad);

                await context.SaveChangesAsync();

                return NoContent();
            }
            catch (Exception)
            {
                return NotFound();
            }
        }
        [HttpDelete("Unidad/{unidadId}")]
        public async Task<IActionResult> DelUnidad(int unidadId)
        {
            try
            {
                var mesaEnUnidad = await context.Articulos.AnyAsync(x => x.UnidadId == unidadId);
                if (mesaEnUnidad)
                {
                    return NotFound("Unidad no puede ser borrado");
                }
                context.Entry(new Unidad { UnidadId = unidadId }).State = EntityState.Deleted;
                await context.SaveChangesAsync();
                return NoContent();
            }
            catch (System.Exception ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}
