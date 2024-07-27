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
    public class TipoHabitacionController : ControllerBase
    {
        private readonly GestionEmpContext context;

        public TipoHabitacionController(GestionEmpContext context)
        {
            this.context = context;
        }
        [HttpGet("listadoTipoHabitacion")]
        public async Task<List<tipoHabitacionDTO>> TipoHabitaciones()
        {
            var result = new List<tipoHabitacionDTO>();

            var query = (
                from data in context.TipoHabitacions
                select new tipoHabitacionDTO
                {
                    TipoHabitacionId = data.TipoHabitacionId,
                    TipoHabitacionDesc = data.TipoHabitacionDesc,
                    TipoHabitacionEstatus = data.TipoHabitacionEstatus
                }
            );
            result = await query.OrderBy(x => x.TipoHabitacionDesc).ToListAsync();

            return result;
        }

        [HttpGet("TipoHabitaciones")]
        public async Task<List<tipoHabitacionDTO>> GetTipoHabitaciones()
        {
            var result = new List<tipoHabitacionDTO>();

            var query = (
                from data in context.TipoHabitacions.Where(x => x.TipoHabitacionEstatus == true)
                select new tipoHabitacionDTO
                {
                    TipoHabitacionId = data.TipoHabitacionId,
                    TipoHabitacionDesc = String.IsNullOrEmpty(data.TipoHabitacionDesc) ? "" : data.TipoHabitacionDesc,
                    TipoHabitacionEstatus = data.TipoHabitacionEstatus
                }
            );
            result = await query.OrderBy(x => x.TipoHabitacionDesc).ToListAsync();

            return result;
        }
        [HttpGet("TipoHabitacion/{tipoHabitacionId}")]
        public async Task<tipoHabitacionDTO> GetTipoHabitacion(int tipoHabitacionId)
        {
            tipoHabitacionDTO tipoHabitacion = new tipoHabitacionDTO();

            try
            {
                var result = await context.TipoHabitacions.Where(x => x.TipoHabitacionId == tipoHabitacionId).FirstOrDefaultAsync();

                if (result != null)
                {
                    tipoHabitacion.TipoHabitacionId = result.TipoHabitacionId;
                    tipoHabitacion.TipoHabitacionDesc = result.TipoHabitacionDesc;
                    tipoHabitacion.TipoHabitacionEstatus = result.TipoHabitacionEstatus;
                }
            }
            catch (Exception)
            {

            }
            return tipoHabitacion;
        }
        [HttpPost("TipoHabitacion")]
        public async Task<ActionResult> PostTipoHabitacion(tipoHabitacionDTO model)
        {
            try
            {
                var Existe = await context.TipoHabitacions.Where(x => x.TipoHabitacionDesc == model.TipoHabitacionDesc).FirstOrDefaultAsync();

                if (Existe != null)
                {
                    return NotFound("Ya existe un Tipo de Habitación creada con esta descripción.");
                }
                TipoHabitacion tipoHabitacion = new TipoHabitacion();
                tipoHabitacion.TipoHabitacionDesc = model.TipoHabitacionDesc;
                tipoHabitacion.TipoHabitacionEstatus = model.TipoHabitacionEstatus;
                context.Add(tipoHabitacion);
                await context.SaveChangesAsync();

                return NoContent();
            }
            catch (Exception)
            {
                return NotFound();
            }
        }
        [HttpPut("TipoHabitacion")]
        public async Task<ActionResult> UpdateTipoHabitacion(tipoHabitacionDTO model)
        {
            try
            {
                var Existe = await context.TipoHabitacions.Where(x => x.TipoHabitacionDesc == model.TipoHabitacionDesc && x.TipoHabitacionId != model.TipoHabitacionId).FirstOrDefaultAsync();

                if (Existe != null)
                {
                    return NotFound("Ya existe un Tipo de Habitación creada con esta descripción.");
                }

                TipoHabitacion tipoHabitacion = await context.TipoHabitacions.Where(x => x.TipoHabitacionId == model.TipoHabitacionId).FirstOrDefaultAsync();

                tipoHabitacion.TipoHabitacionDesc = model.TipoHabitacionDesc;
                tipoHabitacion.TipoHabitacionEstatus = model.TipoHabitacionEstatus;
                context.Update(tipoHabitacion);

                await context.SaveChangesAsync();

                return NoContent();
            }
            catch (Exception)
            {
                return NotFound();
            }
        }
        [HttpDelete("TipoHabitacion/{tipoHabitacionId}")]
        public async Task<IActionResult> DelTipoHabitacion(int tipoHabitacionId)
        {
            try
            {
                var tipoHabitacionEnHab = await context.Habitacions.AnyAsync(x => x.TipoHabitacionId == tipoHabitacionId);
                if (tipoHabitacionEnHab)
                {
                    return NotFound("Tipo de Habitación no puede ser borrado");
                }
                context.Entry(new TipoHabitacion { TipoHabitacionId = tipoHabitacionId }).State = EntityState.Deleted;
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
