namespace TomarMedicacion.Models
{
    public class Recordatorio
    {
        public int Id { get; set; }
        public int PacienteId { get; set; }
        public string? Nombre { get; set; }
        public TimeSpan Horario { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime? FechaFin { get; set; }
        //public required ICollection<Dias> Dias { get; set; } = new List<Dias>();
    }
}
