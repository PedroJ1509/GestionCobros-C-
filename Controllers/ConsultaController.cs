using JaMPeApp.DTOs;
using JaMPeApp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Globalization;
using System.Security.Claims;

namespace JaMPeApp.Controllers
{
    [ApiController]
    [Authorize(AuthenticationSchemes = "Cookies")]
    public class ConsultaController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private readonly GestionEmpContext context;

        public ConsultaController(ILogger<HomeController> logger, GestionEmpContext context)
        {
            _logger = logger;
            this.context = context;
        }

        [HttpGet("/ConsultaVentas")]
        public IActionResult IndexConsultaVentas()
        {
            return View();
        }

        [HttpGet("/ConsultaVentasArticulos")]
        public IActionResult IndexConsultaVentasPorArticulo()
        {
            return View();
        }

        [HttpPost("Ventas")]
        public async Task<List<consultaVentasDTO>> Ventas(consultaVentasFiltroDTO model)
        {
            consultaVentasFiltroDTO model2 = model;
            new List<consultaVentasDTO>();
            DateTime fechaInicio = Convert.ToDateTime(model2.fechaDesde);
            DateTime fechaFinal = Convert.ToDateTime(model2.fechaHasta);
            bool estado = !(model2.estado == "0");
            IQueryable<consultaVentasDTO> query = from x in context.Facturas
                                                  where x.FacturaEstatus == estado && x.FacturaFecha >= fechaInicio && x.FacturaFecha <= fechaFinal && ((model2.tipoComprobante != "0") ? ((int?)x.ComprobanteTipoId == (int?)Convert.ToInt32(model2.tipoComprobante)) : ((int?)x.ComprobanteTipoId >= (int?)0))
                                                  select x into fac
                                                  from cliente in from x in context.Clientes
                                                                  where (int?)x.ClienteId == fac.ClienteId && ((model2.clienteId != "0") ? ((model2.clienteId == "0") ? (x.ClienteId >= 0) : (x.ClienteId == Convert.ToInt32(model2.clienteId))) : (x.ClienteId >= 0))
                                                                  select x
                                                  from condicion in from x in context.CondPagos
                                                                    where (int?)x.CondPagoId == fac.CondPagoId && ((model2.condicionId != "0") ? ((model2.condicionId == "1") ? ((int?)x.CondPagoDias == (int?)0) : ((int?)x.CondPagoDias > (int?)0)) : ((int?)x.CondPagoDias >= (int?)0))
                                                                    select x
                                                  select new consultaVentasDTO
                                                  {
                                                      facturaId = fac.FacturaId,
                                                      facturaNo = fac.FacturaNo,
                                                      fecha = Convert.ToDateTime(fac.FacturaFecha).ToString("dd/MM/yyyy"),
                                                      cliente = ((cliente.ClienteNombre == "") ? ((!string.IsNullOrEmpty(fac.FacturaCliente)) ? fac.FacturaCliente : cliente.ClienteCodigo) : cliente.ClienteNombre.ToUpper()),
                                                      condicionDesc = condicion.CondPagoDesc.ToUpper(),
                                                      comprobante = (string.IsNullOrEmpty(fac.FacturaComprobante) ? "" : fac.FacturaComprobante),
                                                      descuento = Convert.ToDecimal(fac.FacturaDescto).ToString("0,0.0", CultureInfo.InvariantCulture),
                                                      itbis = Convert.ToDecimal(fac.FacturaItbis).ToString("0,0.0", CultureInfo.InvariantCulture),
                                                      ley = Convert.ToDecimal(fac.FacturaMontoImpuesto).ToString("0,0.0", CultureInfo.InvariantCulture),
                                                      total = Convert.ToDecimal(fac.FacturaBalance).ToString("0,0.0", CultureInfo.InvariantCulture)
                                                  };
            return await query.OrderBy((consultaVentasDTO x) => x.facturaNo).ToListAsync();
        }

