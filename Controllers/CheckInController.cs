using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using JaMPeApp.DTOs;
using JaMPeApp.Models;
using Rotativa.AspNetCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace JaMPeApp.Controllers
{
    [ApiController]
    public class CheckInController : ControllerBase
    {
        private readonly GestionEmpContext context;

        public CheckInController(GestionEmpContext context)
        {
            this.context = context;
        }

        [HttpGet("CheckInHabitaciones/{plantaId}")]
        public async Task<List<checkinHabitacionesDTO>> CheckInHabitaciones(int plantaId)
        {
            var result = new List<checkinHabitacionesDTO>();

            if (plantaId == 0)
            {
                var query = (
                    from data in context.Habitacions.Where(x => x.HabitacionEstatus == true)
                    from tipoHabitacion in context.TipoHabitacions.Where(x => x.TipoHabitacionId == data.TipoHabitacionId).DefaultIfEmpty()
                    select new checkinHabitacionesDTO
                    {
                        HabitacionId = data.HabitacionId,
                        HabitacionDesc = String.IsNullOrEmpty(data.HabitacionDesc) ? "" : data.HabitacionDesc,
                        HabitacionEstado = data.HabitacionEstado.ToString(),
                        TipoHabitacionDesc = tipoHabitacion.TipoHabitacionDesc,
                        TipoHabitacionId = tipoHabitacion.TipoHabitacionId.ToString()
                    }
                );
                result = await query.OrderBy(x => x.HabitacionDesc).ToListAsync();
            }
            else
            {
                var query = (
                    from data in context.Habitacions.Where(x => x.HabitacionEstatus == true && x.PlantaId == plantaId)
                    from tipoHabitacion in context.TipoHabitacions.Where(x => x.TipoHabitacionId == data.TipoHabitacionId).DefaultIfEmpty()
                    select new checkinHabitacionesDTO
                    {
                        HabitacionId = data.HabitacionId,
                        HabitacionDesc = String.IsNullOrEmpty(data.HabitacionDesc) ? "" : data.HabitacionDesc,
                        HabitacionEstado = data.HabitacionEstado.ToString(),
                        TipoHabitacionDesc = tipoHabitacion.TipoHabitacionDesc
                    }
                );
                result = await query.OrderBy(x => x.HabitacionDesc).ToListAsync();
            }

            for (int i = 0; i < result.Count(); i++)
            {
                var queryReserva = (
                from reservaDet in context.ReservaDets.Where(x => x.HabitacionId == result[i].HabitacionId)
                from reservas in context.Reservas.Where(x => x.ReservaTipo != -1 && 
                                                        x.ReservaTipo != 2 && 
                                                        x.ReservaId == reservaDet.ReservaId &&
                                                        x.ReservaFechaEntrada <= DateTime.Today &&
                                                        x.ReservaFechaSalida >= DateTime.Today)
                select new reservaDTO
                {
                    ReservaId = reservas.ReservaId,
                    ReservaNo = reservas.ReservaNo,
                    ReservaFechaEntrada = reservas.ReservaFechaEntrada,
                    ReservaFechaSalida = reservas.ReservaFechaSalida.Value,
                    ClienteId = reservas.ClienteId,
                    PlanId = reservas.PlanId,
                    UsuarioId = reservas.UsuarioId,
                    ReservaTipo = reservas.ReservaTipo
                });
                var resultReserva = await queryReserva.ToListAsync();

                if (resultReserva.Count() > 0)
                {
                    result[i].ReservaId = resultReserva[0].ReservaId.ToString();
                    result[i].ReservaNo = resultReserva[0].ReservaNo.ToString();
                    result[i].ReservaTipo = resultReserva[0].ReservaTipo.ToString();
                    result[i].checkout = resultReserva[0].ReservaFechaSalida.Value.ToString("dd/MM/yyyy") == DateTime.Today.ToString("dd/MM/yyyy") ? "1" : "0";
                }
                else
                {
                    result[i].ReservaId = "0";
                    result[i].checkout = "0";
                }
            }

            return result;
        }

        [HttpGet("Hospedajes/{reservaDetID}")]
        public async Task<List<reservaHospedajeDTO>> Hospedajes(int reservaDetId)
        {
            List<reservaHospedajeDTO> result = new List<reservaHospedajeDTO>();

            var query = (
                from data in context.ReservaHospedajes.Where(x => x.ReservaDetId == reservaDetId)
                from nacionalidad in context.Nacionalidads.Where(x => x.NacionalidadId == data.NacionalidadId).DefaultIfEmpty()
                select new reservaHospedajeDTO
                {
                    ReservaDetId = data.ReservaDetId,
                    ReservaHospedajeSec = data.ReservaHospedajeSec,
                    ReservaHospedajeNombre = String.IsNullOrEmpty(data.ReservaHospedajeNombre) ? "" : data.ReservaHospedajeNombre,
                    ReservaHospedajeIdentificacion = data.ReservaHospedajeIdentificacion,
                    ReservaHospedajeDireccion = data.ReservaHospedajeDireccion,
                    ReservaHospedajeTelefonos = String.IsNullOrEmpty(data.ReservaHospedajeTelefonos) ? "" : data.ReservaHospedajeTelefonos,
                    ReservaHospedajeEmail = String.IsNullOrEmpty(data.ReservaHospedajeEmail) ? "" : data.ReservaHospedajeEmail,
                    ReservaHospedajeFechaEntrada = data.ReservaHospedajeFechaEntrada.Value.ToString("dd/MM/yyyy"),
                    ReservaHospedajeFechaSalida = data.ReservaHospedajeFechaSalida.Value.ToString("dd/MM/yyyy"),
                    ReservaHospedajeComentario = data.ReservaHospedajeComentario,
                    NacionalidadId = data.NacionalidadId,
                    NacionalidadDesc = nacionalidad.NacionalidadDesc,
                    ReservaHospedajeSexo = String.IsNullOrEmpty(data.ReservaHospedajeSexo) ? "" : data.ReservaHospedajeSexo,
                    ReservaHospedajeEdad = String.IsNullOrEmpty(data.ReservaHospedajeEdad.ToString()) ? "" :  data.ReservaHospedajeEdad.ToString()
                }
            );
            result = await query.ToListAsync();

            return result;
        }
        [HttpGet("Huesped/{reservaDetID}/{reservaDetSec}")]
        public async Task<reservaHospedajeDTO> Huesped(int reservaDetId, int reservaDetSec)
        {
            reservaHospedajeDTO result = new reservaHospedajeDTO();

            var query = (
                from data in context.ReservaHospedajes.Where(x => x.ReservaDetId == reservaDetId && x.ReservaHospedajeSec == reservaDetSec)
                select new reservaHospedajeDTO
                {
                    ReservaDetId = data.ReservaDetId,
                    ReservaHospedajeSec = data.ReservaHospedajeSec,
                    ReservaHospedajeNombre = String.IsNullOrEmpty(data.ReservaHospedajeNombre) ? "" : data.ReservaHospedajeNombre,
                    ReservaHospedajeIdentificacion = data.ReservaHospedajeIdentificacion,
                    ReservaHospedajeDireccion = data.ReservaHospedajeDireccion,
                    ReservaHospedajeTelefonos = String.IsNullOrEmpty(data.ReservaHospedajeTelefonos) ? "" : data.ReservaHospedajeTelefonos,
                    ReservaHospedajeEmail = String.IsNullOrEmpty(data.ReservaHospedajeEmail) ? "" : data.ReservaHospedajeEmail,
                    ReservaHospedajeFechaEntrada = data.ReservaHospedajeFechaEntrada.Value.ToString("dd/MM/yyyy"),
                    ReservaHospedajeFechaSalida = data.ReservaHospedajeFechaSalida.Value.ToString("dd/MM/yyyy"),
                    ReservaHospedajeComentario = data.ReservaHospedajeComentario,
                    NacionalidadId = data.NacionalidadId,
                    ReservaHospedajeSexo = String.IsNullOrEmpty(data.ReservaHospedajeSexo) ? "" : data.ReservaHospedajeSexo,
                    ReservaHospedajeEdad = String.IsNullOrEmpty(data.ReservaHospedajeEdad.ToString()) ? "" : data.ReservaHospedajeEdad.ToString()
                }
            );
            result = await query.FirstOrDefaultAsync();

            return result;
        }
        [HttpGet("ConsultaIdenticacion/{identificacion}")]
        public async Task<reservaHospedajeDTO> ConsultaIdenticacion(string identificacion)
        {
            reservaHospedajeDTO result = new reservaHospedajeDTO();

            var query = (
                from data in context.ReservaHospedajes.Where(x => x.ReservaHospedajeIdentificacion.Replace("-","") == identificacion.Replace("-", ""))
                select new reservaHospedajeDTO
                {
                    ReservaDetId = data.ReservaDetId,
                    ReservaHospedajeSec = data.ReservaHospedajeSec,
                    ReservaHospedajeNombre = String.IsNullOrEmpty(data.ReservaHospedajeNombre) ? "" : data.ReservaHospedajeNombre,
                    ReservaHospedajeIdentificacion = data.ReservaHospedajeIdentificacion,
                    ReservaHospedajeDireccion = data.ReservaHospedajeDireccion,
                    ReservaHospedajeTelefonos = String.IsNullOrEmpty(data.ReservaHospedajeTelefonos) ? "" : data.ReservaHospedajeTelefonos,
                    ReservaHospedajeEmail = String.IsNullOrEmpty(data.ReservaHospedajeEmail) ? "" : data.ReservaHospedajeEmail,
                    ReservaHospedajeFechaEntrada = data.ReservaHospedajeFechaEntrada.Value.ToString("dd/MM/yyyy"),
                    ReservaHospedajeFechaSalida = data.ReservaHospedajeFechaSalida.Value.ToString("dd/MM/yyyy"),
                    ReservaHospedajeComentario = data.ReservaHospedajeComentario,
                    NacionalidadId = data.NacionalidadId,
                    ReservaHospedajeSexo = String.IsNullOrEmpty(data.ReservaHospedajeSexo) ? "" : data.ReservaHospedajeSexo,
                    ReservaHospedajeEdad = String.IsNullOrEmpty(data.ReservaHospedajeEdad.ToString()) ? "" : data.ReservaHospedajeEdad.ToString()
                }
            );
            result = await query.FirstOrDefaultAsync();

            return result;
        }
        [HttpPut("ReservaHospedaje")]
        public async Task<ActionResult> ReservaHospedaje(reservaHospedajeDTO model)
        {
            try
            {
                ReservaHospedaje reservaHospedaje = await context.ReservaHospedajes.Where(x => x.ReservaDetId == model.ReservaDetId && x.ReservaHospedajeSec == model.ReservaHospedajeSec).FirstOrDefaultAsync();
                reservaHospedaje.ReservaHospedajeIdentificacion = model.ReservaHospedajeIdentificacion;
                reservaHospedaje.ReservaHospedajeFechaEntrada = Convert.ToDateTime(model.ReservaHospedajeFechaEntrada);
                reservaHospedaje.ReservaHospedajeNombre = model.ReservaHospedajeNombre;
                reservaHospedaje.ReservaHospedajeDireccion = model.ReservaHospedajeDireccion;
                reservaHospedaje.ReservaHospedajeTelefonos = model.ReservaHospedajeTelefonos;
                reservaHospedaje.ReservaHospedajeEmail = model.ReservaHospedajeEmail;
                reservaHospedaje.NacionalidadId = model.NacionalidadId;
                reservaHospedaje.ReservaHospedajeEdad = String.IsNullOrEmpty(model.ReservaHospedajeEdad) ? null : Convert.ToInt32(model.ReservaHospedajeEdad);
                reservaHospedaje.ReservaHospedajeSexo = model.ReservaHospedajeSexo;
                context.Update(reservaHospedaje);
                await context.SaveChangesAsync();

                return NoContent();
            }
            catch (Exception)
            {
                return NotFound();
            }
        }
        [HttpPost("ReservaCheckIn/{reservaId}")]
        public async Task<IActionResult> ReservaCheckIn(int reservaId)
        {
            try
            {
                Reserva reserva = await context.Reservas.Where(x => x.ReservaId == reservaId).FirstOrDefaultAsync();
                reserva.ReservaTipo = 1;
                context.Update(reserva);
                await context.SaveChangesAsync();

                return NoContent();
            }
            catch (System.Exception ex)
            {
                return NotFound(ex.Message);
            }
        }
        [HttpPost("AnularCheckIn/{reservaId}")]
        public async Task<IActionResult> AnularCheckIn(int reservaId)
        {
            try
            {
                var checkinFactura = await context.Facturas.Where(x => x.ReservaId == reservaId && x.FacturaBalance > 0).AnyAsync();
                if (checkinFactura)
                {
                    return NotFound("CheckIn no puede ser anulado, ya tiene factura generada.");
                }

                Reserva reserva = await context.Reservas.Where(x => x.ReservaId == reservaId).FirstOrDefaultAsync();
                reserva.ReservaTipo = 0;
                context.Update(reserva);
                await context.SaveChangesAsync();

                return NoContent();
            }
            catch (System.Exception ex)
            {
                return NotFound(ex.Message);
            }
        }
        [HttpPost("ReservaCkeckIn")]
        public async Task<ActionResult> ReservaCkeckIn(reservaCreacionDTO model)
        {
            try
            {
                var query = (
                    from data in context.ReservaDets.Where(x => x.HabitacionId == model.HabitacionId)
                    from reservas in context.Reservas.Where(x => x.ReservaTipo != -1 && x.ReservaId == data.ReservaId && x.ReservaFechaEntrada.Value <= Convert.ToDateTime(model.ReservaFechaEntrada) && x.ReservaFechaSalida.Value > Convert.ToDateTime(model.ReservaFechaEntrada))
                    from cliente in context.Clientes.Where(x => x.ClienteId == reservas.ClienteId).DefaultIfEmpty()
                    select new reservaDTO
                    {
                        ReservaId = reservas.ReservaId,
                        ReservaNo = reservas.ReservaNo,
                        ReservaFechaEntrada = reservas.ReservaFechaEntrada,
                        ReservaFechaSalida = reservas.ReservaFechaSalida.Value.AddDays(1),
                        ClienteId = reservas.ClienteId,
                        ClienteNombre = cliente.ClienteNombre.ToUpper(),
                        PlanId = reservas.PlanId,
                        UsuarioId = reservas.UsuarioId,
                        ReservaTipo = reservas.ReservaTipo
                    }
                );
                var result = await query.ToListAsync();

                if (result.Count > 0)
                {
                    return NotFound("Ya existe una Reservación dentro de las fechas especifivadas.");
                }
                List<Reserva> reservasNo = await context.Reservas.ToListAsync();
                Int32 ultReservaNo = 0;

                if (reservasNo.Count() > 0)
                {
                    foreach (var reserv in reservasNo)
                    {
                        var codigo = Convert.ToInt32(reserv.ReservaNo);
                        if (codigo > ultReservaNo)
                        {
                            ultReservaNo = codigo;
                        }
                    }
                }

                var identity = User.Claims.Where(x => x.Type == "Usuario_ID").FirstOrDefault();
                var valorAutoridad = identity.Value;

                var usuarioId = valorAutoridad;

                Reserva reserva = new Reserva();
                reserva.ReservaNo = ultReservaNo + 1;
                reserva.ReservaFechaEntrada = Convert.ToDateTime(model.ReservaFechaEntrada);
                reserva.ReservaFechaSalida = Convert.ToDateTime(model.ReservaFechaSalida);
                reserva.ClienteId = model.ClienteId;
                reserva.PlanId = model.PlanId;
                reserva.ReservaTipo = 1;
                reserva.UsuarioId = Convert.ToInt32(usuarioId);
                context.Add(reserva);
                await context.SaveChangesAsync();

                ReservaDet reservaDet = new ReservaDet();
                reservaDet.ReservaId = reserva.ReservaId;
                reservaDet.HabitacionId = model.HabitacionId;
                reservaDet.TipoHospedajeId = model.TipoHospedajeId;
                reservaDet.ReservaDetPrecio = model.ReservaDetPrecio;
                context.Add(reservaDet);
                await context.SaveChangesAsync();

                var tipoHospedaje = await context.TipoHospedajes.Where(x => x.TipoHospedajeId == model.TipoHospedajeId).FirstOrDefaultAsync();

                for (int i = 1; i <= tipoHospedaje.TipoHospedajeOcupacion; i++)
                {
                    ReservaHospedaje reservaHos = new ReservaHospedaje();
                    reservaHos.ReservaDetId = reservaDet.ReservaDetId;
                    reservaHos.ReservaHospedajeSec = i;
                    reservaHos.NacionalidadId = 0;
                    context.Add(reservaHos);
                    await context.SaveChangesAsync();
                }


                return Ok(reservaDet.ReservaDetId);
            }
            catch (Exception)
            {
                return NotFound();
            }
        }
        [Route("/CheckInReport/{reservaId}")]
        public IActionResult CheckInReport(int reservaId)//[FromBody] List<reservaCreacionDTO> model
        {
            try
            {

                
                var general = context.Generals.FirstOrDefault();

                var query = (
                    from data in context.ReservaDets.Where(x => x.ReservaId == reservaId)
                    from reservas in context.Reservas.Where(x => x.ReservaId == data.ReservaId)
                    from cliente in context.Clientes.Where(x => x.ClienteId == reservas.ClienteId).DefaultIfEmpty()
                    from habitacion in context.Habitacions.Where(x => x.HabitacionId == data.HabitacionId).DefaultIfEmpty()
                    from tipoHabitacion in context.TipoHabitacions.Where(x => x.TipoHabitacionId == habitacion.TipoHabitacionId).DefaultIfEmpty()
                    from tipoHospedaje in context.TipoHospedajes.Where(x => x.TipoHospedajeId == data.TipoHospedajeId).DefaultIfEmpty()
                    select new checkInReport
                    {
                        reservaNo = reservas.ReservaNo,
                        reservaId = reservas.ReservaId,
                        reservaDetId = data.ReservaDetId,
                        tituloNombreEmpresa = general.GeneralEmpresaNombre,
                        clienteNombre = cliente.ClienteNombre,
                        HuespedNombre = cliente.ClienteNombre,
                        HuespedHabitacion = habitacion.HabitacionDesc,
                        HuespedTipoHabitacion = tipoHabitacion.TipoHabitacionDesc,
                        HuespedTipoHospedaje = tipoHospedaje.TipoHospedajeDesc,
                        HuespedTarifa = data.ReservaDetPrecio.ToString(),
                        HuespedDireccion = cliente.ClienteDir1,
                        HuespedTelefono = cliente.ClienteTel,
                        HuespedEmail = cliente.ClienteEmail,
                        HuespedIdentificacion = cliente.ClienteCedula,
                        HuespedFechaEntrada = reservas.ReservaFechaEntrada.Value.ToString("dd/MM/yyyy"),
                        HuespedFechaSalida = reservas.ReservaFechaSalida.Value.ToString("dd/MM/yyyy")
                    }
                );
                var result = query.FirstOrDefault();

                checkInReport CheckInReport = new checkInReport();
                CheckInReport.reservaNo = result.reservaNo;
                CheckInReport.reservaId = result.reservaId;
                CheckInReport.reservaDetId = result.reservaDetId;
                CheckInReport.tituloNombreEmpresa = result.tituloNombreEmpresa;
                CheckInReport.clienteNombre = result.clienteNombre;
                CheckInReport.HuespedHabitacion = result.HuespedHabitacion;
                CheckInReport.HuespedTipoHabitacion = result.HuespedTipoHabitacion;
                CheckInReport.HuespedTipoHospedaje = result.HuespedTipoHospedaje;
                CheckInReport.HuespedTarifa = result.HuespedTarifa;
                CheckInReport.HuespedDireccion = result.HuespedDireccion;
                CheckInReport.HuespedTelefono = result.HuespedTelefono;
                CheckInReport.HuespedEmail = result.HuespedEmail;
                CheckInReport.HuespedIdentificacion = result.HuespedIdentificacion;
                CheckInReport.HuespedFechaEntrada = result.HuespedFechaEntrada;
                CheckInReport.HuespedFechaSalida = result.HuespedFechaSalida;

                List<ListadoHuesped> listadohuesped = new List<ListadoHuesped>();

                List<reservaHospedajeDTO> resultListadoHuesped = new List<reservaHospedajeDTO>();

                var queryListadoHuesped = (
                    from data in context.ReservaHospedajes.Where(x => x.ReservaDetId == CheckInReport.reservaDetId)
                    select new reservaHospedajeDTO
                    {
                        ReservaDetId = data.ReservaDetId,
                        ReservaHospedajeSec = data.ReservaHospedajeSec,
                        ReservaHospedajeNombre = String.IsNullOrEmpty(data.ReservaHospedajeNombre) ? "" : data.ReservaHospedajeNombre,
                        ReservaHospedajeIdentificacion = data.ReservaHospedajeIdentificacion,
                        ReservaHospedajeDireccion = data.ReservaHospedajeDireccion,
                        ReservaHospedajeTelefonos = String.IsNullOrEmpty(data.ReservaHospedajeTelefonos) ? "" : data.ReservaHospedajeTelefonos,
                        ReservaHospedajeEmail = String.IsNullOrEmpty(data.ReservaHospedajeEmail) ? "" : data.ReservaHospedajeEmail,
                        ReservaHospedajeFechaEntrada = data.ReservaHospedajeFechaEntrada.Value.ToString("dd/MM/yyyy"),
                        ReservaHospedajeFechaSalida = data.ReservaHospedajeFechaSalida.Value.ToString("dd/MM/yyyy"),
                        ReservaHospedajeComentario = data.ReservaHospedajeComentario,
                        NacionalidadId = data.NacionalidadId,
                        ReservaHospedajeSexo = String.IsNullOrEmpty(data.ReservaHospedajeSexo) ? "" : data.ReservaHospedajeSexo,
                        ReservaHospedajeEdad = String.IsNullOrEmpty(data.ReservaHospedajeEdad.ToString()) ? "" : data.ReservaHospedajeEdad.ToString()
                    }
                );
                resultListadoHuesped = queryListadoHuesped.ToList();

                List<ListadoHuesped> listHuesp = new List<ListadoHuesped>();

                if (resultListadoHuesped.Count() > 0)
                {
                    for (int i = 0; i < resultListadoHuesped.Count(); i++)
                    {
                        if (resultListadoHuesped[i].ReservaHospedajeSec == 1)
                        {
                            if (resultListadoHuesped[i].ReservaHospedajeNombre != "") { CheckInReport.HuespedNombre = resultListadoHuesped[i].ReservaHospedajeNombre; };
                            if (resultListadoHuesped[i].ReservaHospedajeIdentificacion != "") { CheckInReport.HuespedIdentificacion = resultListadoHuesped[i].ReservaHospedajeIdentificacion; };
                            if (resultListadoHuesped[i].ReservaHospedajeDireccion != "") { CheckInReport.HuespedDireccion = resultListadoHuesped[i].ReservaHospedajeDireccion; };
                            if (resultListadoHuesped[i].ReservaHospedajeTelefonos != "") { CheckInReport.HuespedTelefono = resultListadoHuesped[i].ReservaHospedajeTelefonos; };
                            if (resultListadoHuesped[i].ReservaHospedajeEmail != "") { CheckInReport.HuespedEmail = resultListadoHuesped[i].ReservaHospedajeEmail; };
                            if (resultListadoHuesped[i].NacionalidadId != 0) {
                                var nacionalidad = context.Nacionalidads.FirstOrDefault(x => x.NacionalidadId == resultListadoHuesped[i].NacionalidadId);
                                CheckInReport.HuespedNacionalidad = nacionalidad.NacionalidadDesc; 
                            };

                        }
                        ListadoHuesped huesp = new ListadoHuesped();
                        huesp.HuespedNombre = resultListadoHuesped[i].ReservaHospedajeNombre;
                        huesp.HuespedSexo = resultListadoHuesped[i].ReservaHospedajeSexo == "F" ? "FEMENINO" : "MASCULINO";
                        huesp.HuespedEdad = resultListadoHuesped[i].ReservaHospedajeEdad;
                        listHuesp.Add(huesp);
                    }
                }

                CheckInReport.listadoHuespedes = listHuesp;

                var root2 = Environment.CurrentDirectory + "/wwwroot/PDFReports/";
                var pdfname = String.Format("{0}.pdf", "checkinreport");
                var path2 = Path.Combine(root2, pdfname);
                path2 = Path.GetFullPath(path2);

                var report = new ViewAsPdf("CheckInReport", CheckInReport)
                {
                    SaveOnServerPath = path2,
                    PageSize = Rotativa.AspNetCore.Options.Size.A4,
                    PageOrientation = Rotativa.AspNetCore.Options.Orientation.Portrait,
                    PageMargins = new Rotativa.AspNetCore.Options.Margins(10, 10, 10, 10)
                };

                return report;
            }
            catch (Exception ex)
            {
                return NotFound(ex);
            }
        }
        [HttpGet("Nacionalidades")]
        public async Task<List<nacionalidadDTO>> Nacionalidades()
        {
            var result = new List<nacionalidadDTO>();

            var query = (
                from data in context.Nacionalidads
                select new nacionalidadDTO
                {
                    NacionalidadId = data.NacionalidadId,
                    NacionalidadDesc = String.IsNullOrEmpty(data.NacionalidadDesc) ? "" : data.NacionalidadDesc
                }
            );
            result = await query.OrderBy(x => x.NacionalidadDesc).ToListAsync();

            return result;
        }
    }
}
