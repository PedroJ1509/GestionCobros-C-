using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using JaMPeApp.DTOs;
using JaMPeApp.Models;
using System.Globalization;
namespace JaMPeApp.Controllers
{
    [ApiController]
    [Authorize(AuthenticationSchemes = CookieAuthenticationDefaults.AuthenticationScheme)]
    public class AnalisisCostoControllercs : Controller
    {
        private readonly GestionEmpContext context;

        public AnalisisCostoControllercs(GestionEmpContext context)
        {
            this.context = context;
        }
        [HttpGet("ListadoArticuloAnalisisCosto")]
        public async Task<List<listadoArticuloAnalisisCostoDTO>> Articulos()
        {
            var result = new List<listadoArticuloAnalisisCostoDTO>();

            var query = (
                from data in context.ArticuloAnalisisCostos
                from articulo in context.Articulos.Where(u => u.ArticuloId == data.ArticuloId)
                select new listadoArticuloAnalisisCostoDTO
                {
                    ArticuloAnalisisCostoId = data.ArticuloAnalisisCostoId,
                    Fecha = Convert.ToDateTime(data.Fecha).ToString("dd/MM/yyyy"),
                    ArticuloId = data.ArticuloId,
                    CodigoDesc = articulo.ArticuloDesc,
                    TotalCosto = Convert.ToDecimal(data.TotalCosto).ToString("0,0.0", CultureInfo.InvariantCulture),
                    CostoUnidad = Convert.ToDecimal(data.CostoUnd).ToString("0,0.0", CultureInfo.InvariantCulture),
                    Precio = Convert.ToDecimal(data.CostoUnd * (1 + (data.Ganancia/100))).ToString("0,0.0", CultureInfo.InvariantCulture),
                    CantidadTotal = Convert.ToDecimal(data.Cantidad).ToString("0,0.0", CultureInfo.InvariantCulture),
                    EstadoCerrada = data.Estado,
                }
            );
            result = await query.OrderByDescending(x => x.ArticuloAnalisisCostoId).ToListAsync();

            return result;
        }
        [HttpGet("ListadoArticuloAnalisisCosto/{pagina}/{siCambio}/{totalRegistros}/{cadenaFiltro}")]
        public async Task<IActionResult> Articulos( int pagina, int siCambio, int totalRegistros, string cadenaFiltro)
        {
            var result = new List<listadoArticuloAnalisisCostoDTO>();

            int cantidadRegistroPorPagina = 10;

            var query = (
                from data in context.ArticuloAnalisisCostos
                from articulo in context.Articulos.Where(u => u.ArticuloId == data.ArticuloId && u.ArticuloSiKit == true && (cadenaFiltro != "*" ? (u.ArticuloCd + u.ArticuloDesc + u.ArticuloPartNo).Contains(cadenaFiltro) : true))
                select new listadoArticuloAnalisisCostoDTO
                {
                    ArticuloAnalisisCostoId = data.ArticuloAnalisisCostoId,
                    Fecha = Convert.ToDateTime(data.Fecha).ToString("dd/MM/yyyy"),
                    ArticuloId = data.ArticuloId,
                    CodigoDesc = articulo.ArticuloDesc,
                    TotalCosto = Convert.ToDecimal(data.TotalCosto).ToString("0,0.0", CultureInfo.InvariantCulture),
                    CostoUnidad = Convert.ToDecimal(data.CostoUnd).ToString("0,0.0", CultureInfo.InvariantCulture),
                    Precio = Convert.ToDecimal(data.CostoUnd * (1 + (data.Ganancia / 100))).ToString("0,0.0", CultureInfo.InvariantCulture),
                    CantidadTotal = Convert.ToDecimal(data.Cantidad).ToString("0,0.0", CultureInfo.InvariantCulture),
                    EstadoCerrada = data.Estado,
                }
            );

            if (siCambio == 1)
            {
                totalRegistros = await query.CountAsync();
            }

            result = await query.OrderByDescending(x => x.ArticuloAnalisisCostoId).Skip((pagina - 1) * cantidadRegistroPorPagina).Take(cantidadRegistroPorPagina).ToListAsync();


            return Ok(
                new
                {
                    registros = result,
                    paginaActual = pagina,
                    totalRegistros = totalRegistros,
                    totalPaginas = (int)Math.Ceiling((double)totalRegistros / 10)
                }
            );
        }
        [HttpGet("MenuArticulo/{articuloId}/{cantidad}")]
        public async Task<IActionResult> MenuArticulo(int articuloId, string cantidad)
        {
            var result = new List<articuloAnalisisCostoDetDTO>();

            var identity = User.Claims.Where(x => x.Type == "Almacen_ID").FirstOrDefault();
            var AlmacenId = identity.Value;

            var artic = await context.Articulos.Where(x => x.ArticuloId == articuloId).FirstOrDefaultAsync();

            var ratio = await context.ArticuloUnidads.Where(x => x.ArticuloId == articuloId && x.UnidadId == artic.UnidadId).Select( x => x.ArticuloUnidadRatio).FirstAsync();


            var query = (
                from data in context.ArticuloPorKits.Where(x => x.ArticuloIdPadre == articuloId)
                from articulo in context.Articulos.Where(u => u.ArticuloId == data.ArticuloIdHijo && u.ArticuloStatus == true)
                from unidad in context.Unidads.Where(u => u.UnidadId == data.UnidadId)
                from artAlmacen in context.ArticuloAlmacens.Where(x => x.AlmacenId == Convert.ToInt32(AlmacenId) && x.ArticuloId== articulo.ArticuloId)
                from articuloUnidad in context.ArticuloUnidads.Where(x => x.ArticuloId == articulo.ArticuloId && x.UnidadId == data.UnidadId)
                from unidadRatio in context.ArticuloUnidads.Where(x => x.ArticuloId == articulo.ArticuloId && x.UnidadId == articulo.UnidadId)
                select new articuloAnalisisCostoDetDTO
                {
                    ArticuloPorKitId = data.ArticuloPorKitId,
                    ArticuloDesc = articulo.ArticuloDesc,
                    ArticuloId = articulo.ArticuloId,
                    UnidadDesc = unidad.UnidadDesc,
                    Existencia = Convert.ToDecimal(artAlmacen.ArticuloAlmacenExistencia * articuloUnidad.ArticuloUnidadRatio).ToString("0,0.00", CultureInfo.InvariantCulture),
                    cantidad = Convert.ToDecimal(data.ArticuloPorKitCant * Convert.ToDouble(cantidad)).ToString("0,0.00", CultureInfo.InvariantCulture),
                    CostoUnidad = Convert.ToDecimal((articulo.ArticuloCosto /  (unidadRatio.ArticuloUnidadRatio* articuloUnidad.ArticuloUnidadRatio))).ToString("0,0.00", CultureInfo.InvariantCulture),
                    TotalCosto = Convert.ToDecimal((data.ArticuloPorKitCant * Convert.ToDouble(cantidad)) * (articulo.ArticuloCosto / (unidadRatio.ArticuloUnidadRatio * articuloUnidad.ArticuloUnidadRatio))).ToString("0,0.00", CultureInfo.InvariantCulture),
                    TotalCostoExistencia = Convert.ToDecimal((artAlmacen.ArticuloAlmacenExistencia * articuloUnidad.ArticuloUnidadRatio) * (articulo.ArticuloCosto / (unidadRatio.ArticuloUnidadRatio * articuloUnidad.ArticuloUnidadRatio))).ToString("0,0.00", CultureInfo.InvariantCulture),
                    ExistenciaFaltante = ((artAlmacen.ArticuloAlmacenExistencia * articuloUnidad.ArticuloUnidadRatio) - (data.ArticuloPorKitCant * Convert.ToDouble(cantidad)) > 0) ? "0.0" : Math.Abs(Convert.ToDecimal((artAlmacen.ArticuloAlmacenExistencia * articuloUnidad.ArticuloUnidadRatio) - (data.ArticuloPorKitCant * Convert.ToDouble(cantidad)))).ToString("0,0.00", CultureInfo.InvariantCulture),
                    TotalCostoExistenciaFaltante = ((artAlmacen.ArticuloAlmacenExistencia * articuloUnidad.ArticuloUnidadRatio) - (data.ArticuloPorKitCant * Convert.ToDouble(cantidad)) > 0) ? "0.0" : Math.Abs(Convert.ToDecimal((articulo.ArticuloCosto / (unidadRatio.ArticuloUnidadRatio * articuloUnidad.ArticuloUnidadRatio)) * ((artAlmacen.ArticuloAlmacenExistencia * articuloUnidad.ArticuloUnidadRatio) - (data.ArticuloPorKitCant * Convert.ToDouble(cantidad))))).ToString("0,0.00", CultureInfo.InvariantCulture),
                    TotalCostoTotales = (data.ArticuloPorKitCant * Convert.ToDouble(cantidad)) * (articulo.ArticuloCosto / (unidadRatio.ArticuloUnidadRatio * articuloUnidad.ArticuloUnidadRatio)),
                    CostoUnidadTotales = (articulo.ArticuloCosto / (unidadRatio.ArticuloUnidadRatio * articuloUnidad.ArticuloUnidadRatio)),
                    TotalCostoExistenciaFaltanteTotales = ((artAlmacen.ArticuloAlmacenExistencia * articuloUnidad.ArticuloUnidadRatio) - (data.ArticuloPorKitCant * Convert.ToDouble(cantidad)) > 0) ?  0 : (articulo.ArticuloCosto / (unidadRatio.ArticuloUnidadRatio * articuloUnidad.ArticuloUnidadRatio)) * ((artAlmacen.ArticuloAlmacenExistencia * articuloUnidad.ArticuloUnidadRatio) - (data.ArticuloPorKitCant * Convert.ToDouble(cantidad)))
                }
            );
 

            result = await query.ToListAsync();

            double? TotalCostoTotales = 0;
            double? CostoUnidadTotales = 0;
            double? TotalCostoExistenciaFaltanteTotales = 0;

            foreach (var item in result)
            {
                TotalCostoTotales = TotalCostoTotales + item.TotalCostoTotales;
                CostoUnidadTotales = CostoUnidadTotales + item.CostoUnidadTotales;
                TotalCostoExistenciaFaltanteTotales = TotalCostoExistenciaFaltanteTotales + Convert.ToDouble(Math.Abs((decimal)item.TotalCostoExistenciaFaltanteTotales));
            }

            return Ok(
                new
                {
                    registros = result,
                    TotalCostoTotales = Convert.ToDecimal(TotalCostoTotales).ToString("0,0.00", CultureInfo.InvariantCulture),
                    CostoUnidadTotales = Convert.ToDecimal(TotalCostoTotales/ Convert.ToDouble(cantidad)).ToString("0,0.00", CultureInfo.InvariantCulture),
                    TotalCostoExistenciaFaltanteTotales = Convert.ToDecimal(TotalCostoExistenciaFaltanteTotales).ToString("0,0.00", CultureInfo.InvariantCulture),
                }
            );
        }
    }
}