        [HttpPost("VentasTotales")]
        public async Task<IActionResult> VentasTotales(consultaVentasFiltroDTO model)
        {
            consultaVentasFiltroDTO model2 = model;
            new List<consultaVentasTotalesDTO>();
            new consultaVentasTotalesDTO();
            decimal totalDescuento = default(decimal);
            decimal totalLey = default(decimal);
            decimal totalItbis = default(decimal);
            decimal totalGeneral = default(decimal);
            DateTime fechaInicio = Convert.ToDateTime(model2.fechaDesde);
            DateTime fechaFinal = Convert.ToDateTime(model2.fechaHasta);
            bool estado = !(model2.estado == "0");
            IQueryable<consultaVentasTotalesDTO> query = from x in context.Facturas
                                                         where x.FacturaEstatus == estado && x.FacturaFecha >= fechaInicio && x.FacturaFecha <= fechaFinal && ((model2.tipoComprobante != "0") ? ((int?)x.ComprobanteTipoId == (int?)Convert.ToInt32(model2.tipoComprobante)) : ((int?)x.ComprobanteTipoId >= (int?)0))
                                                         select x into fac
                                                         from cliente in from x in context.Clientes
                                                                         where (int?)x.ClienteId == fac.ClienteId && ((model2.clienteId != "0") ? ((model2.clienteId == "0") ? (x.ClienteId >= 0) : (x.ClienteId == Convert.ToInt32(model2.clienteId))) : (x.ClienteId >= 0))
                                                                         select x
                                                         from condicion in from x in context.CondPagos
                                                                           where (int?)x.CondPagoId == fac.CondPagoId && ((model2.condicionId != "0") ? ((model2.condicionId == "1") ? ((int?)x.CondPagoDias == (int?)0) : ((int?)x.CondPagoDias > (int?)0)) : ((int?)x.CondPagoDias >= (int?)0))
                                                                           select x
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

        [HttpGet("Inventario/{existencia}/{pagina}/{siCambio}/{totalRegistros}/{cadenaFiltro}")]
        public async Task<IActionResult> Articulos(int existencia, int pagina, int siCambio, int totalRegistros, string cadenaFiltro)
        {
            string cadenaFiltro2 = cadenaFiltro;
            new List<listadoArticuloDTO>();
            int cantidadRegistroPorPagina = 10;
            Claim identity = base.User.Claims.Where((Claim x) => x.Type == "Almacen_ID").FirstOrDefault();
            string AlmacenId = identity.Value;
            IQueryable<listadoArticuloDTO> query = from x in context.Articulos
                                                   where (cadenaFiltro2 != "*") ? string.Concat(x.ArticuloCd + x.ArticuloDesc, x.ArticuloPartNo).Contains(cadenaFiltro2) : true
                                                   select x into data
                                                   from unidad in from u in context.Unidads
                                                                  where (int?)u.UnidadId == data.UnidadId
                                                                  select u
                                                   from artAlmacen in from u in context.ArticuloAlmacens
                                                                      where u.ArticuloId == data.ArticuloId && u.AlmacenId == Convert.ToInt32(AlmacenId) && ((existencia != 0) ? ((existencia == 1) ? (u.ArticuloAlmacenExistencia > (double?)0.0) : ((existencia == 2) ? (u.ArticuloAlmacenExistencia < (double?)0.0) : (u.ArticuloAlmacenExistencia == (double?)0.0))) : (u.ArticuloAlmacenExistencia != null))
                                                                      select u
                                                   select new listadoArticuloDTO
                                                   {
                                                       ArticuloID = data.ArticuloId,
                                                       ArticuloCodigo = data.ArticuloCd,
                                                       ArticuloDescripcion = data.ArticuloDesc,
                                                       ArticuloParteNo = data.ArticuloPartNo,
                                                       ArticuloUdm = unidad.UnidadDesc,
                                                       ArticuloUbicacion = artAlmacen.ArticuloAlmacenUbicacion,
                                                       ArticuloExistencia = (string.IsNullOrEmpty(((object)artAlmacen.ArticuloAlmacenExistencia).ToString()) ? "0" : ((Convert.ToDecimal(artAlmacen.ArticuloAlmacenExistencia) == 0m) ? "0" : Convert.ToDecimal(artAlmacen.ArticuloAlmacenExistencia).ToString("0,0.0", CultureInfo.InvariantCulture))),
                                                       ArticuloCosto = (string.IsNullOrEmpty(((object)data.ArticuloCosto).ToString()) ? "0" : ((Convert.ToDecimal(data.ArticuloCosto) == 0m) ? "0" : Convert.ToDecimal(data.ArticuloCosto).ToString("0,0.0", CultureInfo.InvariantCulture))),
                                                       ArticuloPrecios = "",
                                                       ArticuloEstado = data.ArticuloStatus
                                                   };
            if (siCambio == 1)
            {
                totalRegistros = await query.CountAsync();
            }
            List<listadoArticuloDTO> result = await query.OrderBy((listadoArticuloDTO x) => x.ArticuloDescripcion).Skip((pagina - 1) * cantidadRegistroPorPagina).Take(cantidadRegistroPorPagina)
                .ToListAsync();
            foreach (listadoArticuloDTO item in result)
            {
                List<Precio> precios = await (from x in context.Precios
                                              where x.ArticuloId == (int?)item.ArticuloID
                                              orderby x.PrecioNo
                                              select x).ToListAsync();
                string listaPrecio = "";
                for (int i = 0; i < precios.Count; i++)
                {
                    decimal precioUnit = Convert.ToDecimal(precios[i].PrecioMonto);
                    string precioU = ((precioUnit == 0m) ? "0" : Convert.ToDecimal(precios[i].PrecioMonto).ToString("0,0.0", CultureInfo.InvariantCulture));
                    listaPrecio = ((i != precios.Count - 1) ? (listaPrecio + precioU + ", ") : (listaPrecio + precioU));
                }
                item.ArticuloPrecios = listaPrecio;
            }
            return Ok(new
            {
                registros = result,
                paginaActual = pagina,
                totalRegistros = totalRegistros,
                totalPaginas = (int)Math.Ceiling((double)totalRegistros / 10.0)
            });
        }

        [HttpGet("ConsultaDetFactulla/{facturaId}")]
        public async Task<IActionResult> ConsultaDetFactulla(int facturaId)
        {
            new facturaConsultaDTO();
            IQueryable<facturaConsultaDTO> query = from x in context.Facturas
                                                   where x.FacturaId == facturaId
                                                   select x into fac
                                                   from cliente in from c in context.Clientes
                                                                   where (int?)c.ClienteId == fac.ClienteId
                                                                   select c
                                                   from condicion in from c in context.CondPagos
                                                                     where (int?)c.CondPagoId == fac.CondPagoId
                                                                     select c
                                                   from comprobante in from c in context.ComprobanteTipos
                                                                       where (int?)c.ComprobanteTipoId == (int?)fac.ComprobanteTipoId
                                                                       select c
                                                   from Usuario in from c in context.Usuarios
                                                                   where (int?)c.UsuarioId == fac.FacturaUsuarioCierra
                                                                   select c
                                                   select new facturaConsultaDTO
                                                   {
                                                       facturaId = fac.FacturaId,
                                                       facturaNo = fac.FacturaNo,
                                                       fecha = Convert.ToDateTime(fac.FacturaFecha).ToString("dd/MM/yyyy"),
                                                       hora = Convert.ToDateTime(fac.FacturaFecha).ToString("hh:mm:ss tt"),
                                                       cliente = ((cliente.ClienteNombre == "") ? ((!string.IsNullOrEmpty(fac.FacturaCliente)) ? fac.FacturaCliente : cliente.ClienteCodigo) : cliente.ClienteNombre.ToUpper()),
                                                       clienteCedula = cliente.ClienteCedula,
                                                       clienteTelefono = cliente.ClienteTel,
                                                       condicionDesc = condicion.CondPagoDesc,
                                                       vendedor = Usuario.UsuarioNombre,
                                                       comprobante = fac.FacturaComprobante,
                                                       comprobanteTipo = comprobante.ComprobanteDesc,
                                                       comprobanteTipoId = ((object)fac.ComprobanteTipoId).ToString(),
                                                       comprobanteSiFechaVen = comprobante.ComprobanteSiFechaVen,
                                                       comprobanteFechaValida = Convert.ToDateTime(fac.FacturaComprobanteFechaVen).ToString("dd/MM/yyyy"),
                                                       subTotal = Convert.ToDecimal(fac.FacturaBalance - fac.FacturaDescto - fac.FacturaItbis - fac.FacturaMontoImpuesto).ToString("0,0.0", CultureInfo.InvariantCulture),
                                                       descuento = Convert.ToDecimal(fac.FacturaDescto).ToString("0,0.0", CultureInfo.InvariantCulture),
                                                       itbis = Convert.ToDecimal(fac.FacturaItbis).ToString("0,0.0", CultureInfo.InvariantCulture),
                                                       ley = Convert.ToDecimal(fac.FacturaMontoImpuesto).ToString("0,0.0", CultureInfo.InvariantCulture),
                                                       total = Convert.ToDecimal(fac.FacturaBalance).ToString("0,0.0", CultureInfo.InvariantCulture)
                                                   };
            facturaConsultaDTO result = await query.FirstAsync();
            new List<facturaDetConsultaDTO>();
            IQueryable<facturaDetConsultaDTO> queryDet = from x in context.FacturaDets
                                                         where x.FacturaId == (int?)facturaId
                                                         select x into facDet
                                                         from articulo in from c in context.Articulos
                                                                          where (int?)c.ArticuloId == facDet.ArticuloId
                                                                          select c
                                                         from unidad in from c in context.Unidads
                                                                        where (int?)c.UnidadId == facDet.UnidadId
                                                                        select c
                                                         select new facturaDetConsultaDTO
                                                         {
                                                             facturaId = (int)facDet.FacturaId,
                                                             facturaDetNo = (int)facDet.FacturaDetNo,
                                                             codigo = articulo.ArticuloCd,
                                                             descripcion = articulo.ArticuloDesc,
                                                             cantidad = Convert.ToDecimal(facDet.FacturaQty).ToString("0,0.0", CultureInfo.InvariantCulture),
                                                             unidad = unidad.UnidadDesc,
                                                             precio = Convert.ToDecimal(facDet.FacturaPrecio).ToString("0,0.0", CultureInfo.InvariantCulture),
                                                             itbis = Convert.ToDecimal(facDet.FacturaItbis).ToString("0,0.0", CultureInfo.InvariantCulture),
                                                             Importe = Convert.ToDecimal((decimal?)(decimal)facDet.FacturaQty * facDet.FacturaPrecio + (decimal?)(decimal)facDet.FacturaQty * facDet.FacturaItbis).ToString("0,0.0", CultureInfo.InvariantCulture)
                                                         };
            result.facturaDet = await queryDet.OrderBy((facturaDetConsultaDTO x) => x.facturaDetNo).ToListAsync();
            return Ok(result);
        }

        [HttpGet("ConsultaVentasPorArticulo/{articuloId}/{fechaDesde}/{fechaHasta}/{pagina}/{siCambio}/{totalRegistros}")]
        public async Task<IActionResult> ConsultaVentasPorArticulo(int articuloId, string fechaDesde, string fechaHasta, int pagina, int siCambio, int totalRegistros)
        {
            DateTime fechaInicio = Convert.ToDateTime(fechaDesde);
            DateTime fechaFinal = Convert.ToDateTime(fechaHasta);
            int cantidadRegistroPorPagina = 10;
            var result2 = await (from x in context.FacturaDets.Include((FacturaDet x) => x.Factura)
                                 where x.Factura.FacturaEstatus == false && x.Factura.FacturaBalance > (decimal?)0m && x.Factura.FacturaFecha >= fechaInicio && x.Factura.FacturaFecha <= fechaFinal && ((articuloId != 0) ? (x.ArticuloId == (int?)articuloId) : true)
                                 select x into fac
                                 group fac by fac.ArticuloId into grupo
                                 select new
                                 {
                                     id = grupo.Key,
                                     articuloId = grupo.Max((FacturaDet fact) => fact.ArticuloId),
                                     total = grupo.Sum((FacturaDet fact) => fact.FacturaQty)
                                 } into result
                                 orderby result.total descending
                                 select result).Skip((pagina - 1) * cantidadRegistroPorPagina).Take(cantidadRegistroPorPagina).ToListAsync();
            if (siCambio == 1)
            {
                totalRegistros = await (from x in context.FacturaDets.Include((FacturaDet x) => x.Factura)
                                        where x.Factura.FacturaEstatus == false && x.Factura.FacturaBalance > (decimal?)0m && x.Factura.FacturaFecha >= fechaInicio && x.Factura.FacturaFecha <= fechaFinal && ((articuloId != 0) ? (x.ArticuloId == (int?)articuloId) : true)
                                        select x into fac
                                        group fac by fac.ArticuloId into grupo
                                        select new
                                        {
                                            id = grupo.Key,
                                            articuloId = grupo.Max((FacturaDet fact) => fact.ArticuloId),
                                            total = grupo.Sum((FacturaDet fact) => fact.FacturaQty)
                                        }).CountAsync();
            }
            List<ventasPorArticuloDTO> ventasPorArt = new List<ventasPorArticuloDTO>();
            foreach (var item in result2)
            {
                Articulo articulo = await context.Articulos.Where((Articulo x) => (int?)x.ArticuloId == item.articuloId).FirstAsync();
                ventasPorArticuloDTO ventasArt = new ventasPorArticuloDTO();
                ventasArt.articuloId = articulo.ArticuloId;
                ventasArt.articuloDesc = articulo.ArticuloDesc;
                ventasArt.articuloCd = articulo.ArticuloCd;
                ventasArt.cantidad = (decimal)item.total.Value;
                ventasPorArt.Add(ventasArt);
            }
            return Ok(new
            {
                registros = ventasPorArt,
                paginaActual = pagina,
                totalRegistros = totalRegistros,
                totalPaginas = (int)Math.Ceiling((double)totalRegistros / 10.0)
            });
        }
    }
}
