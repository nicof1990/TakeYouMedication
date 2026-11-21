using TomarMedicacion.Models;

namespace TomarMedicacion.Services.Interfaces
{
    public interface IMedicationService
    {
        Task<Medicacion> CreateAsync(Medicacion medicacion);
        Task<Medicacion> UpdateAsync(Medicacion medicacion);
    }
}
