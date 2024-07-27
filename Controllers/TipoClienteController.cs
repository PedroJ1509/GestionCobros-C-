using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using JaMPeApp.DTOs;
using JaMPeApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace JaMPeApp.Controllers
{
    [ApiController]
    [Authorize(AuthenticationSchemes = CookieAuthenticationDefaults.AuthenticationScheme)]
    public class TipoClienteController : ControllerBase
    {
        private readonly GestionEmpContext context;

        public TipoClienteController(GestionEmpContext context)
        {
            this.context = context;
        }

        [HttpGet("ClienteTipo")]
        public async Task<List<clienteTipoDTO>> TipoClientes()
        {
            var result = new List<clienteTipoDTO>();

            var query = (
                from data in context.ClienteTipos
                select new clienteTipoDTO
                {
                    ClienteTipoId = data.ClienteTipoId,
                    ClienteTipoDesc = data.ClienteTipoDesc
                }
            );
            result = await query.OrderBy(x => x.ClienteTipoDesc).ToListAsync();

            return result;
        }
        [HttpGet("listadoTipoCliente")]
        public async Task<List<clienteTipoDTO>> ListTipoClientes()
        {
            var result = new List<clienteTipoDTO>();

            var query = (
                from data in context.ClienteTipos
                select new clienteTipoDTO
                {
                    ClienteTipoId = data.ClienteTipoId,
                    ClienteTipoDesc = data.ClienteTipoDesc
                }
            );
            result = await query.OrderBy(x => x.ClienteTipoDesc).ToListAsync();

            return result;
        }
        [HttpGet("TipoCliente/{clienteTipoId}")]
        public async Task<clienteTipoDTO> GetTipoCliente(int clienteTipoId)
        {
            clienteTipoDTO tipoCliente = new clienteTipoDTO();

            try
            {
                var result = await context.ClienteTipos.Where(x => x.ClienteTipoId == clienteTipoId).FirstOrDefaultAsync();

                if (result != null)
                {
                    tipoCliente.ClienteTipoId = result.ClienteTipoId;
                    tipoCliente.ClienteTipoDesc = result.ClienteTipoDesc;
                }
            }
            catch (Exception)
            {

            }
            return tipoCliente;
        }
        [HttpPost("TipoCliente")]
        public async Task<ActionResult> PostTipoCliente(clienteTipoDTO model)
        {
            try
            {
                var Existe = await context.ClienteTipos.Where(x => x.ClienteTipoDesc == model.ClienteTipoDesc).FirstOrDefaultAsync();

                if (Existe != null)
                {
                    return NotFound("Ya existe un Tipo de Cliente creada con esta descripción.");
                }
                ClienteTipo tipoCliente = new ClienteTipo();
                tipoCliente.ClienteTipoDesc = model.ClienteTipoDesc;
                context.Add(tipoCliente);
                await context.SaveChangesAsync();

                return NoContent();
            }
            catch (Exception)
            {
                return NotFound();
            }
        }
        [HttpPut("TipoCliente")]
        public async Task<ActionResult> UpdateTipoCliente(clienteTipoDTO model)
        {
            try
            {
                var Existe = await context.ClienteTipos.Where(x => x.ClienteTipoDesc == model.ClienteTipoDesc && x.ClienteTipoId != model.ClienteTipoId).FirstOrDefaultAsync();

                if (Existe != null)
                {
                    return NotFound("Ya existe un Tipo de Cliente creada con esta descripción.");
                }

                ClienteTipo tipoCliente = await context.ClienteTipos.Where(x => x.ClienteTipoId == model.ClienteTipoId).FirstOrDefaultAsync();

                tipoCliente.ClienteTipoDesc = model.ClienteTipoDesc;
                context.Update(tipoCliente);

                await context.SaveChangesAsync();

                return NoContent();
            }
            catch (Exception)
            {
                return NotFound();
            }
        }
        [HttpDelete("TipoCliente/{clienteTipoId}")]
        public async Task<IActionResult> DelTipoCliente(int clienteTipoId)
        {
            try
            {
                var tipoClienteEnCliente = await context.Clientes.AnyAsync(x => x.ClienteTipoId == clienteTipoId);
                if (tipoClienteEnCliente)
                {
                    return NotFound("Tipo de Cliente no puede ser borrado");
                }
                context.Entry(new ClienteTipo { ClienteTipoId = clienteTipoId }).State = EntityState.Deleted;
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
