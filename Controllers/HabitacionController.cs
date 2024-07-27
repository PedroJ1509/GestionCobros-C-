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
    public class HabitacionController : ControllerBase
    {
        private readonly GestionEmpContext context;

        public HabitacionController(GestionEmpContext context)
        {
            this.context = context;
        }
        [HttpGet("listadoHabitacion")]
        public async Task<List<habitacionDTO>> listadoHabitacion()
        {
            var result = new List<habitacionDTO>();

            var query = (
                from data in context.Habitacions
                from planta in context.Planta.Where(x => x.PlantaId == data.PlantaId).DefaultIfEmpty()
                from tipoHabitacion in context.TipoHabitacions.Where(x => x.TipoHabitacionId == data.TipoHabitacionId).DefaultIfEmpty()
                select new habitacionDTO
                {
                    HabitacionId = data.HabitacionId,
                    HabitacionDesc = data.HabitacionDesc,
                    PlantaId = data.PlantaId,
                    PlantaDesc = planta.PlantaDesc,
                    TipoHabitacionId = data.TipoHabitacionId,
                    TipoHabitacionDesc = tipoHabitacion.TipoHabitacionDesc,
                    HabitacionEstado = data.HabitacionEstado,
                    HabitacionEstatus = data.HabitacionEstatus
                }
            );
            result = await query.OrderBy(x => x.HabitacionDesc).ToListAsync();

            return result;
        }

        [HttpGet("Habitacion")]
        public async Task<List<habitacionDTO>> Habitacion()
        {
            var result = new List<habitacionDTO>();

            var query = (
                from data in context.Habitacions.Where(x => x.HabitacionEstatus == true)
                select new habitacionDTO
                {
                    HabitacionId = data.HabitacionId,
                    HabitacionDesc = String.IsNullOrEmpty(data.HabitacionDesc) ? "" : data.HabitacionDesc,
                    HabitacionEstatus = data.HabitacionEstatus,
                    HabitacionEstado = data.HabitacionEstado,
                    TipoHabitacionId = data.TipoHabitacionId
                }
            );
            result = await query.OrderBy(x => x.HabitacionDesc).ToListAsync();

            return result;
        }
        [HttpGet("HabitacionDisponibles")]
        public async Task<List<habitacionDTO>> HabitacionDisponibles()
        {
            var result = new List<habitacionDTO>();

            var query = (
                from data in context.Habitacions.Where(x => x.HabitacionEstatus == true && x.HabitacionEstado == 0)
                select new habitacionDTO
                {
                    HabitacionId = data.HabitacionId,
                    HabitacionDesc = String.IsNullOrEmpty(data.HabitacionDesc) ? "" : data.HabitacionDesc,
                    HabitacionEstatus = data.HabitacionEstatus,
                    HabitacionEstado = data.HabitacionEstado,
                    TipoHabitacionId = data.TipoHabitacionId
                }
            );
            result = await query.OrderBy(x => x.HabitacionDesc).ToListAsync();

            return result;
        }
        [HttpGet("Habitacion/{habitacionId}")]
        public async Task<habitacionDTO> GetHabitacion(int habitacionId)
        {
            habitacionDTO habitacion = new habitacionDTO();

            try
            {
                var result = await context.Habitacions.Where(x => x.HabitacionId == habitacionId).FirstOrDefaultAsync();

                if (result != null)
                {
                    habitacion.HabitacionId = result.HabitacionId;
                    habitacion.HabitacionDesc = result.HabitacionDesc;
                    habitacion.PlantaId = result.PlantaId;
                    habitacion.TipoHabitacionId = result.TipoHabitacionId;
                    habitacion.HabitacionEstado = result.HabitacionEstado;
                    habitacion.HabitacionEstatus = result.HabitacionEstatus;
                }
            }
            catch (Exception)
            {

            }
            return habitacion;
        }
        [HttpPost("Habitacion")]
        public async Task<ActionResult> PostHabitacion(habitacionDTO model)
        {
            try
            {
                var Existe = await context.Habitacions.Where(x => x.HabitacionDesc == model.HabitacionDesc).FirstOrDefaultAsync();

                if (Existe != null)
                {
                    return NotFound("Ya existe una Habitación creada con esta descripción.");
                }
                Habitacion habitacion = new Habitacion();
                habitacion.HabitacionDesc = model.HabitacionDesc;
                habitacion.PlantaId = model.PlantaId;
                habitacion.TipoHabitacionId = model.TipoHabitacionId;
                habitacion.HabitacionEstado = 1;
                habitacion.HabitacionEstatus = model.HabitacionEstatus;
                context.Add(habitacion);
                await context.SaveChangesAsync();

                return NoContent();
            }
            catch (Exception)
            {
                return NotFound();
            }
        }
        [HttpPut("Habitacion")]
        public async Task<ActionResult> UpdateHabitacion(habitacionDTO model)
        {
            try
            {
                var Existe = await context.Habitacions.Where(x => x.HabitacionDesc == model.HabitacionDesc && x.HabitacionId != model.HabitacionId).FirstOrDefaultAsync();

                if (Existe != null)
                {
                    return NotFound("Ya existe una Habitación creada con esta descripción.");
                }

                Habitacion habitacion = await context.Habitacions.Where(x => x.HabitacionId == model.HabitacionId).FirstOrDefaultAsync();

                habitacion.HabitacionDesc = model.HabitacionDesc;
                habitacion.HabitacionEstatus = model.HabitacionEstatus;
                habitacion.PlantaId = model.PlantaId;
                habitacion.TipoHabitacionId = model.TipoHabitacionId;
                context.Update(habitacion);

                await context.SaveChangesAsync();

                return NoContent();
            }
            catch (Exception)
            {
                return NotFound();
            }
        }
        [HttpPost("CambiarEstadoHabitacion/{habitacionId}")]
        public async Task<IActionResult> CambiarEstadoHabitacion(int habitacionId)
        {
            try
            {
                Habitacion habitacion = await context.Habitacions.Where(x => x.HabitacionId == habitacionId).FirstOrDefaultAsync();

                habitacion.HabitacionEstado = 0;
                context.Update(habitacion);

                await context.SaveChangesAsync();

                return NoContent();
            }
            catch (System.Exception ex)
            {
                return NotFound(ex.Message);
            }
        }
        [HttpDelete("Habitacion/{habitacionId}")]
        public async Task<IActionResult> DelHabitacion(int habitacionId)
        {
            try
            {
                var habitacionEnHab = await context.ReservaDets.AnyAsync(x => x.HabitacionId == habitacionId);
                if (habitacionEnHab)
                {
                    return NotFound("Habitación no puede ser borrado");
                }
                context.Entry(new Habitacion { HabitacionId = habitacionId }).State = EntityState.Deleted;
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
