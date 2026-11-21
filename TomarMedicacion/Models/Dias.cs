namespace TomarMedicacion.Models
{
    public class Dias
    {
        public int Id { get; set; }
        public ICollection<DayOfWeek> DiasSemana { get; set; } = new List<DayOfWeek>() {
            DayOfWeek.Monday, DayOfWeek.Tuesday, DayOfWeek.Wednesday, DayOfWeek.Thursday, DayOfWeek.Friday, DayOfWeek.Saturday, DayOfWeek.Sunday
        };
    }
}
