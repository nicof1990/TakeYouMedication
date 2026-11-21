using TomarMedicacion.Models;

namespace TomarMedicacion.Services.Interfaces
{
    public interface IRecortadorioService
    {
        Task<Recordatorio> CreateAsync(Recordatorio recordatorio);
        Task<Recordatorio> UpdateAsync(Recordatorio recordatorio);
    }
}
