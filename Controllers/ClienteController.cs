using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.JwtBearer;
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
    public class ClienteController : ControllerBase
    {
        private readonly GestionEmpContext context;

        public ClienteController(GestionEmpContext context)
        {
            this.context = context;
        }

        [HttpGet("ListadoClientes")]
        public async Task<List<listadoClienteDTO>> Clientes()
        {
            var result = new List<listadoClienteDTO>();

            var query = (
                from data in context.Clientes.Where(x => x.ClienteCodigo != "Contado")
                select new listadoClienteDTO
                {
                    ClienteID = data.ClienteId,
                    ClienteCodigo = data.ClienteCodigo,
                    ClienteNombre = data.ClienteNombre,
                    ClienteCedula = data.ClienteCedula,
                    ClienteTelefono = data.ClienteTel,
                    ClienteEmail = data.ClienteEmail
                }
            );
            result = await query.OrderBy(x => x.ClienteNombre).ToListAsync();

            return result;
        }
        [HttpGet("Cliente")]
        public async Task<List<clienteDTO>> ClientesAll()
        {
            var result = new List<clienteDTO>();

            var query = (
                from data in context.Clientes.Where(x => x.ClienteStatus == true && x.ClienteCodigo != "Contado")
                select new clienteDTO
                {
                    ClienteId = data.ClienteId,
                    ClienteNombre = String.IsNullOrEmpty(data.ClienteNombre) ? "" : data.ClienteNombre,
                    PlanId = data.PlanId,
                    VendedorId = data.VendedorId,
                    ComprobanteTipoId = data.ComprobanteTipoId,
                    ClienteTipoId = data.ClienteTipoId
                }
            );
            result = await query.OrderBy(x => x.ClienteNombre).ToListAsync();

            return result;
        }
        [HttpGet("ClienteFactura")]
        public async Task<List<clienteDTO>> ClienteFactura()
        {
            var result = new List<clienteDTO>();

            var query = (
                from data in context.Clientes.Where(x => x.ClienteStatus == true && x.ClienteAutCredito == false)
                select new clienteDTO
                {
                    ClienteId = data.ClienteId,
                    ClienteNombre = String.IsNullOrEmpty(data.ClienteNombre) ? "AL CONTADO" : data.ClienteNombre,
                    PlanId = data.PlanId,
                    VendedorId = data.VendedorId,
                    ComprobanteTipoId = data.ComprobanteTipoId,
                    CondPagoId = data.CondPagoId,
                    ClienteTipoId = data.ClienteTipoId
                }
            );
            result = await query.OrderBy(x => x.ClienteNombre).ToListAsync();

            return result;
        }
        [HttpGet("Cliente/{clienteId}")]
        public async Task<clienteDTO> GetCliente(int clienteId)
        {
            clienteDTO cliente = new clienteDTO();

            try
            {
                var result = await context.Clientes.Where(x => x.ClienteId == clienteId).FirstOrDefaultAsync();

                if (result != null)
                {
                    cliente.ClienteId = result.ClienteId;
                    cliente.ClienteCodigo = result.ClienteCodigo;
                    cliente.ClienteNombre = result.ClienteNombre;
                    cliente.ClienteDir1 = result.ClienteDir1;
                    cliente.ClienteDir2 = result.ClienteDir2;
                    cliente.ClienteCedula = result.ClienteCedula;
                    cliente.ClienteTel = result.ClienteTel;
                    cliente.ClienteFax = result.ClienteFax;
                    cliente.ClienteEmail = result.ClienteEmail;
                    cliente.ClienteDescto = result.ClienteDescto;
                    cliente.ClienteBalance = result.ClienteBalance;
                    cliente.CondPagoId = result.CondPagoId;
                    cliente.ClienteStatus = result.ClienteStatus;
                    cliente.ClienteContacto = result.ClienteContacto;
                    cliente.ClienteAutCredito = result.ClienteAutCredito;
                    cliente.ClienteLimiteCredito = result.ClienteLimiteCredito;
                    cliente.ClienteTipoId = result.ClienteTipoId;
                    cliente.VendedorId = result.VendedorId;
                    cliente.ComprobanteTipoId = result.ComprobanteTipoId;
                    cliente.ClienteSiRetieneIsr = result.ClienteSiRetieneIsr;
                    cliente.ClientePrecioNo = result.ClientePrecioNo;
                    cliente.ClienteTotalPuntos = result.ClienteTotalPuntos;
                    cliente.ClienteComentario = result.ClienteComentario;
                    cliente.PlanId = result.PlanId;
                }
            }
            catch (Exception)
            {
                
            }

            

            return cliente;
        }
        [HttpPost("Cliente")]
        public async Task<ActionResult> PostCliente(clienteDTO model)
        {
            try
            {
                var cedulaExiste = await context.Clientes.Where(x => x.ClienteCedula.Replace("-", "") == model.ClienteCedula.Replace("-", "")).FirstOrDefaultAsync();

                if (cedulaExiste != null)
                {
                    return NotFound("Cédula o RNC ya está asignada a otro cliente ("+ cedulaExiste.ClienteNombre.ToUpper() + ").");
                }
                List<Cliente> clientes = await context.Clientes.Where(x => x.ClienteCodigo != "Contado").ToListAsync();
                Int32 ultCodigoCliente = 0;

                if (clientes.Count() > 0)
                {
                    foreach (var cliente in clientes)
                    {
                        var codigo = Convert.ToInt32(cliente.ClienteCodigo);
                        if (codigo > ultCodigoCliente)
                        {
                            ultCodigoCliente = codigo;
                        }
                    }
                }
                Cliente newCliente = new Cliente();
                newCliente.ClienteCodigo = (ultCodigoCliente + 1).ToString();
                newCliente.ClienteNombre = model.ClienteNombre;
                newCliente.ClienteDir1 = model.ClienteDir1;
                newCliente.ClienteDir2 = model.ClienteDir2;
                newCliente.ClienteCedula = model.ClienteCedula;
                newCliente.ClienteTel = model.ClienteTel;
                newCliente.ClienteFax = model.ClienteFax;
                newCliente.ClienteEmail = model.ClienteEmail;
                newCliente.ClienteDescto = model.ClienteDescto;
                newCliente.ClienteBalance = model.ClienteBalance;
                newCliente.CondPagoId = model.CondPagoId;
                newCliente.ClienteStatus = model.ClienteStatus;
                newCliente.ClienteContacto = model.ClienteContacto;
                newCliente.ClienteAutCredito = model.ClienteAutCredito;
                newCliente.ClienteLimiteCredito = model.ClienteLimiteCredito;
                newCliente.ClienteTipoId = model.ClienteTipoId;
                newCliente.VendedorId = model.VendedorId;
                newCliente.ComprobanteTipoId = model.ComprobanteTipoId;
                newCliente.ClienteSiRetieneIsr = model.ClienteSiRetieneIsr;
                newCliente.ClientePrecioNo = model.ClientePrecioNo;
                newCliente.ClienteTotalPuntos = model.ClienteTotalPuntos;
                newCliente.ClienteComentario = model.ClienteComentario;
                newCliente.PlanId = model.PlanId;
                context.Add(newCliente);
                await context.SaveChangesAsync();

                return Ok(newCliente);
            }
            catch (Exception)
            {
                return NotFound();
            }
        }
        [HttpPut("Cliente")]
        public async Task<ActionResult> UpdateCliente(clienteDTO model)
        {
            try
            {
                var cedulaExiste = await context.Clientes.Where(x => x.ClienteCedula.Replace("-", "") == model.ClienteCedula.Replace("-", "") && x.ClienteId != model.ClienteId).FirstOrDefaultAsync();

                if (cedulaExiste != null)
                {
                    return NotFound("Cédula o RNC ya está asignada a otro cliente (" + cedulaExiste.ClienteNombre.ToUpper() + ").");
                }

                Cliente cliente = await context.Clientes.Where(x => x.ClienteId == model.ClienteId).FirstOrDefaultAsync();

                cliente.ClienteNombre = model.ClienteNombre;
                cliente.ClienteDir1 = model.ClienteDir1;
                cliente.ClienteDir2 = model.ClienteDir2;
                cliente.ClienteCedula = model.ClienteCedula;
                cliente.ClienteTel = model.ClienteTel;
                cliente.ClienteFax = model.ClienteFax;
                cliente.ClienteEmail = model.ClienteEmail;
                cliente.ClienteDescto = model.ClienteDescto;
                cliente.ClienteBalance = model.ClienteBalance;
                cliente.CondPagoId = model.CondPagoId;
                cliente.ClienteStatus = model.ClienteStatus;
                cliente.ClienteContacto = model.ClienteContacto;
                cliente.ClienteAutCredito = model.ClienteAutCredito;
                cliente.ClienteLimiteCredito = model.ClienteLimiteCredito;
                cliente.ClienteTipoId = model.ClienteTipoId;
                cliente.VendedorId = model.VendedorId;
                cliente.ComprobanteTipoId = model.ComprobanteTipoId;
                cliente.ClienteSiRetieneIsr = model.ClienteSiRetieneIsr;
                cliente.ClientePrecioNo = model.ClientePrecioNo;
                cliente.ClienteTotalPuntos = model.ClienteTotalPuntos;
                cliente.ClienteComentario = model.ClienteComentario;
                cliente.PlanId = model.PlanId;
                context.Update(cliente);

                await context.SaveChangesAsync();

                return NoContent();
            }
            catch (Exception)
            {
                return NotFound();
            }
        }
        [HttpDelete("Cliente/{clienteId}")]
        public async Task<IActionResult> DelCliente(int clienteId)
        {
            try
            {

                var clienteEnFactura = await context.Facturas.AnyAsync(x => x.ClienteId == clienteId);
                if (clienteEnFactura)
                {
                    return NotFound("Cliente ha sido usado en factura y no puede ser borrado.");
                }
                var clienteEnCotizacion = await context.Cotizacions.AnyAsync(x => x.ClienteId == clienteId);
                if (clienteEnCotizacion)
                {
                    return NotFound("Cliente ha sido usado en Contizaciones y no puede ser borrado.");
                }
                var clienteEnReservas = await context.Reservas.AnyAsync(x => x.ClienteId == clienteId);
                if (clienteEnReservas)
                {
                    return NotFound("Cliente ha sido usado en Reservaciones y no puede ser borrado.");
                }
                var clienteEnPrestamo = await context.Prestamos.AnyAsync(x => x.ClienteId == clienteId);
                if (clienteEnPrestamo)
                {
                    return NotFound("Cliente ha sido usado en Prestamos y no puede ser borrado.");
                }
                var clienteEnPrepago = await context.Prepagos.AnyAsync(x => x.ClienteId == clienteId);
                if (clienteEnPrepago)
                {
                    return NotFound("Cliente ha sido usado en Prepagos y no puede ser borrado.");
                }
                context.Entry(new Cliente { ClienteId = clienteId }).State = EntityState.Deleted;
                await context.SaveChangesAsync();
                return NoContent();
            }
            catch (System.Exception ex)
            {
                return NotFound(ex.Message);
            }
        }
        [HttpGet("ConsultarRNC/{rnc}")]
        public async Task<ActionResult> ConsultarRNC(string rnc)
        {
            var result = await context.ClienteRncs.Where(x => x.ClienteRnc1 == rnc).FirstOrDefaultAsync();
            //var result = await context.Clientes.FirstOrDefaultAsync();

            return Ok( result );
        }
    }
}
