using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DB;

namespace CitasMedicas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EspecialidadController : ControllerBase
    {
        public readonly CitasMedicasContext _dbcontext;

        public EspecialidadController(CitasMedicasContext context)
        {
            _dbcontext = context;
        }

        [HttpGet]
        [Route("Lista")]
        public IActionResult Lista()
        {
            List<Especialidad> lista = new List<Especialidad>();

            try
            {
                lista = _dbcontext.Especialidads.ToList();
                return StatusCode(StatusCodes.Status200OK, new { mensaje = "ok", response = lista });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status200OK, new { mensaje = ex.Message, response = lista });
            }
        }

        [HttpGet]
        [Route("Obtener/{idEspecialidad:int}")]
        public IActionResult Obtener(int idEspecialidad)
        {
            Especialidad oEspecialidad = _dbcontext.Especialidads.Find(idEspecialidad);

            if (oEspecialidad == null)
            {
                return BadRequest("Especialidad no encontrado");
            }

            try
            {
                return StatusCode(StatusCodes.Status200OK, new { mensaje = "ok", response = oEspecialidad });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status200OK, new { mensaje = ex.Message, response = oEspecialidad });
            }
        }

        [HttpPost]
        [Route("Guardar")]
        public IActionResult Guardar([FromBody] Especialidad especialidad)
        {
            try
            {
                _dbcontext.Especialidads.Add(especialidad);
                _dbcontext.SaveChanges();

                return StatusCode(StatusCodes.Status200OK, new { mensaje = "ok" });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status200OK, new { mensaje = ex.Message });
            }
        }

        [HttpPut]
        [Route("Editar")]
        public IActionResult Editar([FromBody] Especialidad especialidad)
        {
            Especialidad oEspecialidad = _dbcontext.Especialidads.Find(especialidad.EspecialidadId);

            if (oEspecialidad == null)
            {
                return BadRequest("Especialidad no encontrada");
            }

            try
            {
                oEspecialidad.Nombre = especialidad.Nombre ?? especialidad.Nombre;
                _dbcontext.Especialidads.Update(especialidad);
                _dbcontext.SaveChanges();

                return StatusCode(StatusCodes.Status200OK, new { mensaje = "ok" });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status200OK, new { mensaje = ex.Message });
            }
        }

        [HttpDelete]
        [Route("Eliminar/{idEspecialidad:int}")]
        public IActionResult Eliminar(int idEspecialidad)
        {
            Especialidad oEspecialidad = _dbcontext.Especialidads.Find(idEspecialidad);

            if (oEspecialidad == null)
            {
                return BadRequest("Especialidad no encontrada");
            }

            try
            {
                _dbcontext.Especialidads.Remove(oEspecialidad);
                _dbcontext.SaveChanges();

                return StatusCode(StatusCodes.Status200OK, new { mensaje = "ok" });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status200OK, new { mensaje = ex.Message });
            }
        }
    }
}
