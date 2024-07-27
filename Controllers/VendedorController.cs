using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
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
    [Authorize(AuthenticationSchemes = CookieAuthenticationDefaults.AuthenticationScheme)]
    public class VendedorController : ControllerBase
    {
        private readonly GestionEmpContext context;

        public VendedorController(GestionEmpContext context)
        {
            this.context = context;
        }
        [HttpGet("listadoVendedor")]
        public async Task<List<vendedorDTO>> ListadoVendedor()
        {
            var result = new List<vendedorDTO>();

            var query = (
                from data in context.Vendedors
                select new vendedorDTO
                {
                    VendedorId = data.VendedorId,
                    VendedorNombre = data.VendedorNombre,
                    VendedorEstatus = data.VendedorEstatus
                }
            );
            result = await query.OrderBy(x => x.VendedorNombre).ToListAsync();

            return result;
        }

        [HttpGet("Vendedor")]
        public async Task<List<vendedorDTO>> Vendedor()
        {
            var result = new List<vendedorDTO>();

            var query = (
                from data in context.Vendedors.Where(x => x.VendedorEstatus == true)
                select new vendedorDTO
                {
                    VendedorId = data.VendedorId,
                    VendedorNombre = data.VendedorNombre,
                    VendedorEstatus = data.VendedorEstatus
                }
            );
            result = await query.OrderBy(x => x.VendedorNombre).ToListAsync();

            return result;
        }

        [HttpGet("Vendedor/{vendedorId}")]
        public async Task<vendedorDTO> GetVendedor(int vendedorId)
        {
            vendedorDTO vendedor = new vendedorDTO();

            try
            {
                var result = await context.Vendedors.Where(x => x.VendedorId == vendedorId).FirstOrDefaultAsync();

                if (result != null)
                {
                    vendedor.VendedorId = result.VendedorId;
                    vendedor.VendedorNombre = result.VendedorNombre;
                    vendedor.VendedorEstatus = result.VendedorEstatus;
                    vendedor.VendedorCodigo = result.VendedorCodigo;
                }
            }
            catch (Exception)
            {

            }
            return vendedor;
        }
        [HttpPost("Vendedor")]
        public async Task<ActionResult> PostVendedor(vendedorDTO model)
        {
            try
            {
                var Existe = await context.Vendedors.Where(x => x.VendedorNombre == model.VendedorNombre).FirstOrDefaultAsync();

                if (Existe != null)
                {
                    return NotFound("Ya existe un Vendedor creado con este nombre.");
                }

                var ExisteCodigo = await context.Vendedors.Where(x => x.VendedorCodigo != "" && x.VendedorCodigo == model.VendedorCodigo).FirstOrDefaultAsync();

                if (ExisteCodigo != null)
                {
                    return NotFound("El código digitado ya está registrado en otro vendedor.");
                }
                Vendedor vendedor = new Vendedor();
                vendedor.VendedorNombre = model.VendedorNombre;
                vendedor.VendedorEstatus = model.VendedorEstatus;
                vendedor.VendedorCodigo = model.VendedorCodigo;
                context.Add(vendedor);
                await context.SaveChangesAsync();

                return NoContent();
            }
            catch (Exception)
            {
                return NotFound();
            }
        }
        [HttpPut("Vendedor")]
        public async Task<ActionResult> UpdateVendedor(vendedorDTO model)
        {
            try
            {
                var Existe = await context.Vendedors.Where(x => x.VendedorNombre == model.VendedorNombre && x.VendedorId != model.VendedorId).FirstOrDefaultAsync();

                if (Existe != null)
                {
                    return NotFound("Ya existe un Vendedor creado con este nombre.");
                }
                var ExisteCodigo = await context.Vendedors.Where(x => x.VendedorCodigo != "" && x.VendedorCodigo == model.VendedorCodigo && x.VendedorId != model.VendedorId).FirstOrDefaultAsync();

                if (ExisteCodigo != null)
                {
                    return NotFound("El código digitado ya está registrado en otro vendedor.");
                }

                Vendedor vendedor = await context.Vendedors.Where(x => x.VendedorId == model.VendedorId).FirstOrDefaultAsync();

                vendedor.VendedorNombre = model.VendedorNombre;
                vendedor.VendedorEstatus = model.VendedorEstatus;
                vendedor.VendedorCodigo = model.VendedorCodigo;
                context.Update(vendedor);

                await context.SaveChangesAsync();

                return NoContent();
            }
            catch (Exception)
            {
                return NotFound();
            }
        }
        [HttpDelete("Vendedor/{vendedorId}")]
        public async Task<IActionResult> DelVendedor(int vendedorId)
        {
            try
            {
                var vendedorEnCliente = await context.Clientes.AnyAsync(x => x.VendedorId == vendedorId);
                if (vendedorEnCliente)
                {
                    return NotFound("Vendedor no puede ser borrado, ha sido usado en clientes");
                }
                var vendedorEnfactura = await context.Facturas.AnyAsync(x => x.VendedorId == vendedorId);
                if (vendedorEnfactura)
                {
                    return NotFound("Vendedor no puede ser borrado, ha sido usado en facturas.");
                }
                context.Entry(new Vendedor { VendedorId = vendedorId }).State = EntityState.Deleted;
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
