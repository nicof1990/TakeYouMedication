using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TomarMedicacion.Models;
using TomarMedicacion.Services.Interfaces;

namespace TomarMedicacion.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PacienteController : ControllerBase
    {
        public readonly IPatientService patientService;

        public PacienteController(IPatientService patientService)
        {
            this.patientService = patientService;
        }

        [HttpPost]
        public async Task<ActionResult> CreatePaciente(Paciente paciente)
        {
            var createdPaciente = await patientService.CreateAsync(paciente);
            return Ok(createdPaciente);
        }

        [HttpPut]
        public async Task<ActionResult> UpdatePaciente(Paciente paciente)
        {
            var existingPaciente = await patientService.UpdateAsync(paciente);
            if (existingPaciente == null)
            {
                return NotFound();
            }
            return Ok(existingPaciente);
        }
    }
}
