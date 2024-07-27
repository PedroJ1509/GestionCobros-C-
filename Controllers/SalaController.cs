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
    public class SalaController : ControllerBase
    {
        private readonly GestionEmpContext context;

        public SalaController(GestionEmpContext context)
        {
            this.context = context;
        }
        [HttpGet("listadoSalas")]
        public async Task<List<salaDTO>> Clientes()
        {
            var result = new List<salaDTO>();

            var query = (
                from data in context.Salas
                select new salaDTO
                {
                    SalaId = data.SalaId,
                    SalaDesc = data.SalaDesc,
                    SalaEstatus = data.SalaEstatus
                }
            );
            result = await query.OrderBy(x => x.SalaDesc).ToListAsync();

            return result;
        }

        [HttpGet("Salas")]
        public async Task<List<salaDTO>> Salas()
        {
            var result = new List<salaDTO>();

            var query = (
                from data in context.Salas.Where(x => x.SalaEstatus == true)
                select new salaDTO
                {
                    SalaId = data.SalaId,
                    SalaDesc = String.IsNullOrEmpty(data.SalaDesc) ? "" : data.SalaDesc,
                    SalaEstatus = data.SalaEstatus
                }
            );
            result = await query.OrderBy(x => x.SalaDesc).ToListAsync();

            return result;
        }
        [HttpGet("Sala/{salaId}")]
        public async Task<salaDTO> GetSala(int salaId)
        {
            salaDTO sala = new salaDTO();

            try
            {
                var result = await context.Salas.Where(x => x.SalaId == salaId).FirstOrDefaultAsync();

                if (result != null)
                {
                    sala.SalaId = result.SalaId;
                    sala.SalaDesc = result.SalaDesc;
                    sala.SalaEstatus = result.SalaEstatus;
                }
            }
            catch (Exception)
            {

            }
            return sala;
        }
        [HttpPost("Sala")]
        public async Task<ActionResult> PostSala(salaDTO model)
        {
            try
            {
                var Existe = await context.Salas.Where(x => x.SalaDesc == model.SalaDesc).FirstOrDefaultAsync();

                if (Existe != null)
                {
                    return NotFound("Ya existe una Sala creada con esta descripción.");
                }
                Sala sala = new Sala();
                sala.SalaDesc = model.SalaDesc.ToUpper();
                sala.SalaEstatus = model.SalaEstatus;
                context.Add(sala);
                await context.SaveChangesAsync();

                return NoContent();
            }
            catch (Exception)
            {
                return NotFound();
            }
        }
        [HttpPut("Sala")]
        public async Task<ActionResult> UpdateSala(salaDTO model)
        {
            try
            {
                var Existe = await context.Salas.Where(x => x.SalaDesc == model.SalaDesc && x.SalaId != model.SalaId).FirstOrDefaultAsync();

                if (Existe != null)
                {
                    return NotFound("Ya existe una Plana creada con esta descripción.");
                }

                Sala sala = await context.Salas.Where(x => x.SalaId == model.SalaId).FirstOrDefaultAsync();

                sala.SalaDesc = model.SalaDesc.ToUpper();
                sala.SalaEstatus = model.SalaEstatus;
                context.Update(sala);

                await context.SaveChangesAsync();

                return NoContent();
            }
            catch (Exception)
            {
                return NotFound();
            }
        }
        [HttpDelete("Sala/{salaId}")]
        public async Task<IActionResult> DelSala(int salaId)
        {
            try
            {
                var mesaEnSala = await context.Mesas.AnyAsync(x => x.SalaId == salaId);
                if (mesaEnSala)
                {
                    return NotFound("Sala no puede ser borrado");
                }
                context.Entry(new Sala { SalaId = salaId }).State = EntityState.Deleted;
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
