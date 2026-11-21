using TomarMedicacion.Models;
using TomarMedicacion.Services.Interfaces;

namespace TomarMedicacion.Services
{
    public class MedicationService: IMedicationService
    {
        public readonly TomarMedicacionContext _context;
        public MedicationService(TomarMedicacionContext context)
        {
            _context = context;
        }
        public async Task<Medicacion> CreateAsync(Medicacion medicacion)
        {
            _context.Medicacion.Add(medicacion);
            await _context.SaveChangesAsync();
            return medicacion;
        }
        public async Task<Medicacion> UpdateAsync(Medicacion medicacion)
        {
            var existingMedicacion = await _context.Medicacion.FindAsync(medicacion.Id);
            if (existingMedicacion == null)
            {
                throw new Exception("Medicacion not found");
            }
            existingMedicacion.Nombre = medicacion.Nombre;
            existingMedicacion.Dosis = medicacion.Dosis;
            await _context.SaveChangesAsync();
            return existingMedicacion;
        }
    }
}
