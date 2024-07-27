using JaMPeApp.DTOs;
using JaMPeApp.Models;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Globalization;

namespace JaMPeApp.Controllers
{
    [ApiController]
    [Authorize(AuthenticationSchemes = CookieAuthenticationDefaults.AuthenticationScheme)]
    public class FacturaController : Controller
    {
        private readonly GestionEmpContext context;

        public FacturaController(GestionEmpContext context)
        {
            this.context = context;
        }

        [HttpPost("ListaFacturasVentas")]
        public async Task<List<ListaVentasFacturasDTO>> ListaFacturasVentas()
        {
            
            new List<ListaVentasFacturasDTO>();

            IQueryable<ListaVentasFacturasDTO> query = from x in context.VistaFacturasSinCierres
                                                       select x into fac
                                                       select new ListaVentasFacturasDTO
                                                       {
                                                           facturaId = fac.FacturaId,
                                                           facturaNo = fac.FacturaNo,
                                                           fecha = Convert.ToDateTime(fac.FacturaFecha).ToString("dd/MM/yyyy"),
                                                           cliente = fac.ClienteNombre,
                                                           condicionDesc = fac.CondPagoDesc.ToUpper(),
                                                           comprobante = "", // (string.IsNullOrEmpty(fac.FacturaComprobante) ? "" : fac.FacturaComprobante),
                                                           descuento = Convert.ToDecimal(fac.FacturaDescto).ToString("0,0.0", CultureInfo.InvariantCulture),
                                                           itbis = Convert.ToDecimal(fac.FacturaItbis).ToString("0,0.0", CultureInfo.InvariantCulture),
                                                           ley = Convert.ToDecimal(fac.FacturaMontoImpuesto).ToString("0,0.0", CultureInfo.InvariantCulture),
                                                           total = Convert.ToDecimal(fac.FacturaBalance).ToString("0,0.0", CultureInfo.InvariantCulture),
                                                           estado = fac.FacturaEstatus
                                                  };
            return await query.OrderByDescending((ListaVentasFacturasDTO x) => x.facturaId).ToListAsync();
        }
        [HttpPost("ListaFacturasVentasTotales")]
        public async Task<IActionResult> ListaFacturasVentasTotales()
        {
            new List<consultaVentasTotalesDTO>();
            new consultaVentasTotalesDTO();
            decimal totalDescuento = default(decimal);
            decimal totalLey = default(decimal);
            decimal totalItbis = default(decimal);
            decimal totalGeneral = default(decimal);
            IQueryable<consultaVentasTotalesDTO> query = from x in context.VistaFacturasSinCierres
                                                       select x into fac
                                                         select new consultaVentasTotalesDTO
                                                         {
                                                             totalDescuento = Convert.ToDecimal(fac.FacturaDescto),
                                                             totalItbis = Convert.ToDecimal(fac.FacturaItbis),
                                                             totalLey = Convert.ToDecimal(fac.FacturaMontoImpuesto),
                                                             totalGeneral = Convert.ToDecimal(fac.FacturaBalance)
                                                         };
            foreach (consultaVentasTotalesDTO item in await query.ToListAsync())
            {
                totalDescuento += item.totalDescuento;
                totalItbis += item.totalItbis;
                totalLey += item.totalLey;
                totalGeneral += item.totalGeneral;
            }
            return Ok(new
            {
                totalDescuento = Convert.ToDecimal(totalDescuento).ToString("0,0.0", CultureInfo.InvariantCulture),
                totalLey = Convert.ToDecimal(totalLey).ToString("0,0.0", CultureInfo.InvariantCulture),
                totalItbis = Convert.ToDecimal(totalItbis).ToString("0,0.0", CultureInfo.InvariantCulture),
                totalGeneral = Convert.ToDecimal(totalGeneral).ToString("0,0.0", CultureInfo.InvariantCulture)
            });
        }

