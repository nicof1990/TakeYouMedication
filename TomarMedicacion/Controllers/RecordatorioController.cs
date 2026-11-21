using Microsoft.AspNetCore.Mvc;
using TomarMedicacion.Models;

namespace TomarMedicacion.Controllers
{
    public class RecordatorioController : Controller
    {
        public readonly TomarMedicacionContext _context;
        public RecordatorioController(TomarMedicacionContext context)
        {
            _context = context;
        }

        [HttpGet("{pacienteId}")]
        public ActionResult Index(int pacienteID)
        {
            Recordatorio? recordatorio = _context.Recordatorio.FirstOrDefault(r => r.PacienteId == pacienteID);
            if (recordatorio == null)
            {
                return NotFound();
            }
            return Ok(recordatorio);
        }

        [HttpPost]
        public ActionResult CreateRecordatorio(Recordatorio recordatorio)
        {
            _context.Recordatorio.Add(recordatorio);
            _context.SaveChanges();
            return Ok(recordatorio);
        }

        [HttpPatch]
        public ActionResult UpdateRecordatorio(Recordatorio recordatorio)
        {
            var existingRecordatorio = _context.Recordatorio.Find(recordatorio.Id);
            if (existingRecordatorio == null)
            {
                return NotFound();
            }
            existingRecordatorio.PacienteId = recordatorio.PacienteId;
            existingRecordatorio.Horario = recordatorio.Horario;
            existingRecordatorio.Medicaciones = recordatorio.Medicaciones;
            existingRecordatorio.Nombre = recordatorio.Nombre;
            existingRecordatorio.FechaFin = recordatorio.FechaFin;
            existingRecordatorio.Dias = recordatorio.Dias;

            _context.SaveChanges();
            return Ok(existingRecordatorio);
        }
    }
}
