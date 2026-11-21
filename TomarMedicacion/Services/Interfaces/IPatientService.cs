using TomarMedicacion.Models;

namespace TomarMedicacion.Services.Interfaces
{
    public interface IPatientService
    {
        Task<Paciente> CreateAsync(Paciente paciente);
        Task<Paciente> UpdateAsync(Paciente paciente);
    }
}
