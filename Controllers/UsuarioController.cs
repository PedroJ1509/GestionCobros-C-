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
using Microsoft.VisualBasic;

namespace JaMPeApp.Controllers
{
    [ApiController]
    [Authorize(AuthenticationSchemes = CookieAuthenticationDefaults.AuthenticationScheme)]
    public class UsuarioController : ControllerBase
    {
        private readonly GestionEmpContext context;

        public UsuarioController(GestionEmpContext context)
        {
            this.context = context;
        }
        [HttpGet("listadoUsuario")]
        public async Task<List<listadoUsuarioDTO>> ListadoUsuario()
        {
            var result = new List<listadoUsuarioDTO>();

            var query = (
                from data in context.Usuarios
                from autoridad in context.Autoridads.Where(x => x.AutoridadId == data.AutoridadId).DefaultIfEmpty()
                select new listadoUsuarioDTO
                {
                    UsuarioId = data.UsuarioId,
                    UsuarioDescId = data.UsuarioDescId,
                    UsuarioNombre = data.UsuarioNombre,
                    AutoridadId = (short)data.AutoridadId,
                    AutoridadDesc = autoridad.AutoridadDesc,
                    Activo = data.Activo
                }
            );
            result = await query.OrderBy(x => x.UsuarioNombre).ToListAsync();

            return result;
        }

        [HttpGet("Usuario")]
        public async Task<List<usuarioDTO>> Usuario()
        {
            var result = new List<usuarioDTO>();

            var query = (
                from data in context.Usuarios.Where(x => x.Activo == true)
                select new usuarioDTO
                {
                    UsuarioId = data.UsuarioId,
                    UsuarioDescId = data.UsuarioDescId,
                    UsuarioPass = data.UsuarioPass,
                    UsuarioNombre = data.UsuarioNombre,
                    AutoridadId = data.AutoridadId,
                    UsuarioSiCajero = data.UsuarioSiCajero,
                    AlmacenId = data.AlmacenId,
                    UsuarioSiReAbrirCompra = data.UsuarioSiReAbrirCompra,
                    UsuarioSiAnularFactura = data.UsuarioSiAnularFactura,
                    UsuarioSiReAbrirFactura = data.UsuarioSiReAbrirFactura,
                    UsuarioSiModCredCliente = data.UsuarioSiModCredCliente,
                    UsuarioSiPreFactura = data.UsuarioSiPreFactura,
                    UsuarioSiFacCliSob = data.UsuarioSiFacCliSob,
                    UsuarioSiFacFacVen = data.UsuarioSiFacFacVen,
                    UsuarioSiImpuesto = data.UsuarioSiImpuesto,
                    UsuarioSiBorrarFactura = data.UsuarioSiBorrarFactura,
                    UsuarioNoCopiaFac = data.UsuarioNoCopiaFac,
                    Activo = data.Activo
                }
            );
            result = await query.OrderBy(x => x.UsuarioNombre).ToListAsync();

            return result;
        }