        [HttpGet("BuscarDatosFacturaNueva")]
        public async Task<IActionResult> BuscarDatosFacturaNueva()
        {
            var result = await context.Generals.FirstOrDefaultAsync();

            return Ok(new
            {
                ultNumFactura = (result.GeneralUltimaFactura + 1),
                genClienteId = result.GeneralClienteId,
                genTipoComprobante = result.GeneralComprobanteTipoId,
                genTasaImpuesto = result.GeneralTasaImpuesto
            });
        }

        [HttpGet("SiguienteComprobante/{comprobanteId}")]
        public async Task<IActionResult> SiguienteComprobante(int comprobanteId)
        {
            var MinNCF = await context.ComprobanteDisps.Where(x => x.ComprobanteTipoId == comprobanteId).Select(x => x.Ncf).MinAsync();
            string comprobanteComent = "";
            string estadoComprobante = "";
            string mensaje = "";
            string numNCF = "";

            if (MinNCF == null) {
                estadoComprobante = "N";
                var comprobanteTipo = await context.ComprobanteTipos.FirstOrDefaultAsync(x => x.ComprobanteTipoId == comprobanteId);
                var comprobante = await context.Comprobantes.FirstOrDefaultAsync(x => x.ComprobanteTipoId == comprobanteId);

                if (comprobante != null)
                {
                    if ((comprobante.ComprobanteUltimoUsado+1) <= comprobante.ComprobanteFinal)
                    {
                        if (Convert.ToBoolean(comprobanteTipo.ComprobanteSiFechaVen))
                        {
                            if (comprobanteTipo.ComprobanteFechaVen >= DateTime.Now)
                            {
                                comprobanteComent = Convert.ToDateTime(comprobanteTipo.ComprobanteFechaVen).ToString("yyyy-MM-dd HH:mm:ss");
                                numNCF = comprobanteTipo.ComprobanteTextoInicial + (comprobante.ComprobanteUltimoUsado + 1).ToString().PadLeft(10, '0');
                                if ((comprobante.ComprobanteFinal - comprobante.ComprobanteUltimoUsado) <= 10)
                                {
                                    mensaje = "Debe de solicitar comprobantes fiscales del tipo " + comprobanteTipo.ComprobanteDesc.ToUpper() + " ya que solo le quedan " + (comprobante.ComprobanteFinal - comprobante.ComprobanteUltimoUsado).ToString() + ".";
                                }
                            }
                            else
                            {
                                mensaje = "Los Comprobantes Fiscales del tipo " + comprobanteTipo.ComprobanteDesc.ToUpper() + " tienen la fecha vencida, favor verificar...";
                                comprobanteComent = "";
                                comprobanteId = 0;
                                numNCF = "";
                            }
                        }
                        else
                        {
                            comprobanteComent = "";
                            numNCF = comprobanteTipo.ComprobanteTextoInicial + (comprobante.ComprobanteUltimoUsado + 1).ToString().PadLeft(10, '0');
                            if ((comprobante.ComprobanteFinal - comprobante.ComprobanteUltimoUsado) <= 10)
                            {
                                mensaje = "Debe de solicitar comprobantes fiscales del tipo " + comprobanteTipo.ComprobanteDesc.ToUpper() + " ya que solo le quedan " + (comprobante.ComprobanteFinal - comprobante.ComprobanteUltimoUsado).ToString() + ".";
                            }
                        }
                    }
                    else
                    {
                        mensaje = "Todos los Comprobantes Fiscales del tipo " + comprobanteTipo.ComprobanteDesc.ToUpper() + " han sido usado.";
                        comprobanteComent = "";
                        comprobanteId = 0;
                        numNCF = "";
                    }
                }
                else
                {
                    mensaje = "No hay comprobantes configurados para los tipo " + comprobanteTipo.ComprobanteDesc.ToUpper() + ".";
                    comprobanteComent = "";
                    comprobanteId = 0;
                    numNCF = "";
                }
            }
            else
            {
                numNCF = MinNCF;
                estadoComprobante = "D";
            }

            return Ok(new
            {
                comprobanteComent = comprobanteComent,
                estadoComprobante = estadoComprobante,
                mensaje = mensaje,
                numNCF = numNCF,
                comprobanteId = comprobanteId
            });
        }
    }
}
