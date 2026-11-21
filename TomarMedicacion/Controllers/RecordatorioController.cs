using Microsoft.AspNetCore.Mvc;
using TomarMedicacion.Models;
using TomarMedicacion.Services.Interfaces;

namespace TomarMedicacion.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecordatorioController : Controller
    {
        public readonly IRecordatorioService _serviceRecordatorio;
        public RecordatorioController(IRecordatorioService serviceRecordatorio)
        {
            _serviceRecordatorio = serviceRecordatorio;
        }

        //[HttpGet("{pacienteId}")]
        //public ActionResult Index(int pacienteID)
        //{
        //    Recordatorio? recordatorio = _serviceRecordatorio.(pacienteID);
        //    if (recordatorio == null)
        //    {
        //        return NotFound();
        //    }
        //    return Ok(recordatorio);
        //}

        [HttpPost]
        public async Task<ActionResult> CreateRecordatorio(Recordatorio recordatorio)
        {
            await _serviceRecordatorio.CreateAsync(recordatorio);
            return Ok(recordatorio);
        }

        //[HttpPatch]
        //public ActionResult UpdateRecordatorio(Recordatorio recordatorio)
        //{
        //    var existingRecordatorio = _serviceRecordatorio.Recordatorio.Find(recordatorio.Id);
        //    if (existingRecordatorio == null)
        //    {
        //        return NotFound();
        //    }
        //    existingRecordatorio.PacienteId = recordatorio.PacienteId;
        //    existingRecordatorio.Horario = recordatorio.Horario;
        //    existingRecordatorio.Medicaciones = recordatorio.Medicaciones;
        //    existingRecordatorio.Nombre = recordatorio.Nombre;
        //    existingRecordatorio.FechaFin = recordatorio.FechaFin;
        //    existingRecordatorio.Dias = recordatorio.Dias;

        //    _context.SaveChanges();
        //    return Ok(existingRecordatorio);
        //}
    }
}
