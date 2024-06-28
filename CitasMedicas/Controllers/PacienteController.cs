using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DB;

namespace CitasMedicas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PacienteController : ControllerBase
    {
        public readonly CitasMedicasContext _dbcontext;

        public PacienteController(CitasMedicasContext context)
        {
            _dbcontext = context;
        }

        [HttpGet]
        [Route("Lista")]
        public IActionResult Lista()
        {
            List<Paciente> lista = new List<Paciente>();

            try
            {
                lista = _dbcontext.Pacientes.ToList();
                return StatusCode(StatusCodes.Status200OK, new { mensaje = "ok", response = lista });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status200OK, new { mensaje = ex.Message, response = lista });
            }
        }

        [HttpGet]
        [Route("Obtener/{idPaciente:int}")]
        public IActionResult Obtener(int idPaciente)
        {
            Paciente oPaciente = _dbcontext.Pacientes.Find(idPaciente);

            if (oPaciente == null)
            {
                return BadRequest("Paciente no encontrado");
            }

            try
            {
                return StatusCode(StatusCodes.Status200OK, new { mensaje = "ok", response = oPaciente });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status200OK, new { mensaje = ex.Message, response = oPaciente });
            }
        }

        [HttpPost]
        [Route("Guardar")]
        public IActionResult Guardar([FromBody] Paciente paciente)
        {
            try
            {
                _dbcontext.Pacientes.Add(paciente);
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
        public IActionResult Editar([FromBody] Paciente paciente)
        {
            Paciente oPaciente = _dbcontext.Pacientes.Find(paciente.PacienteId);

            if (oPaciente == null)
            {
                return BadRequest("Paciente no encontrado");
            }

            try
            {
                oPaciente.Nombre = paciente.Nombre ?? oPaciente.Nombre;
                oPaciente.Apellido = paciente.Apellido ?? oPaciente.Apellido;
                _dbcontext.Pacientes.Update(oPaciente);
                _dbcontext.SaveChanges();

                return StatusCode(StatusCodes.Status200OK, new { mensaje = "ok" });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status200OK, new { mensaje = ex.Message });
            }
        }

        [HttpDelete]
        [Route("Eliminar/{idPaciente:int}")]
        public IActionResult Eliminar(int idPaciente)
        {
            Paciente oPaciente = _dbcontext.Pacientes.Find(idPaciente);

            if (oPaciente == null)
            {
                return BadRequest("Paciente no encontrado");
            }

            try
            {
                _dbcontext.Pacientes.Remove(oPaciente);
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
