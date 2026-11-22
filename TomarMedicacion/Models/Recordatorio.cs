namespace TomarMedicacion.Models
{
    public class Recordatorio
    {
        public int Id { get; set; }
        public int PacienteId { get; set; }
        public int MedicacionId { get; set; } 
        public string? Nombre { get; set; }
        public TimeOnly Horario { get; set; }
        public DateOnly FechaInicio { get; set; }
        public DateOnly? FechaFin { get; set; }
        public long? ChatID { get; set; }
        //public required ICollection<Dias> Dias { get; set; } = new List<Dias>();
    }
}
