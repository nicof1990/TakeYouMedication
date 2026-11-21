using TomarMedicacion.Models;
using TomarMedicacion.Services.Interfaces;

namespace TomarMedicacion.Services
{
    public class RecordatorioService: IRecordatorioService
    {
        public readonly TomarMedicacionContext _context;
        public RecordatorioService(TomarMedicacionContext context)
        {
            _context = context;
        }
        public async Task<Recordatorio> CreateAsync(Recordatorio recordatorio)
        {
            _context.Recordatorio.Add(recordatorio);
            await _context.SaveChangesAsync();
            return recordatorio;
        }
        public async Task<Recordatorio> UpdateAsync(Recordatorio recordatorio)
        {
            var existingRecordatorio = await _context.Recordatorio.FindAsync(recordatorio.Id);
            if (existingRecordatorio == null)
            {
                throw new Exception("Recordatorio not found");
            }
            existingRecordatorio.PacienteId = recordatorio.PacienteId;
            existingRecordatorio.Horario = recordatorio.Horario;
            existingRecordatorio.Nombre = recordatorio.Nombre;
            existingRecordatorio.FechaFin = recordatorio.FechaFin;
            await _context.SaveChangesAsync();
            return existingRecordatorio;
        }
    }
}
