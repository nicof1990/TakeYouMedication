using Microsoft.AspNetCore.Mvc;
using System.Security.AccessControl;
using TomarMedicacion.Models;
using TomarMedicacion.Services.Interfaces;

namespace TomarMedicacion.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MedicacionController : Controller
    {
        public readonly IMedicationService medicationService;

        public MedicacionController(IMedicationService medicationService)
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
        [HttpGet("{id}")]
        public async Task<ActionResult> GetMedicacion(int id)
        {
            var medicacion = await medicationService.GetByIdAsync(id);
            if (medicacion == null)
            {
                return NotFound();
            }
            return Ok(medicacion);
        }
    }
}
