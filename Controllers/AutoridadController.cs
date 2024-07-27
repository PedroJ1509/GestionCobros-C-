using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using JaMPeApp.DTOs;
using JaMPeApp.Models;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;

namespace JaMPeApp.Controllers
{
    [ApiController]
    [Authorize(AuthenticationSchemes = CookieAuthenticationDefaults.AuthenticationScheme)]
    public class AutoridadController : ControllerBase
    {
        private readonly GestionEmpContext context;
        public AutoridadController(GestionEmpContext context)
        {
            this.context = context;
        }
        [HttpGet("listadoAutoridad")]
        public async Task<List<autoridadDTO>> listadoAutoridad()
        {
            var result = new List<autoridadDTO>();

            var query = (
                from autoridad in context.Autoridads
                from pantalla in context.Pantallas.Where(x => x.PantallaId == autoridad.PantallaId).DefaultIfEmpty()
                select new autoridadDTO
                {
                    AutoridadId = autoridad.AutoridadId,
                    AutoridadDesc = autoridad.AutoridadDesc,
                    PantallaId = autoridad.PantallaId.ToString(),
                    PantallaDesc = pantalla.PantallaDesc
                }
            );
            result = await query.OrderBy(x => x.AutoridadDesc).ToListAsync();

            return result;
        }
        [HttpGet("Autoridad")]
        public async Task<List<autoridadDTO>> Autoridad()
        {
            var result = new List<autoridadDTO>();

            var query = (
                from data in context.Autoridads
                select new autoridadDTO
                {
                    AutoridadId = data.AutoridadId,
                    AutoridadDesc = String.IsNullOrEmpty(data.AutoridadDesc) ? "" : data.AutoridadDesc,
                    PantallaId = data.PantallaId.ToString()
                }
            );
            result = await query.OrderBy(x => x.AutoridadDesc).ToListAsync();

            return result;
        }
        [HttpGet("AlmacenesNoAsignados/{autoridadId}")]
        public async Task<List<almacenAutoridadDTO>> AlmacenesNoAsignados(int autoridadId)
        {
            var result = new List<almacenAutoridadDTO>();

            List<int> listAlmacen = await context.AlmacenAutoridads.Where(x => x.AutoridadId == autoridadId).Select(x => x.AlmacenId).ToListAsync();

            var query = (
                from data in context.Almacens.Where(x => !listAlmacen.Contains(x.AlmacenId))
                select new almacenAutoridadDTO
                {
                    almacenId = data.AlmacenId,
                    almacenDesc = data.AlmacenDesc,
                }
            );
            result = await query.OrderBy(x => x.almacenDesc).ToListAsync();

            return result;
        }
        [HttpGet("AlmacenesAsignados/{autoridadId}")]
        public async Task<List<almacenAutoridadDTO>> AlmacenesAsignados(int autoridadId)
        {
            var result = new List<almacenAutoridadDTO>();

            var query = (
                from data in context.AlmacenAutoridads.Where(x => x.AutoridadId == autoridadId)
                from almacen in context.Almacens.Where(x => x.AlmacenId == data.AlmacenId)
                select new almacenAutoridadDTO
                {
                    almacenId = data.AlmacenId,
                    almacenDesc = almacen.AlmacenDesc,
                }
            );
            result = await query.OrderBy(x => x.almacenDesc).ToListAsync();

            return result;
        }
        [HttpGet("PantallasNoAsignados/{autoridadId}")]
        public async Task<List<pantallaDTO>> PantallasNoAsignados(int autoridadId)
        {
            var result = new List<pantallaDTO>();

            List<short> listPantallas = await context.PantallaAutoridads.Where(x => x.AutoridadId == (short)autoridadId).Select(x => x.PantallaId).ToListAsync();

            var query = (
                from data in context.Pantallas.Where(x => !listPantallas.Contains(x.PantallaId))
                select new pantallaDTO
                {
                    PantallaId = data.PantallaId,
                    PantallaDesc = data.PantallaDesc,
                }
            );
            result = await query.OrderBy(x => x.PantallaDesc).ToListAsync();

            return result;
        }
        [HttpGet("PantallasAsignados/{autoridadId}")]
        public async Task<List<pantallaDTO>> PantallasAsignados(int autoridadId)
        {
            var result = new List<pantallaDTO>();

            var query = (
                from data in context.PantallaAutoridads.Where(x => x.AutoridadId == autoridadId)
                from pantalla in context.Pantallas.Where(x => x.PantallaId == data.PantallaId)
                select new pantallaDTO
                {
                    PantallaId = data.PantallaId,
                    PantallaDesc = pantalla.PantallaDesc,
                }
            );
            result = await query.OrderBy(x => x.PantallaDesc).ToListAsync();

            return result;
        }
        [HttpGet("DepartamentosNoAsignados/{autoridadId}")]
        public async Task<List<departamentoDTO>> DepartamentosNoAsignados(int autoridadId)
        {
            var result = new List<departamentoDTO>();

            List<int> listDepartamentos = await context.DepartamentoAutoridads.Where(x => x.AutoridadId == (short)autoridadId).Select(x => x.DepartamentoId).ToListAsync();

            var query = (
                from data in context.Departamentos.Where(x => !listDepartamentos.Contains(x.DepartamentoId))
                select new departamentoDTO
                {
                    DepartamentoId = data.DepartamentoId,
                    DepartamentoDesc = data.DepartamentoDesc,
                }
            );
            result = await query.OrderBy(x => x.DepartamentoDesc).ToListAsync();

            return result;
        }
        [HttpGet("DepartamentosAsignados/{autoridadId}")]
        public async Task<List<departamentoDTO>> DepartamentosAsignados(int autoridadId)
        {
            var result = new List<departamentoDTO>();

            var query = (
                from data in context.DepartamentoAutoridads.Where(x => x.AutoridadId == autoridadId)
                from depto in context.Departamentos.Where(x => x.DepartamentoId == data.DepartamentoId)
                select new departamentoDTO
                {
                    DepartamentoId = data.DepartamentoId,
                    DepartamentoDesc = depto.DepartamentoDesc,
                }
            );
            result = await query.OrderBy(x => x.DepartamentoDesc).ToListAsync();

            return result;
        }
        [HttpGet("PrivilegiosNoAsignados/{autoridadId}")]
        public async Task<List<privilegioDTO>> PrivilegiosNoAsignados(int autoridadId)
        {
            var result = new List<privilegioDTO>();

            //List<short> listPrivilegios = await context.PrivilegiosAutoridads.Where(x => x.AutoridadId == (short)autoridadId).Select(x => x.PrivilegiosId).ToListAsync();

            //var query = (
            //    from data in context.Privilegios.Where(x => !listPrivilegios.Contains(x.PrivilegiosId))
            //    select new privilegioDTO
            //    {
            //        PrivilegioId = data.PrivilegiosId,
            //        PrivilegioDesc = data.PrivilegiosDesc,
            //    }
            //);
            //result = await query.OrderBy(x => x.PrivilegioDesc).ToListAsync();

            return result;
        }
        [HttpGet("PrivilegiosAsignados/{autoridadId}")]
        public async Task<List<privilegioDTO>> PrivilegiosAsignados(int autoridadId)
        {
            var result = new List<privilegioDTO>();

            //var query = (
            //    from data in context.PrivilegiosAutoridads.Where(x => x.AutoridadId == autoridadId)
            //    from priv in context.Privilegios.Where(x => x.PrivilegiosId == data.PrivilegiosId)
            //    select new privilegioDTO
            //    {
            //        PrivilegioId = data.PrivilegiosId,
            //        PrivilegioDesc = priv.PrivilegiosDesc,
            //    }
            //);
            //result = await query.OrderBy(x => x.PrivilegioDesc).ToListAsync();

            return result;
        }
        [HttpGet("ReportesNoAsignados/{autoridadId}")]
        public async Task<List<reporteDTO>> ReportesNoAsignados(int autoridadId)
        {
            var result = new List<reporteDTO>();

            List<int?> listReportes = await context.GrupoReportesAutoridads.Where(x => x.AutoridadId == (short)autoridadId).Select(x => x.GrupoReporteId).ToListAsync();

            var query = (
                from data in context.GrupoReportes.Where(x => !listReportes.Contains(x.GrupoReporteId))
                select new reporteDTO
                {
                    ReporteId = data.GrupoReporteId,
                    ReporteDesc = data.GrupoReporteDesc,
                }
            );
            result = await query.OrderBy(x => x.ReporteDesc).ToListAsync();

            return result;
        }
        [HttpGet("ReportesAsignados/{autoridadId}")]
        public async Task<List<reporteDTO>> ReportesAsignados(int autoridadId)
        {
            var result = new List<reporteDTO>();

            var query = (
                from data in context.GrupoReportesAutoridads.Where(x => x.AutoridadId == autoridadId)
                from rep in context.GrupoReportes.Where(x => x.GrupoReporteId == data.GrupoReporteId)
                select new reporteDTO
                {
                    ReporteId = data.GrupoReporteId,
                    ReporteDesc = rep.GrupoReporteDesc,
                }
            );
            result = await query.OrderBy(x => x.ReporteDesc).ToListAsync();

            return result;
        }
        [HttpGet("Autoridad/{autoridadId}")]
        public async Task<autoridadDTO> GetAutoridad(int autoridadId)
        {
            autoridadDTO autoridad = new autoridadDTO();

            try
            {
                var result = await context.Autoridads.Where(x => x.AutoridadId == autoridadId).FirstOrDefaultAsync();

                if (result != null)
                {
                    autoridad.AutoridadId = result.AutoridadId;
                    autoridad.AutoridadDesc = result.AutoridadDesc;
                    autoridad.PantallaId = result.PantallaId.ToString();
                }
            }
            catch (Exception)
            {

            }
            return autoridad;
        }
        [HttpPost("Autoridad")]
        public async Task<ActionResult> PostAutoridad(autoridadDTO model)
        {
            try
            {
                var Existe = await context.Autoridads.Where(x => x.AutoridadDesc == model.AutoridadDesc).FirstOrDefaultAsync();

                if (Existe != null)
                {
                    return NotFound("Ya existe una Autoridad creada con esta descripción y/o número.");
                }

                int autorId = await context.Autoridads.Select(x => x.AutoridadId).MaxAsync();

                Autoridad autoridad = new Autoridad();
                autoridad.AutoridadId = (short)(autorId +1);
                autoridad.AutoridadDesc = model.AutoridadDesc;
                autoridad.PantallaId = (short)Convert.ToInt32(model.PantallaId);
                context.Add(autoridad);
                await context.SaveChangesAsync();

                return NoContent();
            }
            catch (Exception)
            {
                return NotFound();
            }
        }
        [HttpPut("Autoridad")]
        public async Task<ActionResult> UpdateAutoridad(autoridadDTO model)
        {
            try
            {
                var Existe = await context.Autoridads.Where(x => x.AutoridadDesc == model.AutoridadDesc && x.AutoridadId != model.AutoridadId).FirstOrDefaultAsync();

                if (Existe != null)
                {
                    return NotFound("Ya existe una Mesa creada con esta descripción.");
                }

                Autoridad autoridad = await context.Autoridads.Where(x => x.AutoridadId ==  model.AutoridadId).FirstOrDefaultAsync();

                autoridad.AutoridadDesc = model.AutoridadDesc;
                autoridad.PantallaId = (short)Convert.ToInt32(model.PantallaId);
                context.Update(autoridad);

                await context.SaveChangesAsync();

                return NoContent();
            }
            catch (Exception)
            {
                return NotFound("No se pudo guardar la información enviada.");
            }
        }
        [HttpDelete("Autoridad/{autoridadId}")]
        public async Task<IActionResult> DelAutoridad(int autoridadId)
        {
            try
            {
                var autoridadEnUsuario = await context.Usuarios.AnyAsync(x => x.AutoridadId == autoridadId);
                if (autoridadEnUsuario)
                {
                    return NotFound("Autoridad no puede ser borrada");
                }
                context.Entry(new Autoridad { AutoridadId = (short)autoridadId }).State = EntityState.Deleted;
                await context.SaveChangesAsync();
                return NoContent();
            }
            catch (System.Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpPost("AsignarAlamcen")]
        public async Task<ActionResult> AsignarAlamcen(autorAlmacenDTO model)
        {
            try
            {
                AlmacenAutoridad autoridad = new AlmacenAutoridad();
                autoridad.AutoridadId = (short)model.autorId;
                autoridad.AlmacenId = model.almacenId;
                context.Add(autoridad);
                await context.SaveChangesAsync();

                return NoContent();
            }
            catch (Exception)
            {
                return NotFound();
            }
        }
        [HttpPost("QuitarAlmacen")]
        public async Task<ActionResult> QuitarAlmacen(autorAlmacenDTO model)
        {
            try
            {

                AlmacenAutoridad autoridad = await context.AlmacenAutoridads.Where(x => x.AlmacenId == model.almacenId && x.AutoridadId == (short)model.autorId).FirstOrDefaultAsync();
                context.Remove(autoridad);
                await context.SaveChangesAsync();

                return NoContent();
            }
            catch (Exception)
            {
                return NotFound();
            }
        }


        [HttpPost("AsignarPantalla")]
        public async Task<ActionResult> AsignarPantalla(autorPantallaDTO model)
        {
            try
            {
                PantallaAutoridad autoridad = new PantallaAutoridad();
                autoridad.AutoridadId = (short)model.autorId;
                autoridad.PantallaId = (short)model.pantallaId;
                context.Add(autoridad);
                await context.SaveChangesAsync();

                return NoContent();
            }
            catch (Exception)
            {
                return NotFound();
            }
        }
        [HttpPost("QuitarPantalla")]
        public async Task<ActionResult> QuitarPantalla(autorPantallaDTO model)
        {
            try
            {

                PantallaAutoridad autoridad = await context.PantallaAutoridads.Where(x => x.PantallaId == model.pantallaId && x.AutoridadId == (short)model.autorId).FirstOrDefaultAsync();
                context.Remove(autoridad);
                await context.SaveChangesAsync();

                return NoContent();
            }
            catch (Exception)
            {
                return NotFound();
            }
        }

        [HttpPost("AsignarDepartamento")]
        public async Task<ActionResult> AsignarDepartamento(autorDepartamentoDTO model)
        {
            try
            {
                DepartamentoAutoridad autoridad = new DepartamentoAutoridad();
                autoridad.AutoridadId = (short)model.autorId;
                autoridad.DepartamentoId = (short)model.departamentoId;
                context.Add(autoridad);
                await context.SaveChangesAsync();

                return NoContent();
            }
            catch (Exception)
            {
                return NotFound();
            }
        }
        [HttpPost("QuitarDepartamento")]
        public async Task<ActionResult> QuitarDepartamento(autorDepartamentoDTO model)
        {
            try
            {

                DepartamentoAutoridad autoridad = await context.DepartamentoAutoridads.Where(x => x.DepartamentoId == model.departamentoId && x.AutoridadId == (short)model.autorId).FirstOrDefaultAsync();
                context.Remove(autoridad);
                await context.SaveChangesAsync();

                return NoContent();
            }
            catch (Exception)
            {
                return NotFound();
            }
        }
        [HttpPost("AsignarPrivilegio")]
        public async Task<ActionResult> AsignarPrivilegio(autorPrivilegioDTO model)
        {
            try
            {
                PrivilegiosAutoridad autoridad = new PrivilegiosAutoridad();
                autoridad.AutoridadId = (short)model.autorId;
                autoridad.PrivilegiosId = (short)model.privilegioId;
                context.Add(autoridad);
                await context.SaveChangesAsync();

                return NoContent();
            }
            catch (Exception)
            {
                return NotFound();
            }
        }
        [HttpPost("QuitarPrivilegio")]
        public async Task<ActionResult> QuitarPrivilegio(autorPrivilegioDTO model)
        {
            try
            {

                //PrivilegiosAutoridad autoridad = await context.PrivilegiosAutoridads.Where(x => x.PrivilegiosId == model.privilegioId && x.AutoridadId == (short)model.autorId).FirstOrDefaultAsync();
                //context.Remove(autoridad);
                //await context.SaveChangesAsync();

                return NoContent();
            }
            catch (Exception)
            {
                return NotFound();
            }
        }
        [HttpPost("AsignarReporte")]
        public async Task<ActionResult> AsignarReporte(autorReporteDTO model)
        {
            try
            {
                GrupoReportesAutoridad autoridad = new GrupoReportesAutoridad();
                autoridad.AutoridadId = (short)model.autorId;
                autoridad.GrupoReporteId = (short)model.reporteId;
                context.Add(autoridad);
                await context.SaveChangesAsync();

                return NoContent();
            }
            catch (Exception)
            {
                return NotFound();
            }
        }
        [HttpPost("QuitarReporte")]
        public async Task<ActionResult> QuitarReporte(autorReporteDTO model)
        {
            try
            {

                GrupoReportesAutoridad autoridad = await context.GrupoReportesAutoridads.Where(x => x.GrupoReporteId == model.reporteId && x.AutoridadId == (short)model.autorId).FirstOrDefaultAsync();
                context.Remove(autoridad);
                await context.SaveChangesAsync();

                return NoContent();
            }
            catch (Exception)
            {
                return NotFound();
            }
        }
    }
}
