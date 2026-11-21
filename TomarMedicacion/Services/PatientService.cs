using TomarMedicacion.Models;
using TomarMedicacion.Services.Interfaces;

namespace TomarMedicacion.Services
{
    public class PatientService: IPatientService
    {
        public readonly TomarMedicacionContext _context;

        public PatientService(TomarMedicacionContext context)
        {
            _context = context;
        }

        public async Task<Paciente> CreateAsync(Paciente paciente)
        {
            _context.Paciente.Add(paciente);
            await _context.SaveChangesAsync();
            return paciente;
        }
        public async Task<Paciente> UpdateAsync(Paciente paciente)
        {
            var existingPaciente = await _context.Paciente.FindAsync(paciente.Id);
            if (existingPaciente == null)
            {
                throw new Exception("Paciente not found");
            }
            existingPaciente.Nombre = paciente.Nombre;
            existingPaciente.Celular = paciente.Celular;
            await _context.SaveChangesAsync();
            return existingPaciente;
        }
    }
}
