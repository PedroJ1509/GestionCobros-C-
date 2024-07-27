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
    public class ReservaController : ControllerBase
    {
        private readonly GestionEmpContext context;

        public ReservaController(GestionEmpContext context)
        {
            this.context = context;
        }
        [HttpGet("Reservas/{habitacionID}/{fecha}")]
        public async Task<List<reservaDTO>> Reservas(int habitacionID, string fecha)
        {
            List<reservaDTO> result = new List<reservaDTO>();

            DateTime FechaCalendar = Convert.ToDateTime(fecha);

            if (habitacionID == 0)
            {
                var query = (
                    from data in context.ReservaDets
                    from reservas in context.Reservas.Where(x => x.ReservaTipo != -1 && x.ReservaId == data.ReservaId && x.ReservaFechaEntrada.Value.Year >= FechaCalendar.Year && x.ReservaFechaEntrada.Value.Month >= FechaCalendar.Month)
                    from cliente in context.Clientes.Where(x => x.ClienteId == reservas.ClienteId).DefaultIfEmpty()
                    from habitacion in context.Habitacions.Where(x => x.HabitacionId == data.HabitacionId).DefaultIfEmpty()
                    select new reservaDTO
                    {
                        ReservaId = reservas.ReservaId,
                        ReservaNo = reservas.ReservaNo,
                        ReservaFechaEntrada = reservas.ReservaFechaEntrada,
                        ReservaFechaSalida = reservas.ReservaFechaSalida.Value.AddDays(1),
                        ClienteId = reservas.ClienteId,
                        ClienteNombre = cliente.ClienteNombre.ToUpper(),
                        PlanId = reservas.PlanId,
                        PlanDesc = habitacion.HabitacionDesc,
                        UsuarioId = reservas.UsuarioId,
                        ReservaTipo = reservas.ReservaTipo
                    }
                );
                result = await query.ToListAsync();
            }
            else
            {
                var query = (
                    from data in context.ReservaDets.Where(x => x.HabitacionId == habitacionID)
                    from reservas in context.Reservas.Where(x => x.ReservaTipo != -1 && x.ReservaId == data.ReservaId && x.ReservaFechaEntrada.Value.Year >= FechaCalendar.Year && x.ReservaFechaEntrada.Value.Month >= FechaCalendar.Month)
                    from cliente in context.Clientes.Where(x => x.ClienteId == reservas.ClienteId).DefaultIfEmpty()
                    from habitacion in context.Habitacions.Where(x => x.HabitacionId == data.HabitacionId).DefaultIfEmpty()
                    select new reservaDTO
                    {
                        ReservaId = reservas.ReservaId,
                        ReservaNo = reservas.ReservaNo,
                        ReservaFechaEntrada = reservas.ReservaFechaEntrada,
                        ReservaFechaSalida = reservas.ReservaFechaSalida.Value.AddDays(1),
                        ClienteId = reservas.ClienteId,
                        ClienteNombre = cliente.ClienteNombre.ToUpper(),
                        PlanId = reservas.PlanId,
                        PlanDesc = habitacion.HabitacionDesc,
                        UsuarioId = reservas.UsuarioId,
                        ReservaTipo = reservas.ReservaTipo
                    }
                );
                result = await query.ToListAsync();
            }

            return result;
        }
        [HttpGet("Reserva/{reservaID}")]
        public async Task<reservaCreacionDTO> GetReserva(int reservaID)
        {
            reservaCreacionDTO result = new reservaCreacionDTO();
            
            var query = (
                from data in context.ReservaDets.Where(x => x.ReservaId == reservaID)
                from reservas in context.Reservas.Where(x => x.ReservaId == reservaID)
                from cliente in context.Clientes.Where(x => x.ClienteId == reservas.ClienteId).DefaultIfEmpty()
                from habitacion in context.Habitacions.Where(x => x.HabitacionId == data.HabitacionId).DefaultIfEmpty()
                select new reservaCreacionDTO
                {
                    ReservaId = reservas.ReservaId,
                    ReservaFechaEntrada = reservas.ReservaFechaEntrada.Value.ToString("dd/MM/yyyy"),
                    ReservaFechaSalida = reservas.ReservaFechaSalida.Value.ToString("dd/MM/yyyy"),
                    ClienteId = reservas.ClienteId,
                    HabitacionId = data.HabitacionId,
                    PlanId = reservas.PlanId,
                    TipoHospedajeId = data.TipoHospedajeId,
                    ReservaDetPrecio = data.ReservaDetPrecio,
                    ReservaTipo = reservas.ReservaTipo.ToString(),
                    ReservaDetId = data.ReservaDetId.ToString()
                }
            );
            result = await query.FirstOrDefaultAsync();

            return result;
        }

        [HttpPost("Reserva")]
        public async Task<ActionResult> PostReserva(reservaCreacionDTO model)
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
                reserva.ReservaTipo = 0;
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

                var clienteBD = await context.Clientes.Where(x => x.ClienteId == model.ClienteId).FirstOrDefaultAsync();

                for (int i = 1; i <= tipoHospedaje.TipoHospedajeOcupacion; i++)
                {
                    if (i == 1)
                    {
                        reservaHospedajeDTO Huesped = new reservaHospedajeDTO();

                        var queryHuesped = (
                            from data in context.ReservaHospedajes.Where(x => x.ReservaHospedajeIdentificacion.Replace("-", "") == clienteBD.ClienteCedula.Replace("-", ""))
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
                        Huesped = await queryHuesped.FirstOrDefaultAsync();

                        if (Huesped != null)
                        {
                            ReservaHospedaje reservaHos = new ReservaHospedaje();
                            reservaHos.ReservaDetId = reservaDet.ReservaDetId;
                            reservaHos.ReservaHospedajeSec = i;
                            reservaHos.NacionalidadId = Huesped.NacionalidadId;
                            reservaHos.ReservaHospedajeNombre = Huesped.ReservaHospedajeNombre;
                            reservaHos.ReservaHospedajeIdentificacion = Huesped.ReservaHospedajeIdentificacion;
                            reservaHos.ReservaHospedajeEmail = Huesped.ReservaHospedajeEmail;
                            reservaHos.ReservaHospedajeTelefonos = Huesped.ReservaHospedajeTelefonos;
                            reservaHos.ReservaHospedajeSexo = Huesped.ReservaHospedajeSexo;
                            reservaHos.ReservaHospedajeFechaEntrada = reserva.ReservaFechaEntrada;
                            reservaHos.ReservaHospedajeFechaSalida = reserva.ReservaFechaSalida;
                            reservaHos.ReservaHospedajeDireccion = Huesped.ReservaHospedajeDireccion;
                            context.Add(reservaHos);
                            await context.SaveChangesAsync();
                        }
                        else
                        {
                            ReservaHospedaje reservaHos = new ReservaHospedaje();
                            reservaHos.ReservaDetId = reservaDet.ReservaDetId;
                            reservaHos.ReservaHospedajeSec = i;
                            reservaHos.NacionalidadId = 0;
                            context.Add(reservaHos);
                            await context.SaveChangesAsync();
                        }
                    }
                    else
                    {
                        ReservaHospedaje reservaHos = new ReservaHospedaje();
                        reservaHos.ReservaDetId = reservaDet.ReservaDetId;
                        reservaHos.ReservaHospedajeSec = i;
                        reservaHos.NacionalidadId = 0;
                        context.Add(reservaHos);
                        await context.SaveChangesAsync();
                    }
                }


                return NoContent();
            }
            catch (Exception)
            {
                return NotFound();
            }
        }

        [HttpPut("Reserva")]
        public async Task<ActionResult> PutReserva(reservaCreacionDTO model)
        {
            try
            {
                var query = (
                    from data in context.ReservaDets.Where(x => x.ReservaId != model.ReservaId && x.HabitacionId == model.HabitacionId)
                    from reservas in context.Reservas.Where(x => x.ReservaId != model.ReservaId && x.ReservaTipo != -1 && x.ReservaId == data.ReservaId && x.ReservaFechaEntrada.Value <= Convert.ToDateTime(model.ReservaFechaEntrada) && x.ReservaFechaSalida.Value > Convert.ToDateTime(model.ReservaFechaEntrada))
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

                Reserva reserva = await context.Reservas.Where(x => x.ReservaId == model.ReservaId).FirstOrDefaultAsync();
                reserva.ReservaFechaEntrada = Convert.ToDateTime(model.ReservaFechaEntrada);
                reserva.ReservaFechaSalida = Convert.ToDateTime(model.ReservaFechaSalida);
                reserva.ClienteId = model.ClienteId;
                reserva.PlanId = model.PlanId;
                reserva.ReservaTipo = 0;
                context.Update(reserva);
                await context.SaveChangesAsync();

                ReservaDet reservaDet = await context.ReservaDets.Where(x => x.ReservaId == model.ReservaId).FirstOrDefaultAsync();
                reservaDet.ReservaId = reserva.ReservaId;
                reservaDet.HabitacionId = model.HabitacionId;
                reservaDet.TipoHospedajeId = model.TipoHospedajeId;
                reservaDet.ReservaDetPrecio = model.ReservaDetPrecio;
                context.Update(reservaDet);
                await context.SaveChangesAsync();

                context.ReservaHospedajes.Where(x => x.ReservaDetId == reservaDet.ReservaDetId)
                                            .ToList().ForEach(x => context.ReservaHospedajes.Remove(x));
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

                return NoContent();
            }
            catch (Exception)
            {
                return NotFound();
            }
        }

        [HttpPost("ReservaActualizarFechas/{reservaID}/{fechaInicio}/{fechaFinal}")]
        public async Task<ActionResult> ReservaActualizarFechas(string reservaID, string fechaInicio, string fechaFinal)
        {
            Reserva reserva = await context.Reservas.Where(x => x.ReservaId == Convert.ToInt32(reservaID)).FirstOrDefaultAsync();
            ReservaDet reservadet = await context.ReservaDets.Where(x => x.ReservaId == Convert.ToInt32(reservaID)).FirstOrDefaultAsync();

            var query = (
                    from data in context.ReservaDets.Where(x => x.ReservaId != reservadet.ReservaId && x.HabitacionId == reservadet.HabitacionId)
                    from reservas in context.Reservas.Where(x => x.ReservaId != reserva.ReservaId && x.ReservaTipo != -1 && x.ReservaId == data.ReservaId && x.ReservaFechaEntrada.Value <= Convert.ToDateTime(fechaInicio + "T00:00:00") && x.ReservaFechaSalida.Value > Convert.ToDateTime(fechaInicio + "T00:00:00"))
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

            reserva.ReservaFechaEntrada = Convert.ToDateTime(fechaInicio + "T00:00:00");
            reserva.ReservaFechaSalida = Convert.ToDateTime(fechaFinal + "T00:00:00").AddDays(-1);
            context.Update(reserva);
            await context.SaveChangesAsync();

            return NoContent();
        }
        [HttpDelete("Reserva/{reservaID}")]
        public async Task<ActionResult> DeleteReserva(int reservaID)
        {
            Reserva reserva = await context.Reservas.Where(x => x.ReservaId == reservaID).FirstOrDefaultAsync();
            
            reserva.ReservaTipo = -1;
            context.Update(reserva);
            await context.SaveChangesAsync();

            return NoContent();
        }
    }
}
