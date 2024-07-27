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
    public class PlanController : ControllerBase
    {
        private readonly GestionEmpContext context;

        public PlanController(GestionEmpContext context)
        {
            this.context = context;
        }
        [HttpGet("listadoPlanes")]
        public async Task<List<planDTO>> Clientes()
        {
            var result = new List<planDTO>();

            var query = (
                from data in context.Plans
                select new planDTO
                {
                    PlanId = data.PlanId,
                    PlanDesc = data.PlanDesc,
                    PlanEstatus = data.PlanEstatus
                }
            );
            result = await query.OrderBy(x => x.PlanDesc).ToListAsync();

            return result;
        }

        [HttpGet("Planes")]
        public async Task<List<planDTO>> Planes()
        {
            var result = new List<planDTO>();

            var query = (
                from data in context.Plans.Where(x => x.PlanEstatus == true)
                select new planDTO
                {
                    PlanId = data.PlanId,
                    PlanDesc = String.IsNullOrEmpty(data.PlanDesc) ? "" : data.PlanDesc,
                    PlanEstatus = data.PlanEstatus
                }
            );
            result = await query.OrderBy(x => x.PlanDesc).ToListAsync();

            return result;
        }
        [HttpGet("Plan/{planId}")]
        public async Task<planDTO> GetPlan(int planId)
        {
            planDTO plan = new planDTO();

            try
            {
                var result = await context.Plans.Where(x => x.PlanId == planId).FirstOrDefaultAsync();

                if (result != null)
                {
                    plan.PlanId = result.PlanId;
                    plan.PlanDesc = result.PlanDesc;
                    plan.PlanEstatus = result.PlanEstatus;
                }
            }
            catch (Exception)
            {

            }
            return plan;
        }
        [HttpPost("Plan")]
        public async Task<ActionResult> PostPlan(planDTO model)
        {
            try
            {
                var Existe = await context.Plans.Where(x => x.PlanDesc == model.PlanDesc).FirstOrDefaultAsync();

                if (Existe != null)
                {
                    return NotFound("Ya existe un Plan creado con esta descripción.");
                }
                Plan plan = new Plan();
                plan.PlanDesc = model.PlanDesc;
                plan.PlanEstatus = model.PlanEstatus;
                context.Add(plan);
                await context.SaveChangesAsync();

                return NoContent();
            }
            catch (Exception)
            {
                return NotFound();
            }
        }
        [HttpPut("Plan")]
        public async Task<ActionResult> UpdatePlan(planDTO model)
        {
            try
            {
                var Existe = await context.Plans.Where(x => x.PlanDesc == model.PlanDesc && x.PlanId != model.PlanId).FirstOrDefaultAsync();

                if (Existe != null)
                {
                    return NotFound("Ya existe un Plan creado con esta descripción.");
                }

                Plan plan = await context.Plans.Where(x => x.PlanId == model.PlanId).FirstOrDefaultAsync();

                plan.PlanDesc = model.PlanDesc;
                plan.PlanEstatus = model.PlanEstatus;
                context.Update(plan);

                await context.SaveChangesAsync();

                return NoContent();
            }
            catch (Exception)
            {
                return NotFound();
            }
        }
        [HttpDelete("Plan/{planId}")]
        public async Task<IActionResult> DelPlan(int planId)
        {
            try
            {
                var planEnCliente = await context.Clientes.AnyAsync(x => x.PlanId == planId);
                if (planEnCliente)
                {
                    return NotFound("Plan no puede ser borrado");
                }
                context.Entry(new Plan { PlanId = planId }).State = EntityState.Deleted;
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
