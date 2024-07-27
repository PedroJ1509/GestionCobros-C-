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
    public class MesaController : ControllerBase
    {
        private readonly GestionEmpContext context;

        public MesaController(GestionEmpContext context)
        {
            this.context = context;
        }
        [HttpGet("listadoMesas")]
        public async Task<List<mesaDTO>> listadoMesa()
        {
            var result = new List<mesaDTO>();

            var query = (
                from data in context.Mesas
                from sala in context.Salas.Where(x => x.SalaId == data.SalaId).DefaultIfEmpty()
                select new mesaDTO
                {
                    MesaId = data.MesaId,
                    MesaNo = data.MesaNo,
                    MesaDesc = data.MesaDesc,
                    MesaEstatus = data.MesaEstatus,
                    SalaId = data.SalaId,
                    SalaDesc = sala.SalaDesc
                }
            );
            result = await query.OrderBy(x => x.MesaDesc).ToListAsync();

            return result;
        }

        [HttpGet("Mesa")]
        public async Task<List<mesaDTO>> Mesa()
        {
            var result = new List<mesaDTO>();

            var query = (
                from data in context.Mesas.Where(x => x.MesaEstatus == true)
                select new mesaDTO
                {
                    MesaId = data.MesaId,
                    MesaDesc = String.IsNullOrEmpty(data.MesaDesc) ? "" : data.MesaDesc,
                    MesaEstatus = data.MesaEstatus
                }
            );
            result = await query.OrderBy(x => x.MesaDesc).ToListAsync();

            return result;
        }
        [HttpGet("Mesa/{mesaId}")]
        public async Task<mesaDTO> GetMesa(int mesaId)
        {
            mesaDTO mesa = new mesaDTO();

            try
            {
                var result = await context.Mesas.Where(x => x.MesaId == mesaId).FirstOrDefaultAsync();

                if (result != null)
                {
                    mesa.MesaId = result.MesaId;
                    mesa.MesaNo = result.MesaNo;
                    mesa.MesaDesc = result.MesaDesc;
                    mesa.MesaEstatus = result.MesaEstatus;
                    mesa.SalaId = result.SalaId;
                }
            }
            catch (Exception)
            {

            }
            return mesa;
        }
        [HttpPost("Mesa")]
        public async Task<ActionResult> PostMesa(mesaDTO model)
        {
            try
            {
                var Existe = await context.Mesas.Where(x => x.MesaDesc == model.MesaDesc).FirstOrDefaultAsync();

                if (Existe != null)
                {
                    return NotFound("Ya existe una Mesa creada con esta descripción y/o número.");
                }
                List<Mesa> mesas = await context.Mesas.ToListAsync();
                Int32 ultMesaNo = 1;

                if (mesas.Count() > 0)
                {
                    foreach (var mes in mesas)
                    {
                        var mesaNo = Convert.ToInt32(mes.MesaNo);
                        if (mesaNo > ultMesaNo)
                        {
                            ultMesaNo = mesaNo;
                        }
                    }
                }

                Mesa mesa = new Mesa();
                mesa.MesaId = model.MesaId;
                mesa.MesaNo = ultMesaNo;
                mesa.MesaDesc = model.MesaDesc;
                mesa.MesaEstatus = model.MesaEstatus;
                mesa.SalaId = model.SalaId;
                context.Add(mesa);
                await context.SaveChangesAsync();

                return NoContent();
            }
            catch (Exception)
            {
                return NotFound();
            }
        }
        [HttpPut("Mesa")]
        public async Task<ActionResult> UpdateMesa(mesaDTO model)
        {
            try
            {
                var Existe = await context.Mesas.Where(x => x.MesaDesc == model.MesaDesc && x.MesaId != model.MesaId).FirstOrDefaultAsync();

                if (Existe != null)
                {
                    return NotFound("Ya existe una Mesa creada con esta descripción.");
                }

                Mesa mesa = await context.Mesas.Where(x => x.MesaId == model.MesaId).FirstOrDefaultAsync();

                mesa.MesaId = model.MesaId;
                mesa.MesaDesc = model.MesaDesc;
                mesa.MesaEstatus = model.MesaEstatus;
                mesa.SalaId = model.SalaId;
                context.Update(mesa);

                await context.SaveChangesAsync();

                return NoContent();
            }
            catch (Exception)
            {
                return NotFound();
            }
        }
        [HttpDelete("Mesa/{mesaId}")]
        public async Task<IActionResult> DelMesa(int mesaId)
        {
            try
            {
                var mesaEnFac = await context.Facturas.AnyAsync(x => x.MesaId == mesaId);
                if (mesaEnFac)
                {
                    return NotFound("Mesa no puede ser borrado");
                }
                context.Entry(new Mesa { MesaId = mesaId }).State = EntityState.Deleted;
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
