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
    public class TarifaController : ControllerBase
    {
        private readonly GestionEmpContext context;

        public TarifaController(GestionEmpContext context)
        {
            this.context = context;
        }
        [HttpGet("listadoTarifa")]
        public async Task<List<tarifaDTO>> listadoTarifa()
        {
            var result = new List<tarifaDTO>();

            var query = (
                from data in context.Tarifas
                from plan in context.Plans.Where(x => x.PlanId == data.PlanId).DefaultIfEmpty()
                from tipoHabitacion in context.TipoHabitacions.Where(x => x.TipoHabitacionId == data.TipoHabitacionId).DefaultIfEmpty()
                from tipoHospedaje in context.TipoHospedajes.Where(x => x.TipoHospedajeId == data.TipoHospedajeId).DefaultIfEmpty()
                select new tarifaDTO
                {
                    TipoHabitacionId = data.TipoHabitacionId,
                    TipoHabitacionDesc = tipoHabitacion.TipoHabitacionDesc,
                    PlanId = data.PlanId,
                    PlanDesc = plan.PlanDesc,
                    TipoHospedajeId = data.TipoHospedajeId,
                    TipoHospedajeDesc = tipoHospedaje.TipoHospedajeDesc,
                    TarifaPrecio = data.TarifaPrecio
                }
            );
            result = await query.ToListAsync();

            return result;
        }

        //[HttpGet("Tarifa")]
        //public async Task<List<tarifaDTO>> Tarifa()
        //{
        //    var result = new List<tarifaDTO>();

        //    var query = (
        //        from data in context.Tarifas
        //        select new tarifaDTO
        //        {
        //            TarifaId = data.TarifaId,
        //            TarifaDesc = String.IsNullOrEmpty(data.TarifaDesc) ? "" : data.TarifaDesc,
        //            TarifaEstatus = data.TarifaEstatus
        //        }
        //    );
        //    result = await query.OrderBy(x => x.TarifaDesc).ToListAsync();

        //    return result;
        //}
        [HttpGet("TarifaPrecio/{tipoHabitacionId:int}/{tipoHospedajeId:int}/{planId:int}")]
        public async Task<tarifaDTO> TarifaPrecio(int tipoHabitacionId, int tipoHospedajeId, int planId)
        {
            tarifaDTO tarifa = new tarifaDTO();

            try
            {
                var result = await context.Tarifas.Where(x => x.PlanId == planId && x.TipoHospedajeId == tipoHospedajeId && x.TipoHabitacionId == tipoHabitacionId).FirstOrDefaultAsync();

                if (result != null)
                {
                    tarifa.PlanId = result.PlanId;
                    tarifa.TipoHabitacionId = result.TipoHabitacionId;
                    tarifa.TipoHospedajeId = result.TipoHospedajeId;
                    tarifa.TarifaPrecio = result.TarifaPrecio;
                }
            }
            catch (Exception)
            {

            }
            return tarifa;
        }
        [HttpPost("TarifaEdit")]
        public async Task<tarifaDTO> GetTarifa( tarifaDTO model)
        {
            tarifaDTO tarifa = new tarifaDTO();

            try
            {
                var result = await context.Tarifas.Where(x => x.PlanId == model.PlanId && x.TipoHospedajeId == model.TipoHospedajeId && x.TipoHabitacionId == model.TipoHabitacionId).FirstOrDefaultAsync();

                if (result != null)
                {
                    tarifa.PlanId = result.PlanId;
                    tarifa.TipoHabitacionId = result.TipoHabitacionId;
                    tarifa.TipoHospedajeId = result.TipoHospedajeId;
                    tarifa.TarifaPrecio = result.TarifaPrecio;
                }
            }
            catch (Exception)
            {

            }
            return tarifa;
        }
        [HttpPost("Tarifa")]
        public async Task<ActionResult> PostTarifa(tarifaDTO model)
        {
            try
            {
                var Existe = await context.Tarifas.Where(x => x.PlanId == model.PlanId && x.TipoHospedajeId == model.TipoHospedajeId && x.TipoHabitacionId == model.TipoHabitacionId).FirstOrDefaultAsync();

                if (Existe != null)
                {
                    return NotFound("Ya existe una tafifa creada con esta combinación.");
                }
                Tarifa tarifa = new Tarifa();
                tarifa.PlanId = model.PlanId;
                tarifa.TipoHabitacionId = model.TipoHabitacionId;
                tarifa.TipoHospedajeId = model.TipoHospedajeId;
                tarifa.TarifaPrecio = model.TarifaPrecio;
                context.Add(tarifa);
                await context.SaveChangesAsync();

                return NoContent();
            }
            catch (Exception)
            {
                return NotFound();
            }
        }
        [HttpPut("Tarifa")]
        public async Task<ActionResult> UpdateTarifa(tarifaDTO model)
        {
            try
            {

                Tarifa tarifa = await context.Tarifas.Where(x => x.PlanId == model.PlanId && x.TipoHospedajeId == model.TipoHospedajeId && x.TipoHabitacionId == model.TipoHabitacionId).FirstOrDefaultAsync();

                tarifa.PlanId = model.PlanId;
                tarifa.TipoHabitacionId = model.TipoHabitacionId;
                tarifa.TipoHospedajeId = model.TipoHospedajeId;
                tarifa.TarifaPrecio = model.TarifaPrecio;
                context.Update(tarifa);

                await context.SaveChangesAsync();

                return NoContent();
            }
            catch (Exception)
            {
                return NotFound();
            }
        }
        [HttpDelete("Tarifa")]
        public async Task<IActionResult> DelTarifa(tarifaDTO model)
        {
            try
            {

                Tarifa tarifa = await context.Tarifas.Where(x => x.PlanId == model.PlanId && x.TipoHospedajeId == model.TipoHospedajeId && x.TipoHabitacionId == model.TipoHabitacionId).FirstOrDefaultAsync();

                context.Entry(tarifa).State = EntityState.Deleted;
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
