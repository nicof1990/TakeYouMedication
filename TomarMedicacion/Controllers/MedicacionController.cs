using Microsoft.AspNetCore.Mvc;
using TomarMedicacion.Models;
using TomarMedicacion.Services;

namespace TomarMedicacion.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MedicacionController : Controller
    {
        public readonly MedicationService medicationService;

        public MedicacionController(MedicationService medicationService)
        {
            this.medicationService = medicationService;
        }

        [HttpPost]
        public async Task<ActionResult> CreateAsync(Medicacion medicacion)
        {
           await medicationService.CreateAsync(medicacion);
           return Ok(medicacion);
        }

        [HttpPut] // otra manera [HttpPut("{id}")], con el id dentro de los parámetros del método.
        public async Task<ActionResult> UpdateMedicacion(Medicacion medicacion)
        {
            var existingMedicacion = await medicationService.UpdateAsync(medicacion);
            if (existingMedicacion == null)
            {
                return NotFound();
            }
            return Ok(existingMedicacion);
        }
    }
}