        [HttpGet("Usuario/{usuarioId}")]
        public async Task<usuarioDTO> GetUsuario(int usuarioId)
        {
            usuarioDTO usuario = new usuarioDTO();

            try
            {
                var result = await context.Usuarios.Where(x => x.UsuarioId == usuarioId).FirstOrDefaultAsync();

                if (result != null)
                {
                    usuario.UsuarioId = result.UsuarioId;
                    usuario.UsuarioDescId = result.UsuarioDescId;
                    usuario.UsuarioPass = DescocClave(result.UsuarioPass);
                    usuario.UsuarioNombre = result.UsuarioNombre;
                    usuario.AutoridadId = result.AutoridadId;
                    usuario.UsuarioSiCajero = result.UsuarioSiCajero;
                    usuario.AlmacenId = result.AlmacenId;
                    usuario.UsuarioSiReAbrirCompra = result.UsuarioSiReAbrirCompra;
                    usuario.UsuarioSiAnularFactura = result.UsuarioSiAnularFactura;
                    usuario.UsuarioSiReAbrirFactura = result.UsuarioSiReAbrirFactura;
                    usuario.UsuarioSiModCredCliente = result.UsuarioSiModCredCliente;
                    usuario.UsuarioSiPreFactura = result.UsuarioSiPreFactura;
                    usuario.UsuarioSiFacCliSob = result.UsuarioSiFacCliSob;
                    usuario.UsuarioSiFacFacVen = result.UsuarioSiFacFacVen;
                    usuario.UsuarioSiImpuesto = result.UsuarioSiImpuesto;
                    usuario.UsuarioSiBorrarFactura = result.UsuarioSiBorrarFactura;
                    usuario.UsuarioNoCopiaFac = result.UsuarioNoCopiaFac;
                    usuario.Activo = result.Activo;
                }
            }
            catch (Exception)
            {

            }
            return usuario;
        }
        [HttpPost("Usuario")]
        public async Task<ActionResult> PostUsuario(usuarioDTO model)
        {
            try
            {
                var Existe = await context.Usuarios.Where(x => x.UsuarioDescId == model.UsuarioDescId).FirstOrDefaultAsync();

                if (Existe != null)
                {
                    return NotFound("Ya existe un Usuario creado con este nombre.");
                }

                int userId = await context.Usuarios.Select(x => x.UsuarioId).MaxAsync();

                Usuario usuario = new Usuario();
                usuario.UsuarioId = (userId + 1);
                usuario.UsuarioDescId = model.UsuarioDescId;
                usuario.UsuarioPass = CocClave(model.UsuarioPass);
                usuario.UsuarioNombre = model.UsuarioNombre;
                usuario.AutoridadId = model.AutoridadId;
                usuario.UsuarioSiCajero = model.UsuarioSiCajero;
                usuario.AlmacenId = model.AlmacenId;
                usuario.UsuarioSiReAbrirCompra = model.UsuarioSiReAbrirCompra;
                usuario.UsuarioSiAnularFactura = model.UsuarioSiAnularFactura;
                usuario.UsuarioSiReAbrirFactura = model.UsuarioSiReAbrirFactura;
                usuario.UsuarioSiModCredCliente = model.UsuarioSiModCredCliente;
                usuario.UsuarioSiPreFactura = model.UsuarioSiPreFactura;
                usuario.UsuarioSiFacCliSob = model.UsuarioSiFacCliSob;
                usuario.UsuarioSiFacFacVen = model.UsuarioSiFacFacVen;
                usuario.UsuarioSiImpuesto = model.UsuarioSiImpuesto;
                usuario.UsuarioSiBorrarFactura = model.UsuarioSiBorrarFactura;
                usuario.UsuarioNoCopiaFac = model.UsuarioNoCopiaFac;
                usuario.Activo = model.Activo;
                context.Add(usuario);
                await context.SaveChangesAsync();

                return NoContent();
            }
            catch (Exception)
            {
                return NotFound();
            }
        }
        [HttpPut("Usuario")]
        public async Task<ActionResult> UpdateUsuario(usuarioDTO model)
        {
            try
            {
                var Existe = await context.Usuarios.Where(x => x.UsuarioDescId == model.UsuarioDescId && x.UsuarioId != model.UsuarioId).FirstOrDefaultAsync();

                if (Existe != null)
                {
                    return NotFound("Ya existe un Usuario creado con este nombre.");
                }

                Usuario usuario = await context.Usuarios.Where(x => x.UsuarioId == model.UsuarioId).FirstOrDefaultAsync();

                usuario.UsuarioDescId = model.UsuarioDescId;
                usuario.UsuarioPass = CocClave(model.UsuarioPass);
                usuario.UsuarioNombre = model.UsuarioNombre;
                usuario.AutoridadId = model.AutoridadId;
                usuario.UsuarioSiCajero = model.UsuarioSiCajero;
                usuario.AlmacenId = model.AlmacenId;
                usuario.UsuarioSiReAbrirCompra = model.UsuarioSiReAbrirCompra;
                usuario.UsuarioSiAnularFactura = model.UsuarioSiAnularFactura;
                usuario.UsuarioSiReAbrirFactura = model.UsuarioSiReAbrirFactura;
                usuario.UsuarioSiModCredCliente = model.UsuarioSiModCredCliente;
                usuario.UsuarioSiPreFactura = model.UsuarioSiPreFactura;
                usuario.UsuarioSiFacCliSob = model.UsuarioSiFacCliSob;
                usuario.UsuarioSiFacFacVen = model.UsuarioSiFacFacVen;
                usuario.UsuarioSiImpuesto = model.UsuarioSiImpuesto;
                usuario.UsuarioSiBorrarFactura = model.UsuarioSiBorrarFactura;
                usuario.UsuarioNoCopiaFac = model.UsuarioNoCopiaFac;
                usuario.Activo = model.Activo;
                context.Update(usuario);

                await context.SaveChangesAsync();

                return NoContent();
            }
            catch (Exception)
            {
                return NotFound();
            }
        }
        public static string CocClave(string Pass)
        {
            string clave;
            int i;
            string Pass2;
            string CAR;
            string Codigo;
            clave = "|?P}kü~9$G";
            Pass2 = "";
            for (i = 0; i < Pass.Length; i++)
            {
                CAR = Pass.Substring(i, 1);
                Codigo = clave.Substring(((i - 1) % clave.Length) + 1, 1);
                Pass2 = Pass2 + Strings.Right("0" + decimalHexadecimal(Strings.Asc(Codigo) ^ Strings.Asc(CAR)), 2);
            }
            return Pass2;
        }
        public static string DescocClave(string Pass)
        {
            string clave;
            int i;
            string Pass2;
            string CAR;
            string Codigo;
            int j;

            clave = "|?P}kü~9$G";
            Pass2 = "";
            j = 0;
            for (i = 0; i < Pass.Length; i += 2)
            {
                CAR = Pass.Substring(i, 2);
                Codigo = clave.Substring(((j - 1) % Strings.Len(clave)) + 1, 1);
                Pass2 = Pass2 + Strings.Chr(Strings.Asc(Codigo) ^ hexadecimalDecimal(CAR));
                j = j + 1;
            }

            return Pass2;
        }
        public static String decimalHexadecimal(int numero)
        {

            char[] letras = { 'A', 'B', 'C', 'D', 'E', 'F' };

            String hexadecimal = "";

            const int DIVISOR = 16;
            long resto = 0;

            for (int i = numero % DIVISOR, j = 0; numero > 0; numero /= DIVISOR, i = numero % DIVISOR, j++)
            {
                resto = i % DIVISOR;
                if (resto >= 10)
                {
                    hexadecimal = letras[resto - 10] + hexadecimal;

                }
                else
                {
                    hexadecimal = resto + hexadecimal;
                }
            }
            return hexadecimal;

        }

