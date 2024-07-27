using JaMPeApp.DTOs;
using JaMPeApp.Models;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace JaMPeApp.Controllers
{
    [ApiController]
    [Authorize(AuthenticationSchemes = CookieAuthenticationDefaults.AuthenticationScheme)]
    public class SuplidorController : Controller
    {
        private readonly GestionEmpContext context;

        public SuplidorController(GestionEmpContext context)
        {
            this.context = context;
        }

        //[HttpGet("ListadoSuplidors")]
        //public async Task<List<listadoSuplidorDTO>> Suplidors()
        //{
        //    var result = new List<listadoSuplidorDTO>();

        //    var query = (
        //        from data in context.Suplidors.Where(x => x.SuplidorCodigo != "Contado")
        //        select new listadoSuplidorDTO
        //        {
        //            SuplidorID = data.SuplidorId,
        //            SuplidorCodigo = data.SuplidorCodigo,
        //            SuplidorNombre = data.SuplidorNombre,
        //            SuplidorCedula = data.SuplidorCedula,
        //            SuplidorTelefono = data.SuplidorTel,
        //            SuplidorEmail = data.SuplidorEmail
        //        }
        //    );
        //    result = await query.OrderBy(x => x.SuplidorNombre).ToListAsync();

        //    return result;
        //}
        [HttpGet("Suplidor")]
        public async Task<List<suplidorDTO>> SuplidorsAll()
        {
            var result = new List<suplidorDTO>();

            var query = (
                from data in context.Suplidors.Where(x => x.SuplidorStatus == true)
                select new suplidorDTO
                {
                    SuplidorId = data.SuplidorId,
                    SuplidorCd = data.SuplidorCd,
                    SuplidorNombre = String.IsNullOrEmpty(data.SuplidorNombre) ? "" : data.SuplidorNombre,
                }
            );
            result = await query.OrderBy(x => x.SuplidorNombre).ToListAsync();

            return result;
        }

        //[HttpGet("Suplidor/{suplidorId}")]
        //public async Task<suplidorDTO> GetSuplidor(int suplidorId)
        //{
        //    suplidorDTO suplidor = new suplidorDTO();

        //    try
        //    {
        //        var result = await context.Suplidors.Where(x => x.SuplidorId == suplidorId).FirstOrDefaultAsync();

        //        if (result != null)
        //        {
        //            suplidor.SuplidorId = result.SuplidorId;
        //            suplidor.SuplidorCodigo = result.SuplidorCodigo;
        //            suplidor.SuplidorNombre = result.SuplidorNombre;
        //            suplidor.SuplidorDir1 = result.SuplidorDir1;
        //            suplidor.SuplidorDir2 = result.SuplidorDir2;
        //            suplidor.SuplidorCedula = result.SuplidorCedula;
        //            suplidor.SuplidorTel = result.SuplidorTel;
        //            suplidor.SuplidorFax = result.SuplidorFax;
        //            suplidor.SuplidorEmail = result.SuplidorEmail;
        //            suplidor.SuplidorDescto = result.SuplidorDescto;
        //            suplidor.SuplidorBalance = result.SuplidorBalance;
        //            suplidor.CondPagoId = result.CondPagoId;
        //            suplidor.SuplidorStatus = result.SuplidorStatus;
        //            suplidor.SuplidorContacto = result.SuplidorContacto;
        //            suplidor.SuplidorAutCredito = result.SuplidorAutCredito;
        //            suplidor.SuplidorLimiteCredito = result.SuplidorLimiteCredito;
        //            suplidor.SuplidorTipoId = result.SuplidorTipoId;
        //            suplidor.VendedorId = result.VendedorId;
        //            suplidor.ComprobanteTipoId = result.ComprobanteTipoId;
        //            suplidor.SuplidorSiRetieneIsr = result.SuplidorSiRetieneIsr;
        //            suplidor.SuplidorPrecioNo = result.SuplidorPrecioNo;
        //            suplidor.SuplidorTotalPuntos = result.SuplidorTotalPuntos;
        //            suplidor.SuplidorComentario = result.SuplidorComentario;
        //            suplidor.PlanId = result.PlanId;
        //        }
        //    }
        //    catch (Exception)
        //    {

        //    }



        //    return suplidor;
        //}
        //[HttpPost("Suplidor")]
        //public async Task<ActionResult> PostSuplidor(suplidorDTO model)
        //{
        //    try
        //    {
        //        var cedulaExiste = await context.Suplidors.Where(x => x.SuplidorCedula.Replace("-", "") == model.SuplidorCedula.Replace("-", "")).FirstOrDefaultAsync();

        //        if (cedulaExiste != null)
        //        {
        //            return NotFound("Cédula o RNC ya está asignada a otro suplidor (" + cedulaExiste.SuplidorNombre.ToUpper() + ").");
        //        }
        //        List<Suplidor> suplidors = await context.Suplidors.Where(x => x.SuplidorCodigo != "Contado").ToListAsync();
        //        Int32 ultCodigoSuplidor = 0;

        //        if (suplidors.Count() > 0)
        //        {
        //            foreach (var suplidor in suplidors)
        //            {
        //                var codigo = Convert.ToInt32(suplidor.SuplidorCodigo);
        //                if (codigo > ultCodigoSuplidor)
        //                {
        //                    ultCodigoSuplidor = codigo;
        //                }
        //            }
        //        }
        //        Suplidor newSuplidor = new Suplidor();
        //        newSuplidor.SuplidorCodigo = (ultCodigoSuplidor + 1).ToString();
        //        newSuplidor.SuplidorNombre = model.SuplidorNombre;
        //        newSuplidor.SuplidorDir1 = model.SuplidorDir1;
        //        newSuplidor.SuplidorDir2 = model.SuplidorDir2;
        //        newSuplidor.SuplidorCedula = model.SuplidorCedula;
        //        newSuplidor.SuplidorTel = model.SuplidorTel;
        //        newSuplidor.SuplidorFax = model.SuplidorFax;
        //        newSuplidor.SuplidorEmail = model.SuplidorEmail;
        //        newSuplidor.SuplidorDescto = model.SuplidorDescto;
        //        newSuplidor.SuplidorBalance = model.SuplidorBalance;
        //        newSuplidor.CondPagoId = model.CondPagoId;
        //        newSuplidor.SuplidorStatus = model.SuplidorStatus;
        //        newSuplidor.SuplidorContacto = model.SuplidorContacto;
        //        newSuplidor.SuplidorAutCredito = model.SuplidorAutCredito;
        //        newSuplidor.SuplidorLimiteCredito = model.SuplidorLimiteCredito;
        //        newSuplidor.SuplidorTipoId = model.SuplidorTipoId;
        //        newSuplidor.VendedorId = model.VendedorId;
        //        newSuplidor.ComprobanteTipoId = model.ComprobanteTipoId;
        //        newSuplidor.SuplidorSiRetieneIsr = model.SuplidorSiRetieneIsr;
        //        newSuplidor.SuplidorPrecioNo = model.SuplidorPrecioNo;
        //        newSuplidor.SuplidorTotalPuntos = model.SuplidorTotalPuntos;
        //        newSuplidor.SuplidorComentario = model.SuplidorComentario;
        //        newSuplidor.PlanId = model.PlanId;
        //        context.Add(newSuplidor);
        //        await context.SaveChangesAsync();

        //        return Ok(newSuplidor);
        //    }
        //    catch (Exception)
        //    {
        //        return NotFound();
        //    }
        //}
        //[HttpPut("Suplidor")]
        //public async Task<ActionResult> UpdateSuplidor(suplidorDTO model)
        //{
        //    try
        //    {
        //        var cedulaExiste = await context.Suplidors.Where(x => x.SuplidorCedula.Replace("-", "") == model.SuplidorCedula.Replace("-", "") && x.SuplidorId != model.SuplidorId).FirstOrDefaultAsync();

        //        if (cedulaExiste != null)
        //        {
        //            return NotFound("Cédula o RNC ya está asignada a otro suplidor (" + cedulaExiste.SuplidorNombre.ToUpper() + ").");
        //        }

        //        Suplidor suplidor = await context.Suplidors.Where(x => x.SuplidorId == model.SuplidorId).FirstOrDefaultAsync();

        //        suplidor.SuplidorNombre = model.SuplidorNombre;
        //        suplidor.SuplidorDir1 = model.SuplidorDir1;
        //        suplidor.SuplidorDir2 = model.SuplidorDir2;
        //        suplidor.SuplidorCedula = model.SuplidorCedula;
        //        suplidor.SuplidorTel = model.SuplidorTel;
        //        suplidor.SuplidorFax = model.SuplidorFax;
        //        suplidor.SuplidorEmail = model.SuplidorEmail;
        //        suplidor.SuplidorDescto = model.SuplidorDescto;
        //        suplidor.SuplidorBalance = model.SuplidorBalance;
        //        suplidor.CondPagoId = model.CondPagoId;
        //        suplidor.SuplidorStatus = model.SuplidorStatus;
        //        suplidor.SuplidorContacto = model.SuplidorContacto;
        //        suplidor.SuplidorAutCredito = model.SuplidorAutCredito;
        //        suplidor.SuplidorLimiteCredito = model.SuplidorLimiteCredito;
        //        suplidor.SuplidorTipoId = model.SuplidorTipoId;
        //        suplidor.VendedorId = model.VendedorId;
        //        suplidor.ComprobanteTipoId = model.ComprobanteTipoId;
        //        suplidor.SuplidorSiRetieneIsr = model.SuplidorSiRetieneIsr;
        //        suplidor.SuplidorPrecioNo = model.SuplidorPrecioNo;
        //        suplidor.SuplidorTotalPuntos = model.SuplidorTotalPuntos;
        //        suplidor.SuplidorComentario = model.SuplidorComentario;
        //        suplidor.PlanId = model.PlanId;
        //        context.Update(suplidor);

        //        await context.SaveChangesAsync();

        //        return NoContent();
        //    }
        //    catch (Exception)
        //    {
        //        return NotFound();
        //    }
        //}
        //[HttpDelete("Suplidor/{suplidorId}")]
        //public async Task<IActionResult> DelSuplidor(int suplidorId)
        //{
        //    try
        //    {

        //        var suplidorEnFactura = await context.Facturas.AnyAsync(x => x.SuplidorId == suplidorId);
        //        if (suplidorEnFactura)
        //        {
        //            return NotFound("Suplidor ha sido usado en factura y no puede ser borrado.");
        //        }
        //        var suplidorEnCotizacion = await context.Cotizacions.AnyAsync(x => x.SuplidorId == suplidorId);
        //        if (suplidorEnCotizacion)
        //        {
        //            return NotFound("Suplidor ha sido usado en Contizaciones y no puede ser borrado.");
        //        }
        //        var suplidorEnReservas = await context.Reservas.AnyAsync(x => x.SuplidorId == suplidorId);
        //        if (suplidorEnReservas)
        //        {
        //            return NotFound("Suplidor ha sido usado en Reservaciones y no puede ser borrado.");
        //        }
        //        var suplidorEnPrestamo = await context.Prestamos.AnyAsync(x => x.SuplidorId == suplidorId);
        //        if (suplidorEnPrestamo)
        //        {
        //            return NotFound("Suplidor ha sido usado en Prestamos y no puede ser borrado.");
        //        }
        //        var suplidorEnPrepago = await context.Prepagos.AnyAsync(x => x.SuplidorId == suplidorId);
        //        if (suplidorEnPrepago)
        //        {
        //            return NotFound("Suplidor ha sido usado en Prepagos y no puede ser borrado.");
        //        }
        //        context.Entry(new Suplidor { SuplidorId = suplidorId }).State = EntityState.Deleted;
        //        await context.SaveChangesAsync();
        //        return NoContent();
        //    }
        //    catch (System.Exception ex)
        //    {
        //        return NotFound(ex.Message);
        //    }
        //}

    }
}
