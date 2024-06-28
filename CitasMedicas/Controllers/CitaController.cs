using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DB;

namespace CitasMedicas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CitaController : ControllerBase
    {
        public readonly CitasMedicasContext _dbcontext;

        public CitaController(CitasMedicasContext context)
        {
            _dbcontext = context;
        }

        [HttpGet]
        [Route("Lista")]
        public IActionResult Lista()
        {
            List<Cita> lista = new List<Cita>();

            try
            {
                lista = _dbcontext.Citas.ToList();
                return StatusCode(StatusCodes.Status200OK, new { mensaje = "ok", response = lista });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status200OK, new { mensaje = ex.Message, response = lista });
            }
        }

        [HttpGet]
        [Route("Obtener/{idCita:int}")]
        public IActionResult Obtener(int idCita)
        {
            Cita oCita = _dbcontext.Citas.Find(idCita);

            if (oCita == null)
            {
                return BadRequest("Cita no encontrada");
            }

            try
            {
                return StatusCode(StatusCodes.Status200OK, new { mensaje = "ok", response = oCita });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status200OK, new { mensaje = ex.Message, response = oCita });
            }
        }

        [HttpPost]
        [Route("Guardar")]
        public IActionResult Guardar([FromBody] Cita cita)
        {
            try
            {
                _dbcontext.Citas.Add(cita);
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
        public IActionResult Editar([FromBody] Cita cita)
        {
            Cita oCita = _dbcontext.Citas.Find(cita.CitaId);

            if (oCita == null)
            {
                return BadRequest("Cita no encontrada");
            }

            try
            {
                _dbcontext.Citas.Update(oCita);
                _dbcontext.SaveChanges();

                return StatusCode(StatusCodes.Status200OK, new { mensaje = "ok" });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status200OK, new { mensaje = ex.Message });
            }
        }

        [HttpDelete]
        [Route("Eliminar/{idCita:int}")]
        public IActionResult Eliminar(int idCita)
        {
            Cita oCita = _dbcontext.Citas.Find(idCita);

            if (oCita == null)
            {
                return BadRequest("Cita no encontrada");
            }

            try
            {
                _dbcontext.Citas.Remove(oCita);
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