        public static int hexadecimalDecimal(String hexadecimal)
        {

            int numero = 0;

            const int DIVISOR = 16;

            for (int i = 0, j = hexadecimal.Length - 1; i < hexadecimal.Length; i++, j--)
            {

                if (hexadecimal[i] >= '0' && hexadecimal[i] <= '9')
                {
                    numero += (int)Math.Pow(DIVISOR, j) * Convert.ToInt32(hexadecimal[i] + "");
                }
                else if (hexadecimal[i] >= 'A' && hexadecimal[i] <= 'F')
                {
                    numero += (int)Math.Pow(DIVISOR, j) * Convert.ToInt32((hexadecimal[i] - 'A' + 10) + "");
                }
                else
                {
                    return -1;
                }

            }

            return numero;

        }
        //[HttpDelete("Usuario/{usuarioId}")]
        //public async Task<IActionResult> DelUsuario(int usuarioId)
        //{
        //    try
        //    {
        //        var usuarioEnCliente = await context.Clientes.AnyAsync(x => x.UsuarioId == usuarioId);
        //        if (usuarioEnCliente)
        //        {
        //            return NotFound("Usuario no puede ser borrado, ha sido usado en clientes");
        //        }
        //        var usuarioEnfactura = await context.Facturas.AnyAsync(x => x.UsuarioId == usuarioId);
        //        if (usuarioEnfactura)
        //        {
        //            return NotFound("Usuario no puede ser borrado, ha sido usado en facturas.");
        //        }
        //        context.Entry(new Usuario { UsuarioId = usuarioId }).State = EntityState.Deleted;
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
