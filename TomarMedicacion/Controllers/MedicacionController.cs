using Microsoft.AspNetCore.Mvc;
using TomarMedicacion.Models;

namespace TomarMedicacion.Controllers
{
    public class MedicacionController : Controller
    {
        public readonly TomarMedicacionContext _context;

        public MedicacionController(TomarMedicacionContext context)
        {
            _context = context;
        }

        [HttpPost]
        public ActionResult Index(Medicacion medicacion)
        {
            _context.Medicacion.Add(medicacion);
            _context.SaveChanges();
            return Ok(medicacion);
        }

        [HttpPut] // otra manera [HttpPut("{id}")], con el id dentro de los parámetros del método.
        public ActionResult UpdateMedicacion(Medicacion medicacion)
        {
            var existingMedicacion = _context.Medicacion.Find(medicacion.Id);
            if (existingMedicacion == null)
            {
                return NotFound();
            }
            existingMedicacion.Nombre = medicacion.Nombre;
            existingMedicacion.Dosis = medicacion.Dosis;
            _context.SaveChanges();
            return Ok(existingMedicacion);
        }
    }
}
