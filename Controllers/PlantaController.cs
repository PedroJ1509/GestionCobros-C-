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
    public class PlantaController : ControllerBase
    {
        private readonly GestionEmpContext context;

        public PlantaController(GestionEmpContext context)
        {
            this.context = context;
        }
        [HttpGet("listadoPlantas")]
        public async Task<List<plantaDTO>> Clientes()
        {
            var result = new List<plantaDTO>();

            var query = (
                from data in context.Planta
                select new plantaDTO
                {
                    PlantaId = data.PlantaId,
                    PlantaDesc = data.PlantaDesc,
                    PlantaEstatus = data.PlantaEstatus
                }
            );
            result = await query.OrderBy(x => x.PlantaDesc).ToListAsync();

            return result;
        }

        [HttpGet("Plantas")]
        public async Task<List<plantaDTO>> Plantas()
        {
            var result = new List<plantaDTO>();

            var query = (
                from data in context.Planta.Where(x => x.PlantaEstatus == true)
                select new plantaDTO
                {
                    PlantaId = data.PlantaId,
                    PlantaDesc = String.IsNullOrEmpty(data.PlantaDesc) ? "" : data.PlantaDesc,
                    PlantaEstatus = data.PlantaEstatus
                }
            );
            result = await query.OrderBy(x => x.PlantaDesc).ToListAsync();

            return result;
        }
        [HttpGet("Planta/{plantaId}")]
        public async Task<plantaDTO> GetPlanta(int plantaId)
        {
            plantaDTO planta = new plantaDTO();

            try
            {
                var result = await context.Planta.Where(x => x.PlantaId == plantaId).FirstOrDefaultAsync();

                if (result != null)
                {
                    planta.PlantaId = result.PlantaId;
                    planta.PlantaDesc = result.PlantaDesc;
                    planta.PlantaEstatus = result.PlantaEstatus;
                }
            }
            catch (Exception)
            {

            }
            return planta;
        }
        [HttpPost("Planta")]
        public async Task<ActionResult> PostPlanta(plantaDTO model)
        {
            try
            {
                var Existe = await context.Planta.Where(x => x.PlantaDesc == model.PlantaDesc).FirstOrDefaultAsync();

                if (Existe != null)
                {
                    return NotFound("Ya existe una Planta creada con esta descripción.");
                }
                Plantum planta = new Plantum();
                planta.PlantaDesc = model.PlantaDesc;
                planta.PlantaEstatus = model.PlantaEstatus;
                context.Add(planta);
                await context.SaveChangesAsync();

                return NoContent();
            }
            catch (Exception)
            {
                return NotFound();
            }
        }
        [HttpPut("Planta")]
        public async Task<ActionResult> UpdatePlanta(plantaDTO model)
        {
            try
            {
                var Existe = await context.Planta.Where(x => x.PlantaDesc == model.PlantaDesc && x.PlantaId != model.PlantaId).FirstOrDefaultAsync();

                if (Existe != null)
                {
                    return NotFound("Ya existe una Plana creada con esta descripción.");
                }

                Plantum planta = await context.Planta.Where(x => x.PlantaId == model.PlantaId).FirstOrDefaultAsync();

                planta.PlantaDesc = model.PlantaDesc;
                planta.PlantaEstatus = model.PlantaEstatus;
                context.Update(planta);

                await context.SaveChangesAsync();

                return NoContent();
            }
            catch (Exception)
            {
                return NotFound();
            }
        }
        [HttpDelete("Planta/{plantaId}")]
        public async Task<IActionResult> DelPlanta(int plantaId)
        {
            try
            {
                var plantaEnHab= await context.Habitacions.AnyAsync(x => x.PlantaId == plantaId);
                if (plantaEnHab)
                {
                    return NotFound("Plana no puede ser borrado");
                }
                context.Entry(new Plantum { PlantaId = plantaId }).State = EntityState.Deleted;
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
