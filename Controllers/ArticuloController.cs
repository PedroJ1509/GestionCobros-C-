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
    public class ArticuloController : Controller
    {
        private readonly GestionEmpContext context;

        public ArticuloController(GestionEmpContext context)
        {
            this.context = context;
        }
        [HttpGet("ListadoArticulos")]
        public async Task<List<listadoArticuloDTO>> Articulos()
        {
            var result = new List<listadoArticuloDTO>();

            var identity = User.Claims.Where(x => x.Type == "Almacen_ID").FirstOrDefault();
            var AlmacenId = identity.Value;

            var query = (
                from data in context.Articulos
                from unidad in context.Unidads.Where(u => u.UnidadId == data.UnidadId).DefaultIfEmpty()
                from artAlmacen in context.ArticuloAlmacens.Where(u => u.ArticuloId == data.ArticuloId && u.AlmacenId == Convert.ToInt32(AlmacenId)).DefaultIfEmpty()
                select new listadoArticuloDTO
                {
                    ArticuloID = data.ArticuloId,
                    ArticuloCodigo = data.ArticuloCd,
                    ArticuloDescripcion = data.ArticuloDesc,
                    ArticuloParteNo = data.ArticuloPartNo,
                    ArticuloUdm = unidad.UnidadDesc,
                    ArticuloUbicacion = artAlmacen.ArticuloAlmacenUbicacion,
                    ArticuloExistencia = String.IsNullOrEmpty(artAlmacen.ArticuloAlmacenExistencia.ToString()) ? "0" : Convert.ToDecimal(artAlmacen.ArticuloAlmacenExistencia) == 0 ? "0" : Convert.ToDecimal(artAlmacen.ArticuloAlmacenExistencia).ToString("0,0.0", CultureInfo.InvariantCulture),
                    ArticuloCosto = String.IsNullOrEmpty(data.ArticuloCosto.ToString()) ? "0" : Convert.ToDecimal(data.ArticuloCosto) == 0 ? "0" : Convert.ToDecimal(data.ArticuloCosto).ToString("0,0.0", CultureInfo.InvariantCulture),
                    ArticuloPrecios = "",
                    ArticuloEstado = data.ArticuloStatus,
                }
            );
            result = await query.OrderBy(x => x.ArticuloDescripcion).ToListAsync();

            foreach (var item in result)
            {
                List<Precio>precios = await context.Precios.Where(x => x.ArticuloId == item.ArticuloID).OrderBy(x => x.PrecioNo).ToListAsync();
                string listaPrecio = "";
                decimal precioUnit = 0;
                string precioU = "";
                for (Int32 i = 0; i < precios.Count; i++)
                {
                    precioUnit = Convert.ToDecimal(precios[i].PrecioMonto);
                    precioU = precioUnit == 0 ? "0" : Convert.ToDecimal(precios[i].PrecioMonto).ToString("0,0.0", CultureInfo.InvariantCulture);
                    if (i == precios.Count -1)
                    {
                        listaPrecio = listaPrecio + precioU;
                    }else
                    {
                        listaPrecio = listaPrecio + precioU + ", ";
                    }
                }

                item.ArticuloPrecios = listaPrecio;
            }

            return result;
        }

        [HttpGet("ArticulosInventario")]
        public async Task<IActionResult> ArticulosInventario()
        {
            try
            {
                var result = new List<articuloInventarioDTO>();

                var identity = User.Claims.Where(x => x.Type == "Almacen_ID").FirstOrDefault();
                var AlmacenId = identity.Value;

                var query = (
                    from data in context.Articulos.Where(x => x.ArticuloInventario == true && x.ArticuloStatus == true)
                    from unidad in context.Unidads.Where(u => u.UnidadId == data.UnidadId)
                    select new articuloInventarioDTO
                    {
                        ArticuloID = data.ArticuloId,
                        ArticuloCodigo = data.ArticuloCd,
                        ArticuloDescripcion = data.ArticuloDesc,
                        unindadId = unidad.UnidadId,
                        unidadDesc = unidad.UnidadDesc
                    }
                );
                result = await query.OrderBy(x => x.ArticuloDescripcion).ToListAsync();

                return Ok(result);
            }
            catch (Exception ex)
            {

                return NotFound();
            }
        }

        [HttpGet("ArticulosIngredientes")]
        public async Task<IActionResult> ArticulosIngredientes()
        {
            try
            {
                var result = new List<articuloInventarioDTO>();

                var identity = User.Claims.Where(x => x.Type == "Almacen_ID").FirstOrDefault();
                var AlmacenId = identity.Value;

                var query = (
                    from data in context.Articulos.Where(x => x.ArticuloSiKit == true && x.ArticuloStatus == true)
                    from unidad in context.Unidads.Where(u => u.UnidadId == data.UnidadId)
                    select new articuloInventarioDTO
                    {
                        ArticuloID = data.ArticuloId,
                        ArticuloCodigo = data.ArticuloCd,
                        ArticuloDescripcion = data.ArticuloDesc,
                        unindadId = unidad.UnidadId,
                        unidadDesc = unidad.UnidadDesc
                    }
                );
                result = await query.OrderBy(x => x.ArticuloDescripcion).ToListAsync();

                return Ok(result);
            }
            catch (Exception ex)
            {

                return NotFound();
            }
        }

        [HttpGet("AllArticulos")]
        public async Task<IActionResult> AllArticulos()
        {
            
            var result = await context.Articulos.Where(x => x.ArticuloStatus == true).Select(x => new { x.ArticuloId, x.ArticuloDesc}).ToListAsync();

            return Ok( result);
        }
        [HttpPost("PreciosArticulo/{articuloId}")]
        public async Task<ActionResult> PreciosArticulo(int articuloId)
        {
            var result = new List<precioDTO>();

            var general = await context.Generals.FirstAsync();

            List<Precio> lisPrecio = await context.Precios.Where(x => x.ArticuloId == articuloId).ToListAsync();

            int cantPrecio = lisPrecio.Count();

            if (cantPrecio < general.GeneralCantPrecios)
            {
                while (cantPrecio < general.GeneralCantPrecios)
                {
                    var newPrecio = new Precio();
                    newPrecio.ArticuloId = articuloId;
                    newPrecio.PrecioNo = cantPrecio + 1;
                    newPrecio.PrecioMonto = 0;
                    newPrecio.PrecioGanancia = 0;
                    newPrecio.PrecioComision = 0;
                    newPrecio.PrecioCodigo = "";
                    context.Add(newPrecio );
                    context.SaveChangesAsync();
                    cantPrecio++;
                }
            }

            var query = (
                from data in context.Precios.Where(x => x.ArticuloId == articuloId)
                select new precioDTO
                {
                    PrecioId = data.PrecioId,
                    PrecioNo = data.PrecioNo,
                    PrecioMonto = data.PrecioMonto,
                    PrecioComision = data.PrecioComision,
                    PrecioGanancia = data.PrecioGanancia,
                    PrecioCodigo = data.PrecioCodigo,
                    ArticuloId = data.ArticuloId
                }
            );
            result = await query.OrderBy(x => x.PrecioNo).ToListAsync();

            return Ok(result);
        }
        [HttpGet("AlmacenesArticulo/{articuloId}")]
        public async Task<List<almacenesArticulosDTO>> AlmacenesArticulo(int articuloId)
        {
            var result = new List<almacenesArticulosDTO>();


            var query = (
                from data in context.ArticuloAlmacens.Where(x => x.ArticuloId == articuloId)
                from almacen in context.Almacens.Where(x => x.AlmacenId == data.AlmacenId).DefaultIfEmpty()
                select new almacenesArticulosDTO
                {
                    almadenId = data.AlmacenId,
                    articuloId = data.ArticuloId,
                    almadenDesc = almacen.AlmacenDesc.ToUpper(),
                    ubicacion = data.ArticuloAlmacenUbicacion.ToUpper(),
                    existencia = Convert.ToDecimal(data.ArticuloAlmacenExistencia).ToString("0,0.0", CultureInfo.InvariantCulture),
                    cantMinima = data.ArticuloAlmacenCantReOrden,
                    cantMaxima = data.ArticuloAlmacenCantMaxima
                }
            ); ;
            result = await query.OrderBy(x => x.almadenDesc).ToListAsync();

            return result;
        }
        [HttpGet("UnidadesMedidaArticulo/{articuloId}")]
        public async Task<List<ArticuloUnidadesDTO>> UnidadesMedidaArticulo(int articuloId)
        {
            var result = new List<ArticuloUnidadesDTO>();


            var query = (
                from data in context.ArticuloUnidads.Where(x => x.ArticuloId == articuloId)
                from unidad in context.Unidads.Where(x => x.UnidadId == data.UnidadId)
                from articulo in context.VArticulos.Where(x => x.ArticuloId == data.ArticuloId)
                select new ArticuloUnidadesDTO
                {
                    unidadId = data.UnidadId,
                    articuloId = data.ArticuloId,
                    unidadDesc = unidad.UnidadDesc.ToUpper(),
                    cantidad = Convert.ToDecimal(articulo.ArticuloExistencia * data.ArticuloUnidadRatio).ToString("0,0.0", CultureInfo.InvariantCulture),
                    ratio = data.ArticuloUnidadRatio.ToString()
                }
            ); ;
            result = await query.OrderBy(x => x.unidadDesc).ToListAsync();

            return result;
        }
        [HttpGet("ComprasArticulo/{articuloId}")]
        public async Task<List<comprasArticuloDTO>> ComprasArticulo(int articuloId)
        {
            var result = new List<comprasArticuloDTO>();


            var query = (
                from compraDet in context.CompraDets.Where(x => x.ArticuloId == articuloId)
                from compra in context.Compras.Where(x => x.CompraId == compraDet.CompraId)
                from suplidor in context.Suplidors.Where(x => x.SuplidorId == compra.SuplidorId)
                from unidad in context.Unidads.Where(x =>x.UnidadId == compraDet.UnidadId)
                from articuloUnidad in context.ArticuloUnidads.Where(x => x.UnidadId == unidad.UnidadId && x.ArticuloId == articuloId)
                select new comprasArticuloDTO
                {
                    fecha = compra.CompraFecha.ToString(),
                    suplidor = suplidor.SuplidorNombre.ToUpper(),
                    unidad = unidad.UnidadDesc.ToUpper(),
                    cantidad = Convert.ToDecimal(compraDet.CompraQty).ToString("0,0.0", CultureInfo.InvariantCulture),
                    costo = Convert.ToDecimal(compraDet.CompraPrecio * Convert.ToDecimal(articuloUnidad.ArticuloUnidadRatio)).ToString("0,0.0", CultureInfo.InvariantCulture)
                }
            );
            result = await query.OrderByDescending(x => x.fecha).ToListAsync();

            return result;
        }


        [HttpGet("ArticulosKit/{articuloId}")]
        public async Task<List<articuloListKitDTO>> ArticulosKit(int articuloId)
        {
            var result = new List<articuloListKitDTO>();

            var query = (
                from artKit in context.ArticuloPorKits.Where(x => x.ArticuloIdPadre == articuloId)
                from art in context.Articulos.Where(x => x.ArticuloId == artKit.ArticuloIdHijo)
                from unidad in context.Unidads.Where(x => x.UnidadId == artKit.UnidadId).DefaultIfEmpty()
                select new articuloListKitDTO
                {
                    articuloKitId = artKit.ArticuloPorKitId,
                    articuloCd = art.ArticuloCd.ToUpper(),
                    articuloDesc = art.ArticuloDesc.ToUpper(),
                    cantidad = Convert.ToDecimal(artKit.ArticuloPorKitCant).ToString("0,0.00", CultureInfo.InvariantCulture),
                    unidadDesc = unidad.UnidadDesc.ToUpper()
                }
            );
            result = await query.OrderBy(x => x.articuloDesc).ToListAsync();

            return result;
        }

        [HttpGet("UltimoArticulo")]
        public async Task<Int32?> UltimoArticulo()
        {
            Int32? result = 0;

            var general = await context.Generals.FirstAsync();

            result = general.GeneralUltimoArticulo + 1;

            return result;
        }
        [HttpGet("Articulo/{articuloId}")]
        public async Task<articuloDTO> GetArticulo(int articuloId)
        {
            articuloDTO articulo = new articuloDTO();

            try
            {
                var result = await context.VArticulos.Where(x => x.ArticuloId == articuloId).FirstOrDefaultAsync();

                if (result != null)
                {
                    articulo.ArticuloId = result.ArticuloId;
                    articulo.ArticuloCd = result.ArticuloCd;
                    articulo.ArticuloPartNo = result.ArticuloPartNo;
                    articulo.ArticuloDesc = result.ArticuloDesc;
                    articulo.MarcaId = result.MarcaId;
                    articulo.ModeloId = result.ModeloId;
                    articulo.ArticuloCosto = result.ArticuloCosto;
                    articulo.ArticuloCostoProm = result.ArticuloCostoProm == 0 ? "0" : Convert.ToDecimal(result.ArticuloCostoProm).ToString("0,0.0", CultureInfo.InvariantCulture) ;
                    articulo.ArticuloStatus = result.ArticuloStatus;
                    articulo.UnidadId = result.UnidadId;
                    articulo.ArticuloConvertible = result.ArticuloConvertible;
                    articulo.ArticuloSiItbis = result.ArticuloSiItbis;
                    articulo.ArticuloStatus = result.ArticuloStatus;
                    articulo.DepartamentoId = result.DepartamentoId;
                    articulo.ArticuloInventario = result.ArticuloInventario;
                    articulo.ArticuloSiItbisincluido = result.ArticuloSiItbisincluido;
                    articulo.ArticuloFabricado = result.ArticuloFabricado;
                    articulo.ArticuloCostoCodigo = result.ArticuloCostoCodigo;
                    articulo.ArticuloSiKit = result.ArticuloSiKit;
                    articulo.ArticuloGanancia2 = result.ArticuloGanancia2;
                    articulo.ArticuloGananciaMinima = result.ArticuloGananciaMinima;
                    articulo.ArticuloSiVencimiento = result.ArticuloSiVencimiento;
                    articulo.ArticuloSiComanda = result.ArticuloSiComanda;
                    articulo.ArticuloExistencia = result.ArticuloExistencia;
                    articulo.ArticuloImgRuta = result.ArticuloImgRuta;
                    articulo.ArticuloSiFactNegativo = result.ArticuloSiFactNegativo;
                    articulo.ArticuloSiGuarnicion = result.ArticuloSiGuarnicion;
                    articulo.ArticuloSiPeso = result.ArticuloSiPeso;
                }
            }
            catch (Exception)
            {
            }

            return articulo;
        }
        [HttpPost("Articulo")]
        public async Task<ActionResult> PostArticulo(articuloDTO model)
        {
            try
            {
                var codigoExiste = await context.Articulos.Where(x => x.ArticuloCd == model.ArticuloCd).FirstOrDefaultAsync();

                if (codigoExiste != null)
                {
                    return NotFound("Código de artículo ya está asignada a otro articulo (" + codigoExiste.ArticuloDesc.ToUpper() + ").");
                }

                var general = await context.Generals.FirstAsync();

                if ((general.GeneralUltimoArticulo+1).ToString() == model.ArticuloCd.ToString())
                {
                    general.GeneralUltimoArticulo = general.GeneralUltimoArticulo + 1;
                    context.Generals.Update(general);
                    await context.SaveChangesAsync();
                }


                Articulo newArticulo = new Articulo();
                newArticulo.ArticuloId = model.ArticuloId;
                newArticulo.ArticuloCd = model.ArticuloCd;
                newArticulo.ArticuloPartNo = model.ArticuloPartNo;
                newArticulo.ArticuloDesc = model.ArticuloDesc.ToUpper();
                newArticulo.MarcaId = model.MarcaId;
                newArticulo.ModeloId = model.ModeloId;
                newArticulo.ArticuloCosto = model.ArticuloCosto;
                newArticulo.ArticuloCostoProm = 0;
                newArticulo.ArticuloStatus = model.ArticuloStatus;
                newArticulo.UnidadId = model.UnidadId;
                newArticulo.ArticuloConvertible = model.ArticuloConvertible;
                newArticulo.ArticuloSiItbis = model.ArticuloSiItbis;
                newArticulo.ArticuloStatus = model.ArticuloStatus;
                newArticulo.DepartamentoId = model.DepartamentoId;
                newArticulo.ArticuloInventario = model.ArticuloInventario;
                newArticulo.ArticuloSiItbisincluido = model.ArticuloSiItbisincluido;
                newArticulo.ArticuloFabricado = model.ArticuloFabricado;
                newArticulo.ArticuloCostoCodigo = model.ArticuloCostoCodigo;
                newArticulo.ArticuloSiKit = model.ArticuloSiKit;
                newArticulo.ArticuloGanancia2 = model.ArticuloGanancia2;
                newArticulo.ArticuloGananciaMinima = model.ArticuloGananciaMinima;
                newArticulo.ArticuloSiVencimiento = model.ArticuloSiVencimiento;
                newArticulo.ArticuloSiComanda = model.ArticuloSiComanda;
                newArticulo.ArticuloImgRuta = model.ArticuloImgRuta;
                newArticulo.ArticuloSiFactNegativo = model.ArticuloSiFactNegativo;
                newArticulo.ArticuloSiGuarnicion = model.ArticuloSiGuarnicion;
                newArticulo.ArticuloSiPeso = model.ArticuloSiPeso;
                context.Add(newArticulo);
                await context.SaveChangesAsync();

                ArticuloUnidad articulounidad = new ArticuloUnidad();
                articulounidad.ArticuloId = newArticulo.ArticuloId;
                articulounidad.UnidadId = Convert.ToInt32(model.UnidadId);
                articulounidad.ArticuloUnidadRatio = 1;
                context.Add(articulounidad);
                await context.SaveChangesAsync();


                List<Precio> listPrecio = await context.Precios.Where(x => x.ArticuloId == newArticulo.ArticuloId).ToListAsync();

                int nPrecio = listPrecio.Count();

                while (nPrecio < Convert.ToInt16(general.GeneralCantPrecios))
                {
                    Precio newPrecio = new Precio();
                    newPrecio.ArticuloId = newArticulo.ArticuloId;
                    newPrecio.PrecioNo = nPrecio + 1;
                    newPrecio.PrecioMonto = 0;
                    newPrecio.PrecioGanancia = 0;
                    newPrecio.PrecioComision = 0;
                    newPrecio.PrecioCodigo = "";
                    context.Add(newPrecio);
                    await context.SaveChangesAsync();
                    nPrecio++;
                }
                List<int> listAlmacen = await context.ArticuloAlmacens.Where(x => x.ArticuloId == newArticulo.ArticuloId).Select(x => x.ArticuloId).ToListAsync();

                List<Almacen> almacenes = await context.Almacens.Where(x => !listAlmacen.Contains(x.AlmacenId)).ToListAsync();


                var identity = User.Claims.Where(x => x.Type == "Almacen_ID").FirstOrDefault();
                var almacenId = identity.Value;

                foreach (var almacen in almacenes)
                {
                    double? existenciaArt = 0;
                    if (Convert.ToInt32(almacenId) == almacen.AlmacenId)
                    {
                        existenciaArt = model.ArticuloExistencia;
                    }
                    ArticuloAlmacen articuloAlmn = new ArticuloAlmacen();
                    articuloAlmn.ArticuloId = newArticulo.ArticuloId;
                    articuloAlmn.AlmacenId = almacen.AlmacenId;
                    articuloAlmn.ArticuloAlmacenExistencia = existenciaArt;
                    articuloAlmn.ArticuloAlmacenCantMaxima = 0;
                    articuloAlmn.ArticuloAlmacenCantReOrden = 0;
                    articuloAlmn.ArticuloAlmacenUbicacion = "";
                    context.Add(articuloAlmn);
                    await context.SaveChangesAsync();
                }


                var articuloAlmacen = await context.ArticuloAlmacens.Where(x => x.AlmacenId == Convert.ToInt32(almacenId)).FirstOrDefaultAsync();
                articuloAlmacen.ArticuloAlmacenExistencia = model.ArticuloExistencia;
                context.Update(articuloAlmacen);
                await context.SaveChangesAsync();

                return Ok(newArticulo);
            }
            catch (Exception)
            {
                return NotFound();
            }
        }
        [HttpPost("CambiarPrecioArticulo")]
        public async Task<ActionResult> CambiarPrecioArticulo(precioArticuloDTO model)
        {
            try
            {
                var precio = await context.Precios.Where(x => x.PrecioId == Convert.ToInt32(model.precioId)).FirstOrDefaultAsync();
                precio.PrecioMonto = Convert.ToDouble(model.precioMonto);
                precio.PrecioGanancia = model.precioGanancia;
                precio.PrecioComision = model.precioComision;
                precio.PrecioCodigo = model.precioCodigo;
                context.Update(precio);
                await context.SaveChangesAsync();

                return NoContent();

            }
            catch (Exception)
            {
                return NotFound();
            }
        }
        [HttpPost("ArticuloKit")]
        public async Task<ActionResult> ArticuloKit(articuloKitDTO model)
        {
            try
            {
                var articuloKit = await context.ArticuloPorKits.Where(x => x.ArticuloIdPadre == model.articuloIdPadre && x.ArticuloIdHijo == model.articuloIdHijo).FirstOrDefaultAsync();

                if (articuloKit != null)
                {
                    return BadRequest("Artículo ya existe en la lista.");
                }

                ArticuloPorKit artKit = new ArticuloPorKit();
                artKit.ArticuloIdPadre = model.articuloIdPadre;
                artKit.ArticuloIdHijo = model.articuloIdHijo;
                artKit.ArticuloPorKitCant = model.cantidad;
                artKit.UnidadId = model.unidadId;
                context.Add(artKit);
                await context.SaveChangesAsync();

                return NoContent();

            }
            catch (Exception)
            {
                return NotFound();
            }
        }
        [HttpPost("ActualizaArticuloAlmacen")]
        public async Task<ActionResult> ActualizaArticuloAlmacen(almacenesArticulosDTO model)
        {
            try
            {
                var almacen = await context.ArticuloAlmacens.Where(x => x.ArticuloId == model.articuloId && x.AlmacenId == model.almadenId).FirstOrDefaultAsync();
                almacen.ArticuloAlmacenUbicacion = model.ubicacion;
                almacen.ArticuloAlmacenCantMaxima = model.cantMaxima;
                almacen.ArticuloAlmacenCantReOrden = model.cantMinima;
                context.Update(almacen);
                await context.SaveChangesAsync();

                return NoContent();

            }
            catch (Exception)
            {
                return NotFound();
            }
        }
        [HttpPost("UnidadArticulo")]
        public async Task<ActionResult> PostUnidadArticulo(unidadArticuloDTO model)
        {
            try
            {
                bool puedeBorrar = true;
                var uniFactDet = await context.FacturaDets.Where(x => x.UnidadId == model.unidadId).FirstOrDefaultAsync();
                

                var articuloUnidad = await context.ArticuloUnidads.Where(x => x.UnidadId == model.unidadId && x.ArticuloId == model.articuloId).FirstOrDefaultAsync();

                if (articuloUnidad != null)
                {
                    if (uniFactDet != null)
                    {
                        puedeBorrar = false;
                    }

                    var uniCompDet = await context.CompraDets.Where(x => x.UnidadId == model.unidadId).FirstOrDefaultAsync();
                    if (uniCompDet != null)
                    {
                        puedeBorrar = false;
                    }

                    var uniMatArt = await context.MaterialesPorArticulos.Where(x => x.UnidadId == model.unidadId).FirstOrDefaultAsync();
                    if (uniMatArt != null)
                    {
                        puedeBorrar = false;
                    }

                    var uniNotCr = await context.NotaCrDets.Where(x => x.UnidadId == model.unidadId).FirstOrDefaultAsync();
                    if (uniNotCr != null)
                    {
                        puedeBorrar = false;
                    }

                    var uniNOtDb = await context.NotaDbDets.Where(x => x.UnidadId == model.unidadId).FirstOrDefaultAsync();
                    if (uniNOtDb != null)
                    {
                        puedeBorrar = false;
                    }

                    var uniCotDet = await context.CotizacionDets.Where(x => x.UnidadId == model.unidadId).FirstOrDefaultAsync();
                    if (uniCotDet != null)
                    {
                        puedeBorrar = false;
                    }

                    if (puedeBorrar == false)
                    {
                        return NotFound("Esta Unidad de Medida no puede ser Modificada, ha sido utilizada con este Artículo...");
                    }

                    articuloUnidad.ArticuloUnidadRatio = model.ratio;
                    context.Update(articuloUnidad);
                    await context.SaveChangesAsync();
                }
                else
                {
                    ArticuloUnidad unidad = new ArticuloUnidad();
                    unidad.UnidadId = model.unidadId;
                    unidad.ArticuloId = model.articuloId;
                    unidad.ArticuloUnidadRatio = model.ratio;
                    context.Add(unidad);
                    await context.SaveChangesAsync();
                }

                return NoContent();
            }
            catch (Exception)
            {
                return NotFound();
            }
        }
        [HttpPut("Articulo")]
        public async Task<ActionResult> UpdateArticulo(articuloDTO model)
        {
            try
            {
                var codigoExiste = await context.Articulos.Where(x => x.ArticuloCd == model.ArticuloCd && x.ArticuloId != model.ArticuloId).FirstOrDefaultAsync();

                if (codigoExiste != null)
                {
                    return NotFound("Código de artículo ya está asignada a otro articulo (" + codigoExiste.ArticuloDesc.ToUpper() + ").");
                }

                Articulo newArticulo = await context.Articulos.Where(x => x.ArticuloId == model.ArticuloId).FirstOrDefaultAsync();


                newArticulo.ArticuloCd = model.ArticuloCd;
                newArticulo.ArticuloPartNo = model.ArticuloPartNo;
                newArticulo.ArticuloDesc = model.ArticuloDesc.ToUpper();
                newArticulo.MarcaId = model.MarcaId;
                newArticulo.ModeloId = model.ModeloId;
                newArticulo.ArticuloStatus = model.ArticuloStatus;
                newArticulo.UnidadId = model.UnidadId;
                newArticulo.ArticuloConvertible = model.ArticuloConvertible;
                newArticulo.ArticuloSiItbis = model.ArticuloSiItbis;
                newArticulo.ArticuloStatus = model.ArticuloStatus;
                newArticulo.DepartamentoId = model.DepartamentoId;
                newArticulo.ArticuloInventario = model.ArticuloInventario;
                newArticulo.ArticuloSiItbisincluido = model.ArticuloSiItbisincluido;
                newArticulo.ArticuloFabricado = model.ArticuloFabricado;
                newArticulo.ArticuloCostoCodigo = model.ArticuloCostoCodigo;
                newArticulo.ArticuloSiKit = model.ArticuloSiKit;
                newArticulo.ArticuloGanancia2 = model.ArticuloGanancia2;
                newArticulo.ArticuloGananciaMinima = model.ArticuloGananciaMinima;
                newArticulo.ArticuloSiVencimiento = model.ArticuloSiVencimiento;
                newArticulo.ArticuloSiComanda = model.ArticuloSiComanda;
                newArticulo.ArticuloImgRuta = model.ArticuloImgRuta;
                newArticulo.ArticuloSiFactNegativo = model.ArticuloSiFactNegativo;
                newArticulo.ArticuloSiGuarnicion = model.ArticuloSiGuarnicion;
                newArticulo.ArticuloSiPeso = model.ArticuloSiPeso;
                context.Update(newArticulo);

                await context.SaveChangesAsync();

                if (Convert.ToInt16(model.UnidadIdAnt) != model.UnidadId)
                {
                    double? ratio;
                    var articuloUnidads = await context.ArticuloUnidads.Where(x => x.ArticuloId == model.ArticuloId && x.UnidadId == model.UnidadId).FirstOrDefaultAsync();

                    if (articuloUnidads != null)
                    {
                        ratio = articuloUnidads.ArticuloUnidadRatio;
                    }
                    else
                    {
                        ratio = 1;
                        ArticuloUnidad newArticuloUnidad = new ArticuloUnidad();
                        newArticuloUnidad.ArticuloId = model.ArticuloId;
                        newArticuloUnidad.UnidadId = Convert.ToInt16(model.UnidadId);
                        newArticuloUnidad.ArticuloUnidadRatio = (float)(ratio);
                        context.Add(newArticuloUnidad);
                        await context.SaveChangesAsync();
                    }
                    ////Actualizar los costos de los articulos
                    //newArticulo.ArticuloCosto = newArticulo.ArticuloCosto / ratio;
                    //newArticulo.ArticuloCostoProm = newArticulo.ArticuloCostoProm / ratio;
                    //context.Update(newArticulo);
                    //await context.SaveChangesAsync();

                    //var articuloAlmacen = await context.ArticuloAlmacens.Where(x => x.ArticuloId == model.ArticuloId).ToListAsync();
                    ////Actualizaar la existencia de los alamcenes
                    //foreach (var artAlm in articuloAlmacen)
                    //{
                    //    artAlm.ArticuloAlmacenExistencia = artAlm.ArticuloAlmacenExistencia * ratio;
                    //    context.Update(artAlm);
                    //    await context.SaveChangesAsync();
                    //}


                }

                return NoContent();
            }
            catch (Exception)
            {
                return NotFound();
            }
        }
        [HttpDelete("ArticuloKit/{articuloKitId}")]
        public async Task<IActionResult> DelArticuloKit(int articuloKitId)
        {
            try
            {
                var artKit = await context.ArticuloPorKits.Where(x => x.ArticuloPorKitId == articuloKitId).FirstAsync();
                context.Remove(artKit);
                await context.SaveChangesAsync();
                return NoContent();
            }
            catch (System.Exception ex)
            {
                return NotFound(ex.Message);
            }
        }
        //[HttpDelete("Articulo/{articuloId}")]
        //public async Task<IActionResult> DelArticulo(int articuloId)
        //{
        //    try
        //    {

        //        var articuloEnFactura = await context.Facturas.AnyAsync(x => x.ArticuloId == articuloId);
        //        if (articuloEnFactura)
        //        {
        //            return NotFound("Articulo ha sido usado en factura y no puede ser borrado.");
        //        }
        //        var articuloEnCotizacion = await context.Cotizacions.AnyAsync(x => x.ArticuloId == articuloId);
        //        if (articuloEnCotizacion)
        //        {
        //            return NotFound("Articulo ha sido usado en Contizaciones y no puede ser borrado.");
        //        }
        //        var articuloEnReservas = await context.Reservas.AnyAsync(x => x.ArticuloId == articuloId);
        //        if (articuloEnReservas)
        //        {
        //            return NotFound("Articulo ha sido usado en Reservaciones y no puede ser borrado.");
        //        }
        //        var articuloEnPrestamo = await context.Prestamos.AnyAsync(x => x.ArticuloId == articuloId);
        //        if (articuloEnPrestamo)
        //        {
        //            return NotFound("Articulo ha sido usado en Prestamos y no puede ser borrado.");
        //        }
        //        var articuloEnPrepago = await context.Prepagos.AnyAsync(x => x.ArticuloId == articuloId);
        //        if (articuloEnPrepago)
        //        {
        //            return NotFound("Articulo ha sido usado en Prepagos y no puede ser borrado.");
        //        }
        //        context.Entry(new Articulo { ArticuloId = articuloId }).State = EntityState.Deleted;
        //        await context.SaveChangesAsync();
        //        return NoContent();
        //    }
        //    catch (System.Exception ex)
        //    {
        //        return NotFound(ex.Message);
        //    }
        //}
        //[HttpGet("ConsultarRNC/{rnc}")]
        //public async Task<ActionResult> ConsultarRNC(string rnc)
        //{
        //    var result = await context.ArticuloRncs.Where(x => x.ArticuloRnc1 == rnc).FirstOrDefaultAsync();

        //    return Ok(result);
        //}
    }
}
