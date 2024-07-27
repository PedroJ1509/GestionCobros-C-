using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using JaMPeApp.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace JaMPeApp.Controllers
{

    [Authorize]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly GestionEmpContext context;

        public HomeController(ILogger<HomeController> logger, GestionEmpContext context)
        {
            _logger = logger;
            this.context = context;
        }
        [HttpGet("/")]
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet("Clientes")]
        public IActionResult IndexCliente()
        {
            return View();
        }
        [HttpGet("Facturas")]
        public IActionResult Facturas()
        {
            return View();
        }
        [HttpGet("IndexOrdenCompra")]
        public IActionResult IndexOrdenCompra()
        {
            return View();
        }
        [HttpGet("Index_AnalisisCosto")]
        public IActionResult IndexAnalisisCosto()
        {
            return View();
        }
        [HttpGet("Articulos")]
        public IActionResult IndexArticulo()
        {

            var generales = context.Generals.FirstOrDefault();

            ViewBag.Modelo = generales.GeneralEtiquetaModelo.ToLower();
            ViewBag.Marca = generales.GeneralEtiquetaMarca.ToLower();
            return View();
        }
        [HttpGet("Index_Planes")]
        public IActionResult IndexPlan()
        {
            return View();
        }
        [HttpGet("Index_Autoridad")]
        public IActionResult IndexAutoridad()
        {
            return View();
        }
        [HttpGet("Index_Usuario")]
        public IActionResult IndexUsuario()
        {
            return View();
        }
        [HttpGet("Index_Plantas")]
        public IActionResult IndexPlanta()
        {
            return View();
        }
        [HttpGet("Index_TipoHabitacion")]
        public IActionResult IndexTipoHabitacion()
        {
            return View();
        }
        [HttpGet("Index_TipoHospedaje")]
        public IActionResult IndexTipoHospedaje()
        {
            return View();
        }
        [HttpGet("Index_TipoCliente")]
        public IActionResult IndexTipoCliente()
        {
            return View();
        }
        [HttpGet("Index_Unidad")]
        public IActionResult IndexUnidad()
        {
            return View();
        }
        [HttpGet("Index_Habitacion")]
        public IActionResult IndexHabitacion()
        {
            return View();
        }
        [HttpGet("Index_Tarifa")]
        public IActionResult IndexTarifa()
        {
            return View();
        }
        [HttpGet("Index_Sala")]
        public IActionResult IndexSala()
        {
            return View();
        }
        [HttpGet("Index_Mesa")]
        public IActionResult IndexMesa()
        {
            return View();
        }
        [HttpGet("Index_Vendedor")]
        public IActionResult IndexVendedor()
        {
            return View();
        }
        [HttpGet("Index_Reservas")]
        public IActionResult IndexReservas()
        {
            return View();
        }
        [HttpGet("/ConsultaInv")]
        public IActionResult IndexConsInventario()
        {
            return View();
        }
        [HttpGet("Index_CheckIn")]
        public IActionResult IndexCheckin()
        {
            var generales = context.Generals.FirstOrDefault();
            var cliente = context.Clientes.FirstOrDefault(x => x.ClienteId == generales.GeneralClienteId);

            ViewBag.ClienteContado = generales.GeneralClienteId.ToString();
            ViewBag.CondicionGeneral = cliente.CondPagoId.ToString();
            ViewBag.VendedorGeneral = cliente.VendedorId.ToString();
            ViewBag.ComprobanteGeneral = generales.GeneralComprobanteTipoId.ToString();

            return View();
        }

        [HttpGet("EncriptarClaveUser")]
        public IActionResult EncriptarClaveUser()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }
        [AllowAnonymous]
        [HttpGet("/login")]
        public IActionResult login()
        {
            return View();
        }
        [HttpGet("/Logout")]
        public IActionResult Logout()
        {
            HttpContext.SignOutAsync(
            CookieAuthenticationDefaults.AuthenticationScheme);

            return Redirect("/login");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
