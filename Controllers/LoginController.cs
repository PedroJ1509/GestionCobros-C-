using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Microsoft.VisualBasic;
using JaMPeApp.DTOs;
using JaMPeApp.Models;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
namespace JaMPeApp.Controllers
{
    public class LoginController : ControllerBase
    {
        private readonly GestionEmpContext context;
        private readonly IConfiguration configuration;

        public LoginController(GestionEmpContext context, IConfiguration configuration)
        {
            this.context = context;
            this.configuration = configuration;
        }
        [HttpPost("/Login")]
        public async Task<IActionResult> Login([FromBody] usuarioLoginDTO model)
        {
            var usuario = await context.Usuarios.Where(x => x.UsuarioDescId == model.Usuario).FirstOrDefaultAsync();

            if (usuario != null)
            {
                if (DescocClave(usuario.UsuarioPass) == model.Contrasena)
                {
                    Int32 EmpresaNo;
                    string NoSeguimiento;
                    bool LicVenc;

                    var general = await context.Generals.FirstOrDefaultAsync();

                    EmpresaNo = Convert.ToInt32(Desencriptar(general.GeneralNoCp.ToString()));
                    LicVenc = false;

                    if (general.GeneralNoSeguimiento.ToString().Substring(0, 1) == "C")
                    {
                        NoSeguimiento = Desencriptar(general.GeneralNoSeguimiento.ToString().Substring(1, general.GeneralNoSeguimiento.ToString().Length - 1));
                        LicVenc = true;
                    }
                    else
                    {
                        NoSeguimiento = Desencriptar(general.GeneralNoSeguimiento.ToString());
                    }
                    if (ComprovarFechaValida(NoSeguimiento, EmpresaNo) == true && LicVenc == false)
                    {
                        var autoridad = await context.Autoridads.Where(x => x.AutoridadId == usuario.AutoridadId).FirstOrDefaultAsync();
                        var pantalla = context.PantallaAutoridads.Where(x => x.AutoridadId == usuario.AutoridadId).ToList();
                        var claims = new List<Claim>
                        {
                            new Claim("Usuario_Nombre", usuario.UsuarioNombre),
                            new Claim("Usuario_ID", usuario.UsuarioId.ToString()),
                            new Claim("Autoridad_ID", usuario.AutoridadId.ToString()),
                            new Claim("Almacen_ID", usuario.AlmacenId.ToString()),
                            new Claim("Usuario_SiCajero", usuario.UsuarioSiCajero.ToString()),
                            new Claim("Usuario_SiReAbrirCompra", usuario.UsuarioSiReAbrirCompra.ToString()),
                            new Claim("Usuario_SiPreFactura", usuario.UsuarioSiPreFactura.ToString()),
                            new Claim("Usuario_SiReAbrirFactura", usuario.UsuarioSiReAbrirFactura.ToString()),
                            new Claim("Usuario_SiAnularFactura", usuario.UsuarioSiAnularFactura.ToString()),
                            new Claim("Usuario_SiBorrarFactura", usuario.UsuarioSiBorrarFactura.ToString()),
                            new Claim("Usuario_SiFacCliSob", usuario.UsuarioSiFacCliSob.ToString()),
                            new Claim("Usuario_SiFacFacVen", usuario.UsuarioSiFacFacVen.ToString()),
                            new Claim("Usuario_SiImpuesto", usuario.UsuarioSiImpuesto.ToString()),
                            new Claim("Usuario_SiModCredCliente", usuario.UsuarioSiModCredCliente.ToString()),
                            new Claim("GeneralNombreEmpresa", general.GeneralEmpresaNombre.ToString()),
                        };

                        var claimsIdentity = new ClaimsIdentity(
                            claims, CookieAuthenticationDefaults.AuthenticationScheme);

                        var authProperties = new AuthenticationProperties
                        {
                            AllowRefresh = true,

                            ExpiresUtc = DateTimeOffset.UtcNow.AddDays(1),

                            IsPersistent = false,
                            // Whether the authentication session is persisted across 
                            // multiple requests. When used with cookies, controls
                            // whether the cookie's lifetime is absolute (matching the
                            // lifetime of the authentication ticket) or session-based.

                            //IssuedUtc = <DateTimeOffset>,
                            // The time at which the authentication ticket was issued.

                            RedirectUri = "/login"
                        };

                        await HttpContext.SignInAsync(
                            CookieAuthenticationDefaults.AuthenticationScheme,
                            new ClaimsPrincipal(claimsIdentity),
                            authProperties);

                        var token = ConstruirToken(usuario, claims);

                        return Ok(new
                        {
                            tk_mjpsoft = token,
                            usuario_Nombre = usuario.UsuarioNombre,
                            usuario_ID= usuario.UsuarioId,
                            autoridad_ID= usuario.AutoridadId,
                            almacen_ID= usuario.AlmacenId,
                            usuario_SiCajero= usuario.UsuarioSiCajero,
                            usuario_SiReAbrirCompra= usuario.UsuarioSiReAbrirCompra,
                            usuario_SiPreFactura= usuario.UsuarioSiPreFactura,
                            usuario_SiReAbrirFactura= usuario.UsuarioSiReAbrirFactura,
                            usuario_SiAnularFactura= usuario.UsuarioSiAnularFactura,
                            usuario_SiBorrarFactura= usuario.UsuarioSiBorrarFactura,
                            usuario_SiFacCliSob= usuario.UsuarioSiFacCliSob,
                            usuario_SiFacFacVen= usuario.UsuarioSiFacFacVen,
                            usuario_SiImpuesto= usuario.UsuarioSiImpuesto,
                            usuario_SiModCredCliente= usuario.UsuarioSiModCredCliente,
                            generalNombreEmpresa= general.GeneralEmpresaNombre
                        });
                    }
                    else
                    {
                        return NotFound("Su licencia ha  caducado, favor comunicarse con los administradores de JaMPe Soft");
                    }
                }
                else
                {
                    return NotFound("Error en las credenciales del usuario, por favor verificar...");
                }
            }
            else
            {
                return NotFound("Error en las credenciales del usuario, por favor verificar...");
            }
        }
        [HttpPost("/EncriptarClave/{usuario}")]
        public async Task<IActionResult> EncriptarClave(string usuario)
        {

            var user = await context.Usuarios.Where(x => x.UsuarioDescId == usuario).FirstOrDefaultAsync();

            if (user != null)
            {
                string claveEncriptada = CocClave(user.UsuarioPass);
                user.UsuarioPass = claveEncriptada;
                context.Update(user);
                await context.SaveChangesAsync();

                return NoContent();
            }
            else
            {
                return NotFound("Usuario no existe...");
            }

        }
        private async Task<RespuestaAutenticacion> ConstruirToken(Usuario usuario, List<Claim> claims)
        {
            var expiracion = DateTime.UtcNow.AddDays(1);

            var llave = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["llavejwt"]));
            var creds = new SigningCredentials(llave, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(issuer: null, audience: null, claims: claims, expires: expiracion, signingCredentials: creds);

            return new RespuestaAutenticacion()
            {
                Token = new JwtSecurityTokenHandler().WriteToken(token),
                Expiracion = expiracion
            };
        }
        private string Encriptar(string _cadenaAencriptar)
        {
            long n;
            string letra;
            int dec = 0;
            string cocinada = "";

            n = Strings.Len(_cadenaAencriptar);

            for (int i = 0; i < n; i++)
            {
                letra = _cadenaAencriptar.Substring(i, 1);

                dec = Strings.Asc(letra) + 123;

                cocinada = cocinada + Strings.Chr(dec);
            }

            return cocinada;
            //string result = string.Empty;
            //byte[] encryted = System.Text.Encoding.Unicode.GetBytes(_cadenaAencriptar);
            //result = Convert.ToBase64String(encryted);
            //return result;
        }
        private string DesEncriptar(string _cadenaAdesencriptar)
        {
            long n;
            string letra;
            int dec;
            string descocinada = "" ;

            n = _cadenaAdesencriptar.Length;

            for (int i = 0; i < n; i++)
            {
                letra = _cadenaAdesencriptar.Substring(i, 1);

                dec = Strings.Asc(letra) - 123;

                descocinada = descocinada + Strings.Chr(dec);
            }

            return descocinada;
            //string result = string.Empty;
            //byte[] decryted = Convert.FromBase64String(_cadenaAdesencriptar);
            ////result = System.Text.Encoding.Unicode.GetString(decryted, 0, decryted.ToArray().Length);
            //result = System.Text.Encoding.Unicode.GetString(decryted);
            //return result;
        }
        public string Desencriptar(string DataValue)
        {
            string Desencriptar = "";
            try
            {
                long X;
                string Temp, HexByte;
                Temp = "";
                for (int i = 0; i < DataValue.Length - 1; i = i + 2)
                {
                    HexByte = DataValue.Substring(i, 2);
                    Temp = Temp + Convert.ToChar(ConvToInt(HexByte)).ToString();
                }
                Desencriptar = Temp;
            }
            catch (Exception)
            {

                Desencriptar = "";
            }
            return Desencriptar;
        }
        private Int32 ConvToInt(string X)
        {
            string x1, x2;
            Int32 Temp;

            x1 = X.Substring(0, 1);
            x2 = X.Substring(1, 1);

            if (IsNumeric(x1))
            {
                Temp = 16 * Convert.ToInt16(x1);
            }
            else
            {
                Temp = (Strings.Asc(x1) - 55) * 16;
            }
            if (IsNumeric(x2))
            {
                Temp = Temp + Convert.ToInt16(x2);
            }
            else
            {
                Temp = Temp + (Strings.Asc(x2) - 55);
            }
            return Temp;
        }
        public static Boolean IsNumeric(string Valor)
        {
            try
            {
                if (Convert.ToDouble(Valor) >= 0)
                {
                    return true;
                }
                else
                {
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }
        public string CocClave(string Pass)
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
        public string DescocClave(string Pass)
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
        public static Boolean ComprovarFechaValida(String CadenaFecha, int UsuarioID)
        {
            try
            {
                if (!String.IsNullOrEmpty(CadenaFecha))
                {
                    string FechaDesencriptada = "";
                    DateTime FechaActual = DateTime.Today;

                    Int32 dia = Convert.ToInt32(CadenaFecha.Substring(0, 10));
                    Int32 mes = Convert.ToInt32(CadenaFecha.Substring(10, 8));
                    Int64 ano = Convert.ToInt64(CadenaFecha.Substring(18, 15));
                    int usuario = Convert.ToInt32(CadenaFecha.Substring(33, 9));

                    int dia1;
                    int mes1;
                    Int64 ano1;
                    int usuario1;

                    dia1 = (((dia - 69548) / 2568) - 31689) / 2541;
                    mes1 = (((mes - 84695) / 1624) - 18274) / 1854;
                    ano1 = (((ano - 96524) / 754) - 89131) / 6584;
                    usuario1 = (((usuario - 5984) / 542) - 9721) / 1725;

                    FechaDesencriptada = ano1 + "-" + mes1 + "-" + dia1;

                    if (dia1 >= 1 && dia1 <= 31)
                    {
                        if (mes1 <= 12 && mes1 > 0)
                        {

                            if ((Convert.ToDateTime(FechaActual.ToString("d")) < Convert.ToDateTime(FechaDesencriptada)) && usuario1 == UsuarioID)
                            {
                                return true;
                            }
                            else
                            {
                                return false;
                            }
                        }
                        else
                        {
                            return false;
                        }
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }
            }
            catch
            {
                return false;
            }
        }



    }
}
