using TomarMedicacion.Models;

namespace TomarMedicacion.Services.Interfaces
{
    public interface IRecordatorioService
    {
        Task<Recordatorio> CreateAsync(Recordatorio recordatorio);
        Task<Recordatorio> UpdateAsync(Recordatorio recordatorio);
    }
}
