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
    public class DashboardController : Controller
    {
        private readonly GestionEmpContext context;
        public DashboardController(GestionEmpContext context)
        {
            this.context = context;
        }
        [HttpGet("TotalesDashboardInfo")]
        public async Task<totalesDashboard> TotalesDashboardInfo()
        {
            var result = new totalesDashboard();

            var ventadia = await context.Facturas.Where(x => x.FacturaFecha.Value.Year == DateTime.Today.Year && x.FacturaFecha.Value.Month == DateTime.Today.Month && x.FacturaFecha.Value.Day == DateTime.Today.Day && x.FacturaEstatus == false).Select(x => x.FacturaBalance).SumAsync();

            var recibodia = await context.ReciboPagos.Where(x => x.ReciboFecha.Value.Year == DateTime.Today.Year && x.ReciboFecha.Value.Month == DateTime.Today.Month && x.ReciboFecha.Value.Day == DateTime.Today.Day).Select(x => x.ReciboMonto).SumAsync();

            var totalcxc = await context.VistaEstadoCxCs.Select(x => x.Pendiente).SumAsync();

            //var totalcxp = await context.VistaEstadoSuplidors.Select(x => x.Pendiente).SumAsync();

            var ultimoCierre = await context.CierreCajas.Include(x => x.Usuario).Where(x =>  x.CierreCajaCerrada == true)
                                       .Select(x => new { fecha = x.CierreCajaFechaHora, dia = x.CierreCajaFechaHora.Value.Day, mes = x.CierreCajaFechaHora.Value.Month, usuario = x.Usuario.UsuarioNombre, monto = Convert.ToDecimal(x.CierreCajaMonto).ToString("0,0.00", CultureInfo.InvariantCulture), efectivo = Convert.ToDecimal(x.CierreCajaEfectivoSistema).ToString("0,0.00", CultureInfo.InvariantCulture) })
                                       .OrderByDescending(result => result.fecha).Take(1).FirstOrDefaultAsync();

            result.ventasDia = Convert.ToDecimal(ventadia).ToString("0,0.00", CultureInfo.InvariantCulture);
            result.reciboDia = Convert.ToDecimal(recibodia).ToString("0,0.00", CultureInfo.InvariantCulture);
            result.totalCxC = Convert.ToDecimal(totalcxc).ToString("0,0.00", CultureInfo.InvariantCulture);
            result.totalCxP = "";
            result.ultimoCierre = ultimoCierre.monto;

            return result;
        }
        [HttpGet("BuscarVentasPorDia")]
        public async Task<IActionResult> BuscarVentasPorDia()
        {
            var FechaInicial = Convert.ToDateTime(DateTime.Today.Year.ToString() + "-" + DateTime.Today.Month.ToString() + "-" + DateTime.Today.Day.ToString()).AddDays(-7);

            var result = await context.Facturas.Where(x => x.FacturaFecha >= FechaInicial && x.FacturaEstatus == false)
                                        .GroupBy(fac => fac.FacturaFecha.Value.Month.ToString() + "-" + fac.FacturaFecha.Value.Day.ToString())
                                        .Select(grupo => new { fecha = grupo.Key, mes = grupo.Max(fact => fact.FacturaFecha.Value.Month), dia = grupo.Max(fact => fact.FacturaFecha.Value.Day), total = grupo.Sum(fact => fact.FacturaBalance) })
                                        .OrderBy(result => result.mes).ThenBy(result => result.dia).ToListAsync();

            return Ok(
                result
            );
        }
        [HttpGet("BuscarVentasPorMes")]
        public async Task<IActionResult> BuscarVentasPorMes()
        {
            var FechaInicial = Convert.ToDateTime(DateTime.Today.Year.ToString() + "-" + DateTime.Today.Month.ToString() + "-01").AddMonths(-7);
            var FechaFinal = Convert.ToDateTime(DateTime.Today.Year.ToString() + "-" + DateTime.Today.Month.ToString() + "-01");

            List<ventasPorMesDTO> arrResult = new List<ventasPorMesDTO>();

            while (FechaInicial <= FechaFinal)
            {
                List<int> listContado = await context.CondPagos.Where(x => x.CondPagoDias==0).Select(x =>x.CondPagoId).ToListAsync();
                List<int> listCCredito = await context.CondPagos.Where(x => x.CondPagoDias > 0).Select(x => x.CondPagoId).ToListAsync();

                var ventaMesContado = await context.Facturas.Where(x => x.FacturaFecha.Value.Year == FechaInicial.Year && x.FacturaFecha.Value.Month == FechaInicial.Month && listContado.Contains((int)x.CondPagoId) && x.FacturaEstatus == false).Select(x => x.FacturaBalance).SumAsync();
                var ventaMesCRedito = await context.Facturas.Where(x => x.FacturaFecha.Value.Year == FechaInicial.Year && x.FacturaFecha.Value.Month == FechaInicial.Month && listCCredito.Contains((int)x.CondPagoId) && x.FacturaEstatus == false).Select(x => x.FacturaBalance).SumAsync();

                ventasPorMesDTO arrmes = new ventasPorMesDTO();
                arrmes.ano = FechaInicial.Year;
                arrmes.mes = FechaInicial.Month;
                arrmes.anoMes = FechaInicial.Year.ToString() + "-" + FechaInicial.Month.ToString();
                arrmes.ventasContado = ventaMesContado;
                arrmes.ventasCredito = ventaMesCRedito;

                arrResult.Add(arrmes);
                FechaInicial = FechaInicial.AddMonths(1);
            }

            //var result = await context.Facturas.Where(x => x.FacturaFecha >= FechaInicial)
            //                            .GroupBy(fac => fac.FacturaFecha.Value.Year.ToString() + "-" + fac.FacturaFecha.Value.Month.ToString()+"-"+fac.CondPagoId)
            //                            .Select(grupo => new { fecha = grupo.Key, ano = grupo.Max(fact => fact.FacturaFecha.Value.Year), mes = grupo.Max(fact => fact.FacturaFecha.Value.Month), condicion = grupo.Max(fact => fact.CondPagoId), total = grupo.Sum(fact => fact.FacturaBalance) })
            //                            .OrderBy(result => result.condicion).ThenBy(result => result.ano).ThenBy(result => result.mes).ToListAsync();

            return Ok(
                arrResult
            );
        }
        [HttpGet("BuscarVentasPorArticulo")]
        public async Task<IActionResult> BuscarVentasPorArticulo()
        {
            var FechaInicial = Convert.ToDateTime(DateTime.Today.Year.ToString() + "-" + DateTime.Today.Month.ToString() + "-" + DateTime.Today.Day.ToString()).AddDays(-7);

            var result = await context.FacturaDets.Include(x => x.Factura).Where(x => x.Factura.FacturaEstatus == false && x.Factura.FacturaBalance > 0 && x.Factura.FacturaFecha.Value.Year == DateTime.Today.Year && x.Factura.FacturaFecha.Value.Month == DateTime.Today.Month)
                                        .GroupBy(fac => fac.ArticuloId)
                                        .Select(grupo => new { id = grupo.Key, articuloId = grupo.Max(fact => fact.ArticuloId), total = grupo.Sum(fact => fact.FacturaQty) })
                                        .OrderByDescending(result => result.total).Take(7).ToListAsync();

            List<ventasPorArticuloDTO> ventasPorArt = new List<ventasPorArticuloDTO>();
            decimal totalArtVentas = 0;
            foreach (var item in result)
            {
                var articulo = await context.Articulos.Where(x => x.ArticuloId == item.articuloId).FirstAsync();
                ventasPorArticuloDTO ventasArt = new ventasPorArticuloDTO();
                ventasArt.articuloId = articulo.ArticuloId;
                ventasArt.articuloDesc = articulo.ArticuloDesc;
                ventasArt.articuloCd = articulo.ArticuloCd;
                ventasArt.cantidad = (decimal)item.total;
                totalArtVentas = totalArtVentas + (decimal)item.total;
                ventasPorArt.Add(ventasArt);
            }

            foreach (var item in ventasPorArt)
            {
                item.porcentaje = (decimal)(item.cantidad * 100 / totalArtVentas);
            }
            return Ok(
                ventasPorArt
            );
        }
        [HttpGet("BuscarUltimosCierres")]
        public async Task<IActionResult> BuscarUltimosCierres()
        {
            var FechaInicial = Convert.ToDateTime(DateTime.Today.Year.ToString() + "-" + DateTime.Today.Month.ToString() + "-" + DateTime.Today.Day.ToString()).AddDays(-7);

            var result = await context.CierreCajas.Include(x => x.Usuario).Where(x => x.CierreCajaFechaHora >= FechaInicial && x.CierreCajaCerrada == true )
                                        .Select( x  => new { fecha = x.CierreCajaFechaHora, dia = x.CierreCajaFechaHora.Value.Day, mes = x.CierreCajaFechaHora.Value.Month, usuario = x.Usuario.UsuarioNombre, monto = Convert.ToDecimal(x.CierreCajaMonto).ToString("0,0.00", CultureInfo.InvariantCulture), efectivo = Convert.ToDecimal(x.CierreCajaEfectivoSistema).ToString("0,0.00", CultureInfo.InvariantCulture) })
                                        .OrderByDescending(result => result.fecha).Take(6).ToListAsync();

            
            return Ok(
                result
            );
        }
    }
}
