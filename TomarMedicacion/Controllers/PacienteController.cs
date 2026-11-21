using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TomarMedicacion.Models;

namespace TomarMedicacion.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PacienteController : ControllerBase
    {
        public readonly TomarMedicacionContext _context;

        public PacienteController(TomarMedicacionContext context)
        {
            _context = context;
        }

        [HttpPost]
        public ActionResult CreatePaciente(Paciente paciente)
        {
            _context.Paciente.Add(paciente);
            _context.SaveChanges();
            return Ok(paciente);
        }

        [HttpPut]
        public ActionResult UpdatePaciente(Paciente paciente)
        {
            var existingPaciente = _context.Paciente.Find(paciente.Id);
            if (existingPaciente == null)
            {
                return NotFound();
            }
            existingPaciente.Nombre = paciente.Nombre;
            existingPaciente.Celular = paciente.Celular;
            _context.SaveChanges();
            return Ok(existingPaciente);
        }
    }
}
