using TomarMedicacion.Models;
using Microsoft.EntityFrameworkCore;

public class TomarMedicacionContext(DbContextOptions<TomarMedicacionContext> options) : DbContext(options)
{
    public DbSet<TomarMedicacion.Models.Medicacion> Medicacion { get; set; } = default!;
    public DbSet<TomarMedicacion.Models.Paciente> Paciente { get; set; } = default!;
    public DbSet<TomarMedicacion.Models.Recordatorio> Recordatorio { get; set; } = default!;
}

