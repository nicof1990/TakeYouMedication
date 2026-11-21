using TomarMedicacion.Models;

namespace TomarMedicacion.DTOs
{
    public class RecordatorioDTO
    {
        public required ICollection<Medicacion> Medicaciones { get; set; } = new List<Medicacion>();
        public string? Nombre { get; set; }
        public TimeSpan Horario { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime? FechaFin { get; set; }
        public required ICollection<Dias> Dias { get; set; } = new List<Dias>();
    }
}
