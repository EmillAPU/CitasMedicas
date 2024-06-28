using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DB;

namespace CitasMedicas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MedicoController : ControllerBase
    {
        public readonly CitasMedicasContext _dbcontext;

        public MedicoController(CitasMedicasContext context)
        {
            _dbcontext = context;
        }

        [HttpGet]
        [Route("Lista")]
        public IActionResult Lista()
        {
            List<Medico> lista = new List<Medico>();

            try
            {
                lista = _dbcontext.Medicos.ToList();
                return StatusCode(StatusCodes.Status200OK, new { mensaje = "ok", response = lista });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status200OK, new { mensaje = ex.Message, response = lista });
            }
        }

        [HttpGet]
        [Route("Obtener/{idMedico:int}")]
        public IActionResult Obtener(int idMedico)
        {
            Medico oMedico = _dbcontext.Medicos.Find(idMedico);

            if (oMedico == null)
            {
                return BadRequest("Medico no encontrado");
            }

            try
            {
                return StatusCode(StatusCodes.Status200OK, new { mensaje = "ok", response = oMedico });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status200OK, new { mensaje = ex.Message, response = oMedico });
            }
        }

        [HttpPost]
        [Route("Guardar")]
        public IActionResult Guardar([FromBody] Medico medico)
        {
            try
            {
                _dbcontext.Medicos.Add(medico);
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
        public IActionResult Editar([FromBody] Medico medico)
        {
            Medico oMedico = _dbcontext.Medicos.Find(medico.MedicoId);

            if (oMedico == null)
            {
                return BadRequest("Medico no encontrado");
            }

            try
            {
                oMedico.Nombre = medico.Nombre ?? medico.Nombre;
                oMedico.Apellido = medico.Apellido ?? medico.Apellido;
                _dbcontext.Medicos.Update(medico);
                _dbcontext.SaveChanges();

                return StatusCode(StatusCodes.Status200OK, new { mensaje = "ok" });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status200OK, new { mensaje = ex.Message });
            }
        }

        [HttpDelete]
        [Route("Eliminar/{idMedico:int}")]
        public IActionResult Eliminar(int idMedico)
        {
            Medico oMedico = _dbcontext.Medicos.Find(idMedico);

            if (oMedico == null)
            {
                return BadRequest("Medico no encontrado");
            }

            try
            {
                _dbcontext.Medicos.Remove(oMedico);
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
