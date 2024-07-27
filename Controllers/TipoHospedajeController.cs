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
    public class TipoHospedajeController : ControllerBase
    {
        private readonly GestionEmpContext context;

        public TipoHospedajeController(GestionEmpContext context)
        {
            this.context = context;
        }
        [HttpGet("listadoTipoHospedaje")]
        public async Task<List<tipoHospedajeDTO>> TipoHospedajes()
        {
            var result = new List<tipoHospedajeDTO>();

            var query = (
                from data in context.TipoHospedajes
                select new tipoHospedajeDTO
                {
                    TipoHospedajeId = data.TipoHospedajeId,
                    TipoHospedajeDesc = data.TipoHospedajeDesc,
                    TipoHospedajeOcupacion = data.TipoHospedajeOcupacion,
                    TipoHospedajeEstatus = data.TipoHospedajeEstatus
                }
            );
            result = await query.OrderBy(x => x.TipoHospedajeDesc).ToListAsync();

            return result;
        }

        [HttpGet("TipoHospedajes")]
        public async Task<List<tipoHospedajeDTO>> GetTipoHospedajes()
        {
            var result = new List<tipoHospedajeDTO>();

            var query = (
                from data in context.TipoHospedajes.Where(x => x.TipoHospedajeEstatus == true)
                select new tipoHospedajeDTO
                {
                    TipoHospedajeId = data.TipoHospedajeId,
                    TipoHospedajeDesc = String.IsNullOrEmpty(data.TipoHospedajeDesc) ? "" : data.TipoHospedajeDesc,
                    TipoHospedajeEstatus = data.TipoHospedajeEstatus
                }
            );
            result = await query.OrderBy(x => x.TipoHospedajeDesc).ToListAsync();

            return result;
        }
        [HttpGet("TipoHospedaje/{tipoHospedajeId}")]
        public async Task<tipoHospedajeDTO> GetTipoHospedaje(int tipoHospedajeId)
        {
            tipoHospedajeDTO tipoHospedaje = new tipoHospedajeDTO();

            try
            {
                var result = await context.TipoHospedajes.Where(x => x.TipoHospedajeId == tipoHospedajeId).FirstOrDefaultAsync();

                if (result != null)
                {
                    tipoHospedaje.TipoHospedajeId = result.TipoHospedajeId;
                    tipoHospedaje.TipoHospedajeDesc = result.TipoHospedajeDesc;
                    tipoHospedaje.TipoHospedajeOcupacion = result.TipoHospedajeOcupacion;
                    tipoHospedaje.TipoHospedajeEstatus = result.TipoHospedajeEstatus;
                }
            }
            catch (Exception)
            {

            }
            return tipoHospedaje;
        }
        [HttpPost("TipoHospedaje")]
        public async Task<ActionResult> PostTipoHospedaje(tipoHospedajeDTO model)
        {
            try
            {
                var Existe = await context.TipoHospedajes.Where(x => x.TipoHospedajeDesc == model.TipoHospedajeDesc).FirstOrDefaultAsync();

                if (Existe != null)
                {
                    return NotFound("Ya existe un Tipo de Hospedaje creada con esta descripción.");
                }
                TipoHospedaje tipoHospedaje = new TipoHospedaje();
                tipoHospedaje.TipoHospedajeDesc = model.TipoHospedajeDesc;
                tipoHospedaje.TipoHospedajeOcupacion = model.TipoHospedajeOcupacion;
                tipoHospedaje.TipoHospedajeEstatus = model.TipoHospedajeEstatus;
                context.Add(tipoHospedaje);
                await context.SaveChangesAsync();

                return NoContent();
            }
            catch (Exception)
            {
                return NotFound();
            }
        }
        [HttpPut("TipoHospedaje")]
        public async Task<ActionResult> UpdateTipoHospedaje(tipoHospedajeDTO model)
        {
            try
            {
                var Existe = await context.TipoHospedajes.Where(x => x.TipoHospedajeDesc == model.TipoHospedajeDesc && x.TipoHospedajeId != model.TipoHospedajeId).FirstOrDefaultAsync();

                if (Existe != null)
                {
                    return NotFound("Ya existe un Tipo de Hospedaje creada con esta descripción.");
                }

                TipoHospedaje tipoHospedaje = await context.TipoHospedajes.Where(x => x.TipoHospedajeId == model.TipoHospedajeId).FirstOrDefaultAsync();

                tipoHospedaje.TipoHospedajeDesc = model.TipoHospedajeDesc;
                tipoHospedaje.TipoHospedajeEstatus = model.TipoHospedajeEstatus;
                tipoHospedaje.TipoHospedajeOcupacion = model.TipoHospedajeOcupacion;
                context.Update(tipoHospedaje);

                await context.SaveChangesAsync();

                return NoContent();
            }
            catch (Exception)
            {
                return NotFound();
            }
        }
        [HttpDelete("TipoHospedaje/{tipoHospedajeId}")]
        public async Task<IActionResult> DelTipoHospedaje(int tipoHospedajeId)
        {
            try
            {
                var tipoHospedajeEnHab = await context.Tarifas.AnyAsync(x => x.TipoHospedajeId == tipoHospedajeId);
                if (tipoHospedajeEnHab)
                {
                    return NotFound("Tipo de Hospedaje no puede ser borrado");
                }
                context.Entry(new TipoHospedaje { TipoHospedajeId = tipoHospedajeId }).State = EntityState.Deleted;
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
